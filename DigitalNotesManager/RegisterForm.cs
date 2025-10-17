using System;
using System.Linq;
using System.Windows.Forms;
using DigitalNotesManager.Data;
using DigitalNotesManager.Models;

namespace DigitalNotesManager
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirm = txtConfirm.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            using (var db = new NotesDbContext())
            {
                if (db.Users.Any(u => u.Username == username))
                {
                    MessageBox.Show("Username already exists.");
                    return;
                }

                db.Users.Add(new User
                {
                    Username = username,
                    Password = password
                });
                db.SaveChanges();

                MessageBox.Show("Registration successful! You can now log in.");
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
