using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CryptSharp;
using OctoContacts.DataObjects;

namespace OctoContacts
{
    class NewPasswordForm : System.Windows.Forms.Form
    {
        private User user;

        private System.Windows.Forms.TextBox confirmTextBox;
        private System.Windows.Forms.Label confirmLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label passwordLabel;

        public NewPasswordForm(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.confirmTextBox = new System.Windows.Forms.TextBox();
            this.confirmLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // confirmTextBox
            // 
            this.confirmTextBox.Location = new System.Drawing.Point(78, 38);
            this.confirmTextBox.Name = "confirmTextBox";
            this.confirmTextBox.PasswordChar = '*';
            this.confirmTextBox.Size = new System.Drawing.Size(194, 20);
            this.confirmTextBox.TabIndex = 15;
            // 
            // confirmLabel
            // 
            this.confirmLabel.AutoSize = true;
            this.confirmLabel.Location = new System.Drawing.Point(16, 41);
            this.confirmLabel.Name = "confirmLabel";
            this.confirmLabel.Size = new System.Drawing.Size(45, 13);
            this.confirmLabel.TabIndex = 14;
            this.confirmLabel.Text = "Confirm:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(78, 12);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(194, 20);
            this.passwordTextBox.TabIndex = 13;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(16, 15);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 12;
            this.passwordLabel.Text = "Password:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(107, 78);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 16;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // NewPasswordForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 113);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.confirmTextBox);
            this.Controls.Add(this.confirmLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Name = "NewPasswordForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var password = passwordTextBox.Text;
            var confirm = confirmTextBox.Text;

            if (String.IsNullOrEmpty(password))
            {
                passwordTextBox.Focus();
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTextBox.ResetText();
                confirmTextBox.ResetText();
                return;
            }

            this.user.Delete();
            this.user.Password = Crypter.Blowfish.Crypt(password);
            this.user.Save();

            Close();
        }
    }
}
