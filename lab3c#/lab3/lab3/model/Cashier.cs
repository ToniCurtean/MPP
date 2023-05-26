using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.model
{
    public class Cashier:Entity<int>
    {
        public string username { get; set; }
        public string password { get; set; }

        public Cashier(int id,string username,string password) : base(id)
        {
            this.username = username;
            this.password = password;
        }

       
    }
}
