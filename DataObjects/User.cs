﻿using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

using CryptSharp;

using NDatabase;

namespace OctoContacts.DataObjects
{

    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public User(string username, string password, string securityQ, string securityA)
        {
            Username = username;
            Password = password;
            SecurityQuestion = securityQ;
            SecurityAnswer = securityA;
        }

        public static bool UsernameExists(string username)
        {
            return UserWithUsername(username) != null;
        }

        public static User UserWithUsername(string username)
        {
            try
            {
                using (var odb = OdbFactory.Open("octo3.db"))
                {
                    var user = odb.AsQueryable<User>().FirstOrDefault(u => u.Username == username);
                    return user;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to open database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public static User Login(string username, string password)
        {
            try
            {
                using (var odb = OdbFactory.Open("octo3.db"))
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

        public void Save()
        {
            try
            {
                using (var odb = OdbFactory.Open("octo3.db"))
                {
                    odb.Store(this);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Failed to open database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Delete()
        {
            try
            {
                using (var odb = OdbFactory.Open("octo3.db"))
                {
                    User u = (from cont in odb.AsQueryable<User>()
                               where cont.Username.Equals(this.Username)
                               select cont).First();
                    odb.Delete(u);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Failed to open database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
