using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NDatabase;

namespace OctoContacts
{
    public partial class NewContactForm : Form
    {
        public NewContactForm()
        {
            InitializeComponent();
        }

        private void buttonContactCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonContactSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var odb = OdbFactory.Open("octo.db"))
                {
                    odb.Store(new Contact(this.textBoxContactName.Text, this.textBoxContactNumber.Text));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to open database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("Contact saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
