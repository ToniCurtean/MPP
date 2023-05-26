using System;

namespace model
{
    [Serializable]
    public class Cashier:Entity<int>
    {
        private string username;

        private string password;
        
        
        public Cashier(int id) : base(id)
        {
            
        }

        public Cashier(int id,string username, string password) : base(id)
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