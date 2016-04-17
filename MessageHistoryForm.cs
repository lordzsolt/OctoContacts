using System;
using System.Windows.Forms;

using NDatabase;

namespace OctoContacts
{
    public partial class MessageHistoryForm : Form
    {
        public MessageHistoryForm()
        {
            InitializeComponent();
        }

        private void MessageHistoryForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (var odb = OdbFactory.Open("octo.db"))
                {
                    var msgs = odb.QueryAndExecute<Message>();

                    foreach (var msg in msgs)
                    {
                        var lvi = new ListViewItem(new[] { msg.Date.ToString(), msg.To, msg.Text });
                        listView.Items.Add(lvi);
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
