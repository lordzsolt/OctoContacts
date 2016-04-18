using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NDatabase;

using OctoContacts.DataObjects;

namespace OctoContacts
{
    public partial class LoginForm : Form
    {
        private const string kConfigurationKeyUsername = "username";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Configuration config =
                ConfigurationManager.OpenExeConfiguration(System.Windows.Forms.Application.ExecutablePath);
            if (config.AppSettings.Settings[kConfigurationKeyUsername] != null)
            {
                this.usernameTextBox.Text = config.AppSettings.Settings[kConfigurationKeyUsername].Value;
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var username = this.usernameTextBox.Text;
            var password = this.passwordTextBox.Text;
            var user = User.login(username, password);
            if (user != null && this.saveUsernameCheckbox.Checked)
            {
                Configuration config =
                    ConfigurationManager.OpenExeConfiguration(System.Windows.Forms.Application.ExecutablePath);
                config.AppSettings.Settings[kConfigurationKeyUsername].Value = username;
            }
        }
    }
}
