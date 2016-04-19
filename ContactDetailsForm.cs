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
    public partial class ContactDetailsForm : Form
    {
        private Contact contact;
        public ContactDetailsForm(string contactName)
        {
            InitializeComponent();
            try
            {
                using (var odb = OdbFactory.Open("octo.db"))
                {
                    contact = (from cont in odb.AsQueryable<Contact>()
                               where cont.Name.Equals(contactName)
                               select cont).First();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to open database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ContactDetailsForm_Load(object sender, EventArgs e)
        {
            labelShowedContactName.Text = contact.Name;
            labelShowedContactNumber.Text = contact.Number;
        }

        private void buttonContactOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
