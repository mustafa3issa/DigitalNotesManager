using System;
using System.Linq;
using System.Windows.Forms;
using DigitalNotesManager.Data;
using DigitalNotesManager.Helpers;
using DigitalNotesManager.Models;

namespace DigitalNotesManager
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            using (var db = new NotesDbContext())
            {
                var user = db.Users
                    .FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    UserSession.SetUser(user.UserID, user.Username);

                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }
    }
}
