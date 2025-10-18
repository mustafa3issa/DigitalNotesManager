using DigitalNotesManager.Data;
using DigitalNotesManager.Helpers;
using Timer = System.Windows.Forms.Timer;

namespace DigitalNotesManager
{
    public partial class MainForm : Form
    {
        private Timer reminderTimer;
        private HashSet<int> notifiedNotes = new HashSet<int>();

        private void InitializeReminderSystem()
        {
            reminderTimer = new Timer();
            reminderTimer.Interval = 60000; // check every 1 minute
            reminderTimer.Tick += ReminderTimer_Tick;
            reminderTimer.Start();
        }

        private void ReminderTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                using (var db = new NotesDbContext())
                {
                    int userId = UserSession.UserID;

                    var dueNotes = db.Notes
                        .Where(n => n.UserID == userId
                                    && n.ReminderDate != null
                                    && n.ReminderDate <= DateTime.Now
                                    && !notifiedNotes.Contains(n.NoteID))
                        .ToList();


                    foreach (var note in dueNotes)
                    {
                        notifiedNotes.Add(note.NoteID);
                        string plainText = string.Empty;
                        using (RichTextBox rtb = new RichTextBox())
                        {
                            rtb.Rtf = note.Content; // load RTF
                            plainText = rtb.Text;   // extract plain text
                        }
                        MessageBox.Show(
                            $"Reminder for note: {note.Title}\n\n{plainText}",
                            "Reminder",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                // Optional: log or handle silently
                Console.WriteLine($"Reminder check failed: {ex.Message}");
            }
        }

        public MainForm()
        {
            InitializeComponent();
            InitializeReminderSystem();
            this.IsMdiContainer = true;
            this.Text = $"Digital Notes Manager – Welcome {UserSession.Username}";
        }

        // FILE MENU
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoteEditorForm noteForm = new NoteEditorForm();
            noteForm.MdiParent = this;

            // Get the open NotesListForm
            var listForm = this.MdiChildren.OfType<NotesListForm>().FirstOrDefault();
            if (listForm != null)
                noteForm.NoteChanged += (s, args) => listForm.RefershNotesList();

            noteForm.Show();
        }



        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if there is an active NoteEditorForm already open
            if (this.ActiveMdiChild is NoteEditorForm activeEditor)
            {
                activeEditor.OpenNoteFromFile(); // open file inside current note
            }
            else
            {
                // if no note editor open, create a new one and load file into it
                var noteForm = new NoteEditorForm();
                noteForm.MdiParent = this;
                noteForm.Show();
                noteForm.OpenNoteFromFile();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is NoteEditorForm editor)
            {
                editor.Invoke(new Action(() => editor.SaveNoteToFile()));
            }
            else
            {
                MessageBox.Show("No active note to save.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // EDIT MENU
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^x");
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^c");
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^v");
        }

        // VIEW MENU
        private void notesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if NotesListForm is already open
            var existingForm = this.MdiChildren
                .OfType<NotesListForm>()
                .FirstOrDefault();

            if (existingForm != null)
            {
                existingForm.BringToFront();
                existingForm.Focus();
            }
            else
            {
                NotesListForm listForm = new NotesListForm();
                listForm.MdiParent = this;
                listForm.Show();
            }
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        // HELP MENU
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Digital Notes Manager\nCreated by Mustafa Issa", "About");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Show Notes List Form when MainForm loads
            var notesListForm = new NotesListForm();
            notesListForm.MdiParent = this;
            notesListForm.WindowState = FormWindowState.Maximized; // Optional: fill the parent
            notesListForm.Show();
        }

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is NoteEditorForm editor)
            {
                using (FontDialog fontDialog = new FontDialog())
                {
                    fontDialog.Font = editor.GetCurrentSelectionFont(); // optional, current font
                    if (fontDialog.ShowDialog() == DialogResult.OK)
                    {
                        editor.SetSelectionFont(fontDialog.Font);
                    }
                }

                using (ColorDialog colorDialog = new ColorDialog())
                {
                    colorDialog.Color = editor.GetCurrentSelectionColor(); // optional, current color
                    if (colorDialog.ShowDialog() == DialogResult.OK)
                    {
                        editor.SetSelectionColor(colorDialog.Color);
                    }
                }
            }
            else
            {
                MessageBox.Show("No note is currently open. Please open a note first.",
                                "Format Text",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void progressChartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var statsForm = new StatisticsForm();
            statsForm.MdiParent = this;
            statsForm.Show();
        }
    }
}
