namespace OctoContacts
{
    partial class NewContactForm
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
            this.labelContactName = new System.Windows.Forms.Label();
            this.labelContactNumber = new System.Windows.Forms.Label();
            this.textBoxContactName = new System.Windows.Forms.TextBox();
            this.textBoxContactNumber = new System.Windows.Forms.TextBox();
            this.buttonContactSave = new System.Windows.Forms.Button();
            this.buttonContactCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelContactName
            // 
            this.labelContactName.AutoSize = true;
            this.labelContactName.Location = new System.Drawing.Point(12, 42);
            this.labelContactName.Name = "labelContactName";
            this.labelContactName.Size = new System.Drawing.Size(75, 13);
            this.labelContactName.TabIndex = 0;
            this.labelContactName.Text = "Contact Name";
            // 
            // labelContactNumber
            // 
            this.labelContactNumber.AutoSize = true;
            this.labelContactNumber.Location = new System.Drawing.Point(12, 79);
            this.labelContactNumber.Name = "labelContactNumber";
            this.labelContactNumber.Size = new System.Drawing.Size(84, 13);
            this.labelContactNumber.TabIndex = 0;
            this.labelContactNumber.Text = "Contact Number";
            // 
            // textBoxContactName
            // 
            this.textBoxContactName.Location = new System.Drawing.Point(120, 42);
            this.textBoxContactName.MaxLength = 30;
            this.textBoxContactName.Name = "textBoxContactName";
            this.textBoxContactName.Size = new System.Drawing.Size(152, 20);
            this.textBoxContactName.TabIndex = 1;
            // 
            // textBoxContactNumber
            // 
            this.textBoxContactNumber.Location = new System.Drawing.Point(120, 72);
            this.textBoxContactNumber.MaxLength = 15;
            this.textBoxContactNumber.Name = "textBoxContactNumber";
            this.textBoxContactNumber.Size = new System.Drawing.Size(152, 20);
            this.textBoxContactNumber.TabIndex = 2;
            // 
            // buttonContactSave
            // 
            this.buttonContactSave.Location = new System.Drawing.Point(12, 226);
            this.buttonContactSave.Name = "buttonContactSave";
            this.buttonContactSave.Size = new System.Drawing.Size(75, 23);
            this.buttonContactSave.TabIndex = 3;
            this.buttonContactSave.Text = "Save";
            this.buttonContactSave.UseVisualStyleBackColor = true;
            this.buttonContactSave.Click += new System.EventHandler(this.buttonContactSave_Click);
            // 
            // buttonContactCancel
            // 
            this.buttonContactCancel.Location = new System.Drawing.Point(197, 226);
            this.buttonContactCancel.Name = "buttonContactCancel";
            this.buttonContactCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonContactCancel.TabIndex = 4;
            this.buttonContactCancel.Text = "Cancel";
            this.buttonContactCancel.UseVisualStyleBackColor = true;
            this.buttonContactCancel.Click += new System.EventHandler(this.buttonContactCancel_Click);
            // 
            // NewContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonContactCancel);
            this.Controls.Add(this.buttonContactSave);
            this.Controls.Add(this.textBoxContactNumber);
            this.Controls.Add(this.textBoxContactName);
            this.Controls.Add(this.labelContactNumber);
            this.Controls.Add(this.labelContactName);
            this.Name = "NewContactForm";
            this.Text = "NewContactForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelContactName;
        private System.Windows.Forms.Label labelContactNumber;
        private System.Windows.Forms.TextBox textBoxContactName;
        private System.Windows.Forms.TextBox textBoxContactNumber;
        private System.Windows.Forms.Button buttonContactSave;
        private System.Windows.Forms.Button buttonContactCancel;
    }
}