using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DigitalNotesManager
{
    partial class NoteEditorForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtTitle;
        private RichTextBox rtbContent;
        private DateTimePicker dtpReminder;
        private Button btnSave;
        private Button btnDelete;
        private Button btnClose;
        private Button btnBold;
        private Button btnItalic;
        private Button btnUnderline;
        private Button btnFont;
        private Button btnColor;
        private Label lblTitle;
        private Label lblCategory;
        private Label lblReminder;
        private Controls.CategorySelector categorySelector1;
        private Button BtnSaveAs;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtTitle = new TextBox();
            rtbContent = new RichTextBox();
            dtpReminder = new DateTimePicker();
            btnSave = new Button();
            btnDelete = new Button();
            btnClose = new Button();
            btnBold = new Button();
            btnItalic = new Button();
            btnUnderline = new Button();
            btnFont = new Button();
            btnColor = new Button();
            lblTitle = new Label();
            lblCategory = new Label();
            lblReminder = new Label();
            categorySelector1 = new DigitalNotesManager.Controls.CategorySelector();
            BtnSaveAs = new Button();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTitle.Location = new Point(112, 17);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(623, 30);
            txtTitle.TabIndex = 1;
            // 
            // rtbContent
            // 
            rtbContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbContent.BackColor = Color.White;
            rtbContent.BorderStyle = BorderStyle.FixedSingle;
            rtbContent.Location = new Point(20, 140);
            rtbContent.Name = "rtbContent";
            rtbContent.Size = new Size(715, 265);
            rtbContent.TabIndex = 11;
            rtbContent.Text = "";
            // 
            // dtpReminder
            // 
            dtpReminder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpReminder.CustomFormat = "dd/MM/yyyy hh:mm tt";
            dtpReminder.Format = DateTimePickerFormat.Custom;
            dtpReminder.Location = new Point(472, 54);
            dtpReminder.Name = "dtpReminder";
            dtpReminder.ShowCheckBox = true;
            dtpReminder.Size = new Size(263, 30);
            dtpReminder.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.LightSkyBlue;
            btnSave.Location = new Point(282, 413);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDelete.BackColor = Color.LightCoral;
            btnDelete.Location = new Point(503, 413);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 35);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(613, 413);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 35);
            btnClose.TabIndex = 15;
            btnClose.Text = "Close";
            btnClose.Click += btnClose_Click;
            // 
            // btnBold
            // 
            btnBold.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnBold.Location = new Point(20, 100);
            btnBold.Name = "btnBold";
            btnBold.Size = new Size(35, 30);
            btnBold.TabIndex = 6;
            btnBold.Text = "B";
            btnBold.Click += btnBold_Click;
            // 
            // btnItalic
            // 
            btnItalic.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
            btnItalic.Location = new Point(60, 100);
            btnItalic.Name = "btnItalic";
            btnItalic.Size = new Size(35, 30);
            btnItalic.TabIndex = 7;
            btnItalic.Text = "I";
            btnItalic.Click += btnItalic_Click;
            // 
            // btnUnderline
            // 
            btnUnderline.Font = new Font("Segoe UI", 10.2F, FontStyle.Underline);
            btnUnderline.Location = new Point(100, 100);
            btnUnderline.Name = "btnUnderline";
            btnUnderline.Size = new Size(35, 30);
            btnUnderline.TabIndex = 8;
            btnUnderline.Text = "U";
            btnUnderline.Click += btnUnderline_Click;
            // 
            // btnFont
            // 
            btnFont.Location = new Point(150, 100);
            btnFont.Name = "btnFont";
            btnFont.Size = new Size(60, 30);
            btnFont.TabIndex = 9;
            btnFont.Text = "Font";
            btnFont.Click += btnFont_Click;
            // 
            // btnColor
            // 
            btnColor.Location = new Point(220, 100);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(60, 30);
            btnColor.TabIndex = 10;
            btnColor.Text = "Color";
            btnColor.Click += btnColor_Click;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(54, 23);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Title:";
            // 
            // lblCategory
            // 
            lblCategory.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblCategory.Location = new Point(20, 60);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(86, 29);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Category:";
            // 
            // lblReminder
            // 
            lblReminder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblReminder.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblReminder.Location = new Point(375, 59);
            lblReminder.Name = "lblReminder";
            lblReminder.Size = new Size(91, 23);
            lblReminder.TabIndex = 4;
            lblReminder.Text = "Reminder:";
            // 
            // categorySelector1
            // 
            categorySelector1.BackColor = Color.Transparent;
            categorySelector1.Location = new Point(110, 54);
            categorySelector1.Name = "categorySelector1";
            categorySelector1.SelectedCategory = "";
            categorySelector1.Size = new Size(244, 40);
            categorySelector1.TabIndex = 3;
            // 
            // BtnSaveAs
            // 
            BtnSaveAs.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnSaveAs.BackColor = Color.DeepSkyBlue;
            BtnSaveAs.Location = new Point(392, 413);
            BtnSaveAs.Name = "BtnSaveAs";
            BtnSaveAs.Size = new Size(100, 35);
            BtnSaveAs.TabIndex = 13;
            BtnSaveAs.Text = "Save as";
            BtnSaveAs.UseVisualStyleBackColor = false;
            BtnSaveAs.Click += BtnSaveAs_Click;
            // 
            // NoteEditorForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(755, 454);
            Controls.Add(lblTitle);
            Controls.Add(txtTitle);
            Controls.Add(lblCategory);
            Controls.Add(categorySelector1);
            Controls.Add(lblReminder);
            Controls.Add(dtpReminder);
            Controls.Add(btnBold);
            Controls.Add(btnItalic);
            Controls.Add(btnUnderline);
            Controls.Add(btnFont);
            Controls.Add(btnColor);
            Controls.Add(rtbContent);
            Controls.Add(btnSave);
            Controls.Add(BtnSaveAs);
            Controls.Add(btnDelete);
            Controls.Add(btnClose);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(750, 500);
            Name = "NoteEditorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Note Editor";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
