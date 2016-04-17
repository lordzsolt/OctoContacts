using System;
using System.Net;
using System.Windows.Forms;

using NDatabase;

namespace OctoContacts
{
    public partial class SendMessageForm : Form
    {
        public SendMessageForm()
        {
            InitializeComponent();
        }

        private void SendMessageForm_Load(object sender, EventArgs e)
        {
            // TODO load contact
        }

        private void messageTextBox_TextChanged(object sender, EventArgs e)
        {
            sendButton.Enabled = messageTextBox.TextLength != 0;
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            contactTextBox.Enabled = messageTextBox.Enabled = sendButton.Enabled = false;
            statusLabel.Text = "Sending message...";

            try
            {
                using (var wc = new WebClient())
                {
                    //await wc.DownloadStringTaskAsync("https://rest.nexmo.com/sms/json?api_key=685ca000&api_secret=7f2833736631bfda&to=40748635048&from=OctoContacts&text=" + Uri.EscapeDataString(messageTextBox.Text));
                }
            }
            catch (Exception)
            {
                statusLabel.Text = "Failed.";
                MessageBox.Show("Failed to send message.", "SMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                contactTextBox.Enabled = messageTextBox.Enabled = sendButton.Enabled = true;
                return;
            }
            
            try
            {
                using (var odb = OdbFactory.Open("octo.db"))
                {
                    odb.Store(new Message(DateTime.Now, "Zsolt Kovacs", messageTextBox.Text));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to open database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            statusLabel.Text = "Done.";
            MessageBox.Show("Message sent successfully!", "SMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
