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
        ContactListForm parent;
        public EditContactForm(ContactListForm parent, string contactName)
        {
            InitializeComponent();

            try
            {
                using (var odb = OdbFactory.Open("octo.db"))
                {
                    contact = (from cont in odb.AsQueryable<Contact>()
                                      where cont.Name.Equals(contactName)
                                      select cont).First();
                    odb.Delete(contact);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to open database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.parent = parent;
        }

        private void EditContactForm_Load(object sender, EventArgs e)
        {
            textBoxContactName.Text = contact.Name;
            textBoxContactNumber.Text = contact.Number;
        }

        private void buttonContactSave_Click(object sender, EventArgs e)
        {
            StoreInDatabase(true);
        }

        private void buttonContactCancel_Click(object sender, EventArgs e)
        {
            StoreInDatabase(false);
        }

        private void StoreInDatabase(bool isSave)
        {
            try
            {
                using (var odb = OdbFactory.Open("octo.db"))
                {
                    if (isSave)
                    {
                        contact.Name = textBoxContactName.Text;
                        contact.Number = textBoxContactNumber.Text;
                        var nothing = (from cont in odb.AsQueryable<Contact>()
                                       where cont.Name.Equals(this.textBoxContactName.Text) ||
                                        cont.Name.Equals(this.textBoxContactNumber.Text)
                                       select cont).ToList();
                        if (nothing.Count > 0)
                        {
                            MessageBox.Show("This contact already exists in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    odb.Store(contact);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to open database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.parent.Refresh();
            this.Close();
        }
    }
}
