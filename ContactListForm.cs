using NDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OctoContacts
{
    public partial class ContactListForm : Form
    {
        public ContactListForm()
        {
            InitializeComponent();
        }

        private void ContactListForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (var odb = OdbFactory.Open("octo.db"))
                {
                    List<Contact> fromDB = (from cont in odb.AsQueryable<Contact>()
                                      select cont).ToList();
                    foreach (var contact in fromDB)
                    {
                        var lvi = new ListViewItem(new[] { contact.Name.ToString(), contact.Number });
                        listView_contacts.Items.Add(lvi);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to open database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
