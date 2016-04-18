using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CryptSharp;
using OctoContacts.DataObjects;

namespace OctoContacts
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            TextBox[] textBoxes = {usernameTextBox, passwordTextBox, confirmTextBox, questionTextBox, answerTextBox};
            
            foreach (var textBox in textBoxes)
            {
                if (String.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Focus();
                    return;
                }
            }
            var username = usernameTextBox.Text;
            if (User.UsernameExists(username))
            {
                MessageBox.Show("Username already taken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var password = passwordTextBox.Text;
            var confirm = confirmTextBox.Text;

            if (password != confirm)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTextBox.ResetText();
                confirmTextBox.ResetText();
                return;
            }

            var securityQ = questionTextBox.Text;
            var securityA = answerTextBox.Text;
            User user = new User(username, Crypter.Blowfish.Crypt(password), securityQ, securityA);
            user.Save();

            Close();
        }
    }
}
