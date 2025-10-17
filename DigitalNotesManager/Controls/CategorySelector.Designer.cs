namespace DigitalNotesManager.Controls
{
    partial class CategorySelector
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbCategories;
        private Button btnAddCategory;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cmbCategories = new ComboBox();
            btnAddCategory = new Button();
            SuspendLayout();
            // 
            // cmbCategories
            // 
            cmbCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategories.Font = new Font("Segoe UI", 10F);
            cmbCategories.FormattingEnabled = true;
            cmbCategories.Location = new Point(3, 3);
            cmbCategories.Name = "cmbCategories";
            cmbCategories.Size = new Size(200, 31);
            cmbCategories.TabIndex = 0;
            cmbCategories.SelectedIndexChanged += cmbCategories_SelectedIndexChanged;
            // 
            // btnAddCategory
            // 
            btnAddCategory.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddCategory.Location = new Point(209, 3);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(30, 29);
            btnAddCategory.TabIndex = 1;
            btnAddCategory.Text = "+";
            btnAddCategory.UseVisualStyleBackColor = true;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // CategorySelector
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Transparent;
            Controls.Add(btnAddCategory);
            Controls.Add(cmbCategories);
            Name = "CategorySelector";
            Size = new Size(245, 32);
            ResumeLayout(false);
        }
    }
}
