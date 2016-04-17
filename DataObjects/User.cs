using System;
using System.Windows.Forms;
using NDatabase;

namespace OctoContacts.DataObjects
{
    class User
    {
        public string username { get; set; }
        public string password { get; set; }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public static User login(string username, string password)
        {
            try
            {
                using (var odb = OdbFactory.Open("octo.db"))
                {
                    var query = new CriteriaQuery<User>(Where.Equal("username", username));
                    var user = odb.Query<User>(query);
                    if (user && user.Current.password == password)
                    {
                        return user.Current;
                    }
                    else
                    {
                        MessageBox.Show("Username or password incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to open database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
    }
}
