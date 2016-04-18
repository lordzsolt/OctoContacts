using System;
using System.Linq;
using System.Windows.Forms;

using CryptSharp;

using NDatabase;

namespace OctoContacts.DataObjects
{

    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public static User Login(string username, string password)
        {
            try
            {
                using (var odb = OdbFactory.Open("octo.db"))
                {
                    var user = odb.AsQueryable<User>().FirstOrDefault(u => u.Username == username);
                    
                    if (user != null && Crypter.CheckPassword(password, user.Password))
                    {
                        return user;
                    }
                }

                MessageBox.Show("Username or password incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to open database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        public static bool Register(string username, string password)
        {
            try
            {
                using (var odb = OdbFactory.Open("octo.db"))
                {
                    var user = odb.AsQueryable<User>().FirstOrDefault(u => u.Username == username);

                    if (user != null)
                    {
                        MessageBox.Show("Username already in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    user = new User(username, Crypter.Blowfish.Crypt(password));
                    odb.Store(user);

                    return true;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Failed to open database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
