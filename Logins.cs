using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagementApplication
{
    class Logins
    {
        private int _ID;
        private string _username;
        private string _password;
        private int _superUser;

        public int ID { get => _ID; set => _ID = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public int SuperUser { get => _superUser; set => _superUser = value; }

        public Logins(int iD, string username, string password, int superUser)
        {
            ID = iD;
            Username = username;
            Password = password;
            SuperUser = superUser;
        }
    }
}
