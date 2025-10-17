using DigitalNotesManager.Data;
using DigitalNotesManager.Helpers;
using DigitalNotesManager.Models;
using System.Text;

namespace DigitalNotesManager
{
    public partial class NoteEditorForm : Form
    {
        private int? _noteId = null;
        private bool _isDirty = false;
        private readonly NotesDbContext _context = new NotesDbContext();

        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;

        //Notes list Update Event
        public event EventHandler NoteChanged;

        public NoteEditorForm(int? noteId = null)
        {
            InitializeComponent();
            _noteId = noteId;
            openFileDialog = new OpenFileDialog
            {
                Filter = "Rich Text Files (*.rtf)|*.rtf|Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                Title = "Open Note File"
            };

            saveFileDialog = new SaveFileDialog
            {
                Filter = "Rich Text Files (*.rtf)|*.rtf|Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                Title = "Save Note As"
            };

            // toolbar buttons
            Button[] toolbarButtons = { btnBold, btnItalic, btnUnderline, btnFont, btnColor };
            foreach (var btn in toolbarButtons)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = Color.WhiteSmoke;
                btn.ForeColor = Color.Black;
                //btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }

            // Subscribe to category change
            categorySelector1.CategoryChanged += (s, cat) =>
            {
                Console.WriteLine($"Category changed to: {cat}");
            };

            if (_noteId.HasValue)
                LoadNote();
        }

        private void LoadNote()
        {
            var note = _context.Notes
                .FirstOrDefault(n => n.NoteID == _noteId && n.UserID == UserSession.UserID);

            if (note != null)
            {
                txtTitle.Text = note.Title;
                rtbContent.Rtf = note.Content;
                categorySelector1.SelectedCategory = note.Category;
                if (note.ReminderDate.HasValue)
                    dtpReminder.Value = note.ReminderDate.Value;
            }
        }

        // Save or update note
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedCategory = categorySelector1.SelectedCategory;
            Note note;

            if (_noteId.HasValue)
            {
                note = _context.Notes.FirstOrDefault(n => n.NoteID == _noteId && n.UserID == UserSession.UserID);
                if (note == null) return;

                note.Title = txtTitle.Text;
                note.Content = rtbContent.Rtf;
                note.Category = selectedCategory;
                note.ReminderDate = dtpReminder.Checked ? dtpReminder.Value : null;
            }
            else
            {
                note = new Note
                {
                    Title = txtTitle.Text,
                    Content = rtbContent.Rtf,
                    Category = selectedCategory,
                    CreatedDate = DateTime.Now,
                    ReminderDate = dtpReminder.Checked ? dtpReminder.Value : null,
                    UserID = UserSession.UserID
                };
                _context.Notes.Add(note);
            }

            _context.SaveChanges();
            MessageBox.Show("Note saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Fire Notes list Update Event
            NoteChanged?.Invoke(this, EventArgs.Empty);

            _isDirty = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_noteId.HasValue)
            {
                MessageBox.Show("Note not saved yet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to delete this note?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            var note = _context.Notes.FirstOrDefault(n => n.NoteID == _noteId);
            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
                MessageBox.Show("Note deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Fire Notes list update event
                NoteChanged?.Invoke(this, EventArgs.Empty);

                Close();
            }
        }

        private void btnBold_Click(object sender, EventArgs e) => ToggleStyle(FontStyle.Bold);
        private void btnItalic_Click(object sender, EventArgs e) => ToggleStyle(FontStyle.Italic);
        private void btnUnderline_Click(object sender, EventArgs e) => ToggleStyle(FontStyle.Underline);

        private void ToggleStyle(FontStyle style)
        {
            if (rtbContent.SelectionFont == null) return;
            var currentFont = rtbContent.SelectionFont;
            var newStyle = rtbContent.SelectionFont.Style ^ style;
            rtbContent.SelectionFont = new Font(currentFont, newStyle);
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            using (FontDialog fd = new FontDialog())
            {
                if (fd.ShowDialog() == DialogResult.OK)
                    rtbContent.SelectionFont = fd.Font;
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                if (cd.ShowDialog() == DialogResult.OK)
                    rtbContent.SelectionColor = cd.Color;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_isDirty)
            {
                var res = MessageBox.Show("Do you want to save changes before closing?", "Confirm", MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Yes)
                {
                    btnSave.PerformClick();
                }
                else if (res == DialogResult.Cancel)
                {
                    return;
                }
            }
            //NotesListForm noteForm = new NotesListForm();
            //NoteChanged += (s, args) => noteForm.RefershNotesList();
            Close();
        }

        public void OpenNoteFromFile()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string extension = Path.GetExtension(filePath).ToLower();

                try
                {
                    if (extension == ".rtf")
                        rtbContent.LoadFile(filePath, RichTextBoxStreamType.RichText);
                    else
                        rtbContent.Text = File.ReadAllText(filePath, Encoding.UTF8);

                    _isDirty = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading file:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void SaveNoteToFile()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                string extension = Path.GetExtension(filePath).ToLower();

                try
                {
                    if (extension == ".rtf")
                        rtbContent.SaveFile(filePath, RichTextBoxStreamType.RichText);
                    else
                        File.WriteAllText(filePath, rtbContent.Text, Encoding.UTF8);

                    MessageBox.Show("Note saved successfully!", "File Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _isDirty = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnSaveAs_Click(object sender, EventArgs e)
        {
            SaveNoteToFile();
        }

        // Get current selection font in RichTextBox
        public Font GetCurrentSelectionFont()
        {
            return rtbContent.SelectionFont ?? rtbContent.Font;
        }

        // Apply new font to selection
        public void SetSelectionFont(Font font)
        {
            if (rtbContent.SelectionLength > 0)
                rtbContent.SelectionFont = font;
        }

        // Get current selection color
        public Color GetCurrentSelectionColor()
        {
            return rtbContent.SelectionColor;
        }

        // Apply new color to selection
        public void SetSelectionColor(Color color)
        {
            if (rtbContent.SelectionLength > 0)
                rtbContent.SelectionColor = color;
        }

    }
}
