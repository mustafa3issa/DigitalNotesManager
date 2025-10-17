using DigitalNotesManager.Data;
using DigitalNotesManager.Helpers;


namespace DigitalNotesManager
{
    public partial class NotesListForm : Form
    {
        private readonly NotesDbContext _context = new NotesDbContext();


        public NotesListForm()
        {
            InitializeComponent();
            LoadCategories();
            LoadNotes();
            dtpFrom.ValueChanged += (s, e) => LoadNotes();
            dtpTo.ValueChanged += (s, e) => LoadNotes();
        }

        public void RefershNotesList()
        {
            LoadCategories();
            LoadNotes();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadNotes();
        }

        public void LoadCategories()
        {
            var categories = _context.Notes
                .Where(n => n.UserID == UserSession.UserID && !string.IsNullOrEmpty(n.Category))
                .Select(n => n.Category)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            cmbCategoryFilter.Items.Clear();
            cmbCategoryFilter.Items.Add("All");
            cmbCategoryFilter.Items.AddRange(categories.ToArray());
            cmbCategoryFilter.SelectedIndex = 0;
        }

        public void LoadNotes()
        {
            // Recreate context each time to avoid caching old data
            using (var freshContext = new NotesDbContext())
            {
                string selectedCategory = cmbCategoryFilter.SelectedItem?.ToString() ?? "All";
                string searchText = txtSearch.Text.ToLower();

                DateTime? fromDate = dtpFrom.Checked ? dtpFrom.Value.Date : (DateTime?)null;
                DateTime? toDate = dtpTo.Checked ? dtpTo.Value.Date : (DateTime?)null;

                var query = freshContext.Notes
                    .Where(n => n.UserID == UserSession.UserID);

                if (selectedCategory != "All")
                    query = query.Where(n => n.Category == selectedCategory);

                if (!string.IsNullOrWhiteSpace(searchText))
                    query = query.Where(n =>
                        n.Title.ToLower().Contains(searchText) ||
                        n.Content.ToLower().Contains(searchText));

                if (fromDate.HasValue)
                    query = query.Where(n => n.CreatedDate.Date >= fromDate.Value);

                if (toDate.HasValue)
                    query = query.Where(n => n.CreatedDate.Date <= toDate.Value);

                var notes = query
                    .OrderByDescending(n => n.CreatedDate)
                    .ToList();

                dgvNotes.DataSource = null;
                dgvNotes.DataSource = notes;

                dgvNotes.Columns["UserID"].Visible = false;
                dgvNotes.Columns["User"].Visible = false;
                dgvNotes.Columns["NoteID"].Visible = false;
                dgvNotes.Columns["Content"].Visible = false;
                dgvNotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }


        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadNotes();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadNotes();
        }

        public void dgvNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int noteId = Convert.ToInt32(dgvNotes.Rows[e.RowIndex].Cells["NoteID"].Value);

                var editor = new NoteEditorForm(noteId);
                editor.MdiParent = this.MdiParent;

                // instead of creating a new NotesListForm
                editor.NoteChanged += (s, args) => RefershNotesList();

                editor.Show();

            }
        }

        private void BtnNewNote_Click(object sender, EventArgs e)
        {
            var editor = new NoteEditorForm();
            editor.MdiParent = this.MdiParent;

            // Refresh the list after saving new note
            editor.NoteChanged += (s, args) => RefershNotesList();

            editor.Show();
        }

        private void BtnDeleteNote_Click(object sender, EventArgs e)
        {
            if (dgvNotes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select one or more notes to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete {dgvNotes.SelectedRows.Count} selected note(s)?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            using (var context = new NotesDbContext())
            {
                foreach (DataGridViewRow row in dgvNotes.SelectedRows)
                {
                    int noteId = Convert.ToInt32(row.Cells["NoteID"].Value);

                    var note = context.Notes.FirstOrDefault(n => n.NoteID == noteId && n.UserID == UserSession.UserID);
                    if (note != null)
                        context.Notes.Remove(note);
                }

                context.SaveChanges();
            }

            RefershNotesList();
        }


    }
}
