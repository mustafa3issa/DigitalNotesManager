namespace DigitalNotesManager
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            panelRegister = new Panel();
            btnCancel = new Button();
            btnRegister = new Button();
            lblConfirm = new Label();
            lblPassword = new Label();
            lblUsername = new Label();
            txtConfirm = new TextBox();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            lblTitle = new Label();
            panelRegister.SuspendLayout();
            SuspendLayout();
            // 
            // panelRegister
            // 
            panelRegister.Anchor = AnchorStyles.None;
            panelRegister.BackColor = Color.WhiteSmoke;
            panelRegister.BorderStyle = BorderStyle.FixedSingle;
            panelRegister.Controls.Add(btnCancel);
            panelRegister.Controls.Add(btnRegister);
            panelRegister.Controls.Add(lblConfirm);
            panelRegister.Controls.Add(lblPassword);
            panelRegister.Controls.Add(lblUsername);
            panelRegister.Controls.Add(txtConfirm);
            panelRegister.Controls.Add(txtPassword);
            panelRegister.Controls.Add(txtUsername);
            panelRegister.Controls.Add(lblTitle);
            panelRegister.Location = new Point(-3, -1);
            panelRegister.Margin = new Padding(3, 4, 3, 4);
            panelRegister.Name = "panelRegister";
            panelRegister.Size = new Size(434, 506);
            panelRegister.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.ForeColor = Color.DodgerBlue;
            btnCancel.Location = new Point(69, 445);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(297, 44);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.DodgerBlue;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(69, 387);
            btnRegister.Margin = new Padding(3, 4, 3, 4);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(297, 51);
            btnRegister.TabIndex = 4;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblConfirm
            // 
            lblConfirm.AutoSize = true;
            lblConfirm.Font = new Font("Segoe UI", 10F);
            lblConfirm.ForeColor = Color.Gray;
            lblConfirm.Location = new Point(69, 280);
            lblConfirm.Name = "lblConfirm";
            lblConfirm.Size = new Size(146, 23);
            lblConfirm.TabIndex = 8;
            lblConfirm.Text = "Confirm Password";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F);
            lblPassword.ForeColor = Color.Gray;
            lblPassword.Location = new Point(69, 189);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(80, 23);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Password";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F);
            lblUsername.ForeColor = Color.Gray;
            lblUsername.Location = new Point(69, 99);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(87, 23);
            lblUsername.TabIndex = 6;
            lblUsername.Text = "Username";
            // 
            // txtConfirm
            // 
            txtConfirm.BorderStyle = BorderStyle.FixedSingle;
            txtConfirm.Font = new Font("Segoe UI", 11F);
            txtConfirm.Location = new Point(69, 309);
            txtConfirm.Margin = new Padding(3, 4, 3, 4);
            txtConfirm.Name = "txtConfirm";
            txtConfirm.PlaceholderText = "Re-enter password";
            txtConfirm.Size = new Size(297, 32);
            txtConfirm.TabIndex = 3;
            txtConfirm.UseSystemPasswordChar = true;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(69, 219);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Enter password";
            txtPassword.Size = new Size(297, 32);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.Location = new Point(69, 128);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Choose a username";
            txtUsername.Size = new Size(297, 32);
            txtUsername.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DodgerBlue;
            lblTitle.Location = new Point(137, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(201, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Register Now";
            // 
            // RegisterForm
            // 
            AcceptButton = btnRegister;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(431, 508);
            Controls.Add(panelRegister);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Digital Notes Manager - Register";
            panelRegister.ResumeLayout(false);
            panelRegister.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRegister;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblConfirm;
    }
}
