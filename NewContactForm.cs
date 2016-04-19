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
        ContactListForm parent;
        public NewContactForm(ContactListForm parent)
        {
            InitializeComponent();
            this.parent = parent;
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
                    var nothing = (from cont in odb.AsQueryable<Contact>()
                                   where cont.Name.Equals(this.textBoxContactName.Text) ||
                                    cont.Name.Equals(this.textBoxContactNumber.Text)
                                   select cont).ToList();
                    if (nothing.Count > 0)
                    {
                        MessageBox.Show("This contact already exists in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    odb.Store(new Contact(this.textBoxContactName.Text, this.textBoxContactNumber.Text));
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
