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
    public partial class ContactDetailsForm : Form
    {
        private Contact contact;
        public ContactDetailsForm(Contact contact)
        {
            InitializeComponent();
            this.contact = contact;
        }

        private void ContactDetailsForm_Load(object sender, EventArgs e)
        {
            labelShowedContactName.Text = contact.Name;
            labelShowedContactNumber.Text = contact.Number;
        }

        private void buttonEditContact_Click(object sender, EventArgs e)
        {
            new EditContactForm(contact).ShowDialog();
            this.Close();
        }

        private void buttonContactCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
