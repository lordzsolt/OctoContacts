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
            // TODO temporarily redirected to MessageHistoryForm
            new MessageHistoryForm().ShowDialog();
        }
    }
}
