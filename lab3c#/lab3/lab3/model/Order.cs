using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.model
{
   public class Order:Entity<int>
    {
        public int concertId { get; set; }
        public string buyerName { get; set; }
        public int numberOfTickets { get; set; }

        public Order(int id,int concertId,string buyerName,int numberOfTickets) : base(id)
        {
            this.concertId = concertId;
            this.buyerName = buyerName;
            this.numberOfTickets = numberOfTickets;
        }

       
    }
}
