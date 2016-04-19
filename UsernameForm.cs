using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OctoContacts.DataObjects;

namespace OctoContacts
{
    class UsernameForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Label usernameLabel;

        public UsernameForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(12, 25);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(58, 13);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username:";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(76, 22);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(196, 20);
            this.usernameTextBox.TabIndex = 1;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(109, 68);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 2;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // UsernameForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 103);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.usernameLabel);
            this.Name = "UsernameForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            var username = usernameTextBox.Text;
            if (String.IsNullOrEmpty(username))
            {
                usernameTextBox.Focus();
                return;
            }

            if (!User.UsernameExists(username))
            {
                MessageBox.Show("Invalid username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var user = User.UserWithUsername(username);
            new SecurityQuestionForm(user).ShowDialog();
            Close();
        }
    }
}
