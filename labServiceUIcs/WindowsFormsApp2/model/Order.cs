using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.model
{
    public class Order:Entity<int>
    {
        private int concertId;
        private string buyerName;
        private int numberOfTickets;

        public Order(int id,int concertId,string buyerName,int numberOfTickets) : base(id)
        {
            this.concertId = concertId;
            this.buyerName = buyerName;
            this.numberOfTickets = numberOfTickets;
        }

        public int ConcertId
        {
            get { return concertId; }
            set { concertId = value; }
        }

        public string BuyerName
        {
            get { return buyerName; }
            set { buyerName = value; }
        }

        public int NumberOfTickets
        {
            get { return numberOfTickets; }
            set { numberOfTickets = value; }
        }
    }
}
