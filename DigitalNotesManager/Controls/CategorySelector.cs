using System;
using System.Linq;
using System.Windows.Forms;
using DigitalNotesManager.Data;

namespace DigitalNotesManager.Controls
{
    public partial class CategorySelector : UserControl
    {
        public event EventHandler<string> CategoryChanged;

        private readonly NotesDbContext _context = new NotesDbContext();

        public CategorySelector()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void LoadCategories()
        {
            var categories = _context.Notes
                .Select(n => n.Category)
                .Where(c => !string.IsNullOrEmpty(c))
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            cmbCategories.Items.Clear();
            cmbCategories.Items.AddRange(categories.ToArray());
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoryChanged?.Invoke(this, cmbCategories.SelectedItem?.ToString());
        }

        public string SelectedCategory
        {
            get => cmbCategories.Text;
            set => cmbCategories.Text = value;
        }

        public void RefreshCategories()
        {
            LoadCategories();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string newCategory = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter new category name:",
                "Add Category");

            if (!string.IsNullOrWhiteSpace(newCategory))
            {
                if (!cmbCategories.Items.Contains(newCategory))
                {
                    cmbCategories.Items.Add(newCategory);
                    cmbCategories.SelectedItem = newCategory;
                    CategoryChanged?.Invoke(this, newCategory);
                }
            }
        }
    }
}
