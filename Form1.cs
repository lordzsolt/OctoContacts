using System;
using System.Windows.Forms;

namespace OctoContacts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO temporary flow of the app
            new LoginForm().ShowDialog();
//            new SendMessageForm(new Contact("Zsolt Kovács", "40748635048")).ShowDialog();
//            new MessageHistoryForm().ShowDialog();
        }
    }
}
