using System;

namespace networking
{
    [Serializable]
    public class CashierDTO
    {
        private string username;

        private string password;

        private int id;
        
        public CashierDTO(string username,string password){
            this.username=username;
            this.password=password;
        }

        public CashierDTO(){

        }

        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
    }
}