using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OctoContacts.DataObjects;

namespace OctoContacts
{
    class SecurityQuestionForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label label1;

        public SecurityQuestionForm(User user)
        {
            
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // SecurityQuestionForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.Name = "SecurityQuestionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
