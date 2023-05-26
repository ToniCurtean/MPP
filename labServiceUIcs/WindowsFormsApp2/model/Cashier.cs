using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.model
{
    public class Cashier:Entity<int>
    {
        private string username;
        private string password;

        public Cashier(int id,string username,string password) : base(id)
        {
            this.username = username;
            this.password = password;
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        
    }
}
