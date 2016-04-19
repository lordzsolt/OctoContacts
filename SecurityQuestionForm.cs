using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OctoContacts.DataObjects;

namespace OctoContacts
{
    class SecurityQuestionForm : System.Windows.Forms.Form
    {
        private User user;
        private System.Windows.Forms.TextBox answerTextBox;
        private System.Windows.Forms.Label answerLabel;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Label questionLabel;

        public SecurityQuestionForm(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.questionLabel = new System.Windows.Forms.Label();
            this.answerTextBox = new System.Windows.Forms.TextBox();
            this.answerLabel = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // questionLabel
            // 
            this.questionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.questionLabel.AutoSize = true;
            this.questionLabel.Location = new System.Drawing.Point(12, 9);
            this.questionLabel.MaximumSize = new System.Drawing.Size(276, 0);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(30, 13);
            this.questionLabel.TabIndex = 0;
            this.questionLabel.Text = this.user.SecurityQuestion + "?";
            // 
            // answerTextBox
            // 
            this.answerTextBox.Location = new System.Drawing.Point(60, 36);
            this.answerTextBox.Name = "answerTextBox";
            this.answerTextBox.Size = new System.Drawing.Size(212, 20);
            this.answerTextBox.TabIndex = 1;
            // 
            // answerLabel
            // 
            this.answerLabel.AutoSize = true;
            this.answerLabel.Location = new System.Drawing.Point(9, 39);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(45, 13);
            this.answerLabel.TabIndex = 2;
            this.answerLabel.Text = "Answer:";
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(107, 83);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 3;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // SecurityQuestionForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 118);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.answerLabel);
            this.Controls.Add(this.answerTextBox);
            this.Controls.Add(this.questionLabel);
            this.Name = "SecurityQuestionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            var answer = this.answerTextBox.Text;
            if (String.IsNullOrEmpty(answer))
            {
                answerTextBox.Focus();
                return;
            }

            if (user.SecurityAnswer != answer)
            {
                MessageBox.Show("Invalid answer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            new NewPasswordForm(user).Show();
            Close();
        }
    }
}
