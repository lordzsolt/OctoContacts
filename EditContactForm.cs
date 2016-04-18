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
    public partial class EditContactForm : Form
    {
        private Contact contact;
        public EditContactForm(Contact contact)
        {
            InitializeComponent();
            this.contact = contact;
        }

        private void EditContactForm_Load(object sender, EventArgs e)
        {
            textBoxContactName.Text = contact.Name;
            textBoxContactNumber.Text = contact.Number;
        }

        private void buttonContactSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var odb = OdbFactory.Open("octo.db"))
                {
                    Contact fromDB = (from cont in odb.AsQueryable<Contact>()
                                     where cont.Name.Equals(contact.Name) && cont.Number.Equals(contact.Number)
                                     select cont).First();

                    fromDB.Name = textBoxContactName.Text;
                    fromDB.Number = textBoxContactNumber.Text;

                    odb.Store(fromDB);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to open database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("Contact updated successfully!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void buttonContactCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
