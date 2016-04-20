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
            Refresh();
        }

        void btnAddNewContact_Click(object sender, EventArgs e)
        {
            new NewContactForm(this).ShowDialog();
        }


        public void Refresh()
        {
            this.Controls.Clear();

            Panel panel = new Panel();
            panel.Size = new Size(this.Width - 30, this.Height - 150);
            panel.Location = new Point(10, 50);
            panel.AutoScroll = true;
            //panel.BorderStyle = BorderStyle.FixedSingle;

            Label nameLabel = new Label();
            nameLabel.Text = "Name";
            nameLabel.Location = new Point(10, 20);
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font(nameLabel.Font, FontStyle.Bold);
            this.Controls.Add(nameLabel);

            Label numberLabel = new Label();
            numberLabel.Text = "Number";
            numberLabel.Location = new Point(this.Width / 2, 20);
            numberLabel.AutoSize = true;
            numberLabel.Font = new Font(numberLabel.Font, FontStyle.Bold);
            this.Controls.Add(numberLabel);

            Button btnAddNewContact = new Button();
            btnAddNewContact.Text = "New Contact";
            btnAddNewContact.AutoSize = true;
            btnAddNewContact.Location = new Point(10, this.Height - 50 - btnAddNewContact.Height);
            btnAddNewContact.Click += btnAddNewContact_Click;
            this.Controls.Add(btnAddNewContact);

            Button btnMessageHistory = new Button();
            btnMessageHistory.Text = "Message History";
            btnMessageHistory.AutoSize = true;
            btnMessageHistory.Location = new Point(this.Width - btnMessageHistory.Width-50, this.Height - 50 - btnAddNewContact.Height);
            btnMessageHistory.Click += btnMessageHistory_Click;
            this.Controls.Add(btnMessageHistory);

            try
            {
                using (var odb = OdbFactory.Open("octo.db"))
                {
                    List<Contact> fromDB = (from cont in odb.AsQueryable<Contact>()
                                            orderby cont.Name ascending
                                            select cont).ToList();

                    for (int i = 0; i < fromDB.Count(); ++i)
                    {
                        LinkLabel name = new LinkLabel();
                        name.Text = fromDB[i].Name;
                        name.Location = new Point(0, 20 * i);
                        name.AutoSize = true;
                        name.LinkClicked += name_LinkClicked;
                        panel.Controls.Add(name);

                        LinkLabel number = new LinkLabel();
                        number.Text = fromDB[i].Number;
                        number.Location = new Point(panel.Width / 2, 20 * i);
                        number.AutoSize = true;
                        number.LinkClicked += number_LinkClicked;
                        panel.Controls.Add(number);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to open database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Controls.Add(panel);
        }

        void btnMessageHistory_Click(object sender, EventArgs e)
        {
            new MessageHistoryForm().ShowDialog();
        }

        void number_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel label = sender as LinkLabel;
            try
            {
                using (var odb = OdbFactory.Open("octo.db"))
                {
                    Contact contact = (from cont in odb.AsQueryable<Contact>()
                                       where cont.Number.Equals(label.Text)
                               select cont).First();
                    new SendMessageForm(contact).ShowDialog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to open database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        void name_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel label = sender as LinkLabel;

            if (e.Button == MouseButtons.Left)
                new EditContactForm(this, label.Text).ShowDialog();
            else if (e.Button == MouseButtons.Right)
                new ContactDetailsForm(label.Text).ShowDialog();
        }

        private void ContactListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
