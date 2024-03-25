using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIPrviProjekat
{

    public enum TypeAccount {Admin,Visitor};
    public class Account
    {

        private string username;
        private string password;
        private TypeAccount accType;

        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }
        public TypeAccount AccType { get { return accType; } set { accType = value; } }

        public Account()
        {
          
        }

        public Account(string username,string password, TypeAccount type)
        {
            Username = username;
            Password = password;
            AccType = type;
        }
        public override bool Equals(object obj)
        {

            if (obj == null)
            {
                return false;
            }

            Account temp = (Account)obj;
            if(this.Username == temp.Username && this.Password == temp.Password)
            {
                return true;
            }

            return false;
        }
    }
}
