namespace OctoContacts
{
    partial class ContactDetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonContactOK = new System.Windows.Forms.Button();
            this.labelContactNumber = new System.Windows.Forms.Label();
            this.labelContactName = new System.Windows.Forms.Label();
            this.labelShowedContactName = new System.Windows.Forms.Label();
            this.labelShowedContactNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonContactOK
            // 
            this.buttonContactOK.Location = new System.Drawing.Point(98, 226);
            this.buttonContactOK.Name = "buttonContactOK";
            this.buttonContactOK.Size = new System.Drawing.Size(75, 23);
            this.buttonContactOK.TabIndex = 14;
            this.buttonContactOK.Text = "OK";
            this.buttonContactOK.UseVisualStyleBackColor = true;
            this.buttonContactOK.Click += new System.EventHandler(this.buttonContactOK_Click);
            // 
            // labelContactNumber
            // 
            this.labelContactNumber.AutoSize = true;
            this.labelContactNumber.Location = new System.Drawing.Point(12, 64);
            this.labelContactNumber.Name = "labelContactNumber";
            this.labelContactNumber.Size = new System.Drawing.Size(84, 13);
            this.labelContactNumber.TabIndex = 11;
            this.labelContactNumber.Text = "Contact Number";
            // 
            // labelContactName
            // 
            this.labelContactName.AutoSize = true;
            this.labelContactName.Location = new System.Drawing.Point(12, 27);
            this.labelContactName.Name = "labelContactName";
            this.labelContactName.Size = new System.Drawing.Size(75, 13);
            this.labelContactName.TabIndex = 12;
            this.labelContactName.Text = "Contact Name";
            // 
            // labelShowedContactName
            // 
            this.labelShowedContactName.AutoSize = true;
            this.labelShowedContactName.Location = new System.Drawing.Point(138, 27);
            this.labelShowedContactName.Name = "labelShowedContactName";
            this.labelShowedContactName.Size = new System.Drawing.Size(0, 13);
            this.labelShowedContactName.TabIndex = 12;
            // 
            // labelShowedContactNumber
            // 
            this.labelShowedContactNumber.AutoSize = true;
            this.labelShowedContactNumber.Location = new System.Drawing.Point(138, 64);
            this.labelShowedContactNumber.Name = "labelShowedContactNumber";
            this.labelShowedContactNumber.Size = new System.Drawing.Size(0, 13);
            this.labelShowedContactNumber.TabIndex = 11;
            // 
            // ContactDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonContactOK);
            this.Controls.Add(this.labelShowedContactNumber);
            this.Controls.Add(this.labelContactNumber);
            this.Controls.Add(this.labelShowedContactName);
            this.Controls.Add(this.labelContactName);
            this.Name = "ContactDetailsForm";
            this.Text = "ContactDetailsForm";
            this.Load += new System.EventHandler(this.ContactDetailsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonContactOK;
        private System.Windows.Forms.Label labelContactNumber;
        private System.Windows.Forms.Label labelContactName;
        private System.Windows.Forms.Label labelShowedContactName;
        private System.Windows.Forms.Label labelShowedContactNumber;
    }
}