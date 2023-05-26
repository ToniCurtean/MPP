using System;
using model;

namespace networking
{
    [Serializable]
    public class OrderDTO
    {
        private int concertId;

        private string buyerName;

        private int numberOfTickets;

        private int id;
        
        public OrderDTO(int concertId, String buyerName, int numberOfTickets)
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
        
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        
    }
    
    
}