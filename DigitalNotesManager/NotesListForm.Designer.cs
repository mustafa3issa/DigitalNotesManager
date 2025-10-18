using System;
using System.Drawing;
using System.Windows.Forms;

namespace DigitalNotesManager
{
    partial class NotesListForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvNotes;
        private ComboBox cmbCategoryFilter;
        private TextBox txtSearch;
        private Label lblCategory;
        private Label lblSearch;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Label lblFrom;
        private Label lblTo;
        private Button btnNewNote;
        private Button btnDeleteNote;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotesListForm));
            dgvNotes = new DataGridView();
            cmbCategoryFilter = new ComboBox();
            txtSearch = new TextBox();
            lblCategory = new Label();
            lblSearch = new Label();
            lblFrom = new Label();
            dtpFrom = new DateTimePicker();
            lblTo = new Label();
            dtpTo = new DateTimePicker();
            btnNewNote = new Button();
            btnDeleteNote = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvNotes).BeginInit();
            SuspendLayout();
            // 
            // dgvNotes
            // 
            dgvNotes.AllowUserToAddRows = false;
            dgvNotes.AllowUserToDeleteRows = false;
            dgvNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNotes.BackgroundColor = Color.White;
            dgvNotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNotes.Location = new Point(20, 110);
            dgvNotes.Name = "dgvNotes";
            dgvNotes.ReadOnly = true;
            dgvNotes.RowHeadersVisible = false;
            dgvNotes.RowHeadersWidth = 51;
            dgvNotes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNotes.Size = new Size(840, 380);
            dgvNotes.TabIndex = 0;
            dgvNotes.CellDoubleClick += dgvNotes_CellDoubleClick;
            // 
            // cmbCategoryFilter
            // 
            cmbCategoryFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoryFilter.Font = new Font("Segoe UI", 10F);
            cmbCategoryFilter.Location = new Point(115, 22);
            cmbCategoryFilter.Name = "cmbCategoryFilter";
            cmbCategoryFilter.Size = new Size(200, 31);
            cmbCategoryFilter.TabIndex = 2;
            cmbCategoryFilter.SelectedIndexChanged += cmbCategoryFilter_SelectedIndexChanged;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(412, 22);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search notes...";
            txtSearch.Size = new Size(226, 30);
            txtSearch.TabIndex = 4;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblCategory
            // 
            lblCategory.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCategory.Location = new Point(20, 25);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(90, 25);
            lblCategory.TabIndex = 1;
            lblCategory.Text = "Category:";
            // 
            // lblSearch
            // 
            lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSearch.Location = new Point(336, 25);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(68, 25);
            lblSearch.TabIndex = 3;
            lblSearch.Text = "Search:";
            // 
            // lblFrom
            // 
            lblFrom.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFrom.Location = new Point(20, 65);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(60, 25);
            lblFrom.TabIndex = 5;
            lblFrom.Text = "From:";
            // 
            // dtpFrom
            // 
            dtpFrom.Font = new Font("Segoe UI", 10F);
            dtpFrom.Location = new Point(115, 62);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.ShowCheckBox = true;
            dtpFrom.Size = new Size(200, 30);
            dtpFrom.TabIndex = 6;
            // 
            // lblTo
            // 
            lblTo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTo.Location = new Point(336, 65);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(35, 25);
            lblTo.TabIndex = 7;
            lblTo.Text = "To:";
            // 
            // dtpTo
            // 
            dtpTo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpTo.Font = new Font("Segoe UI", 10F);
            dtpTo.Location = new Point(412, 62);
            dtpTo.Name = "dtpTo";
            dtpTo.ShowCheckBox = true;
            dtpTo.Size = new Size(226, 30);
            dtpTo.TabIndex = 8;
            // 
            // btnNewNote
            // 
            btnNewNote.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNewNote.BackColor = Color.DodgerBlue;
            btnNewNote.FlatStyle = FlatStyle.Flat;
            btnNewNote.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewNote.ForeColor = SystemColors.HighlightText;
            btnNewNote.Location = new Point(662, 43);
            btnNewNote.Name = "btnNewNote";
            btnNewNote.Size = new Size(100, 30);
            btnNewNote.TabIndex = 9;
            btnNewNote.Text = "New Note";
            btnNewNote.UseVisualStyleBackColor = false;
            btnNewNote.Click += BtnNewNote_Click;
            // 
            // btnDeleteNote
            // 
            btnDeleteNote.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteNote.BackColor = Color.Crimson;
            btnDeleteNote.FlatStyle = FlatStyle.Flat;
            btnDeleteNote.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteNote.ForeColor = Color.White;
            btnDeleteNote.Location = new Point(768, 43);
            btnDeleteNote.Name = "btnDeleteNote";
            btnDeleteNote.Size = new Size(100, 30);
            btnDeleteNote.TabIndex = 10;
            btnDeleteNote.Text = "Delete";
            btnDeleteNote.UseVisualStyleBackColor = false;
            btnDeleteNote.Click += BtnDeleteNote_Click;
            // 
            // NotesListForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(880, 520);
            Controls.Add(dgvNotes);
            Controls.Add(lblCategory);
            Controls.Add(cmbCategoryFilter);
            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblFrom);
            Controls.Add(dtpFrom);
            Controls.Add(lblTo);
            Controls.Add(dtpTo);
            Controls.Add(btnNewNote);
            Controls.Add(btnDeleteNote);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "NotesListForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Notes List";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgvNotes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
