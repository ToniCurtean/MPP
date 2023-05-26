using System;
using System.Runtime.CompilerServices;

namespace networking
{
    public interface Request
    {
        
    }

    [Serializable]
    public class LoginRequest : Request
    {
        private CashierDTO cashier;

        public LoginRequest(CashierDTO cashier)
        {
            this.cashier = cashier;
        }
        
        public virtual CashierDTO Cashier
        {
            get
            {
                return cashier;
            }
        }
    }

    [Serializable]
    public class LogoutRequest : Request
    {
        private CashierDTO cashier;

        public LogoutRequest(CashierDTO cashier)
        {
            this.cashier = cashier;
        }

        public virtual CashierDTO Cashier
        {
            get
            {
                return cashier;
            }
        }
    }

    [Serializable]
    public class GetListConcerts : Request
    {
        public GetListConcerts()
        {
            
        }
    }

    [Serializable]
    public class GetConcertInfos : Request
    {
        public GetConcertInfos()
        {
            
        }
    }

    [Serializable]
    public class GetConcertInfosByDate : Request
    {
        private string data;
        
        public GetConcertInfosByDate(string data)
        {
            this.data = data;
        }

        public virtual string Data
        {
            get
            {
                return this.data;
            }
        }
        
    }

    [Serializable]
    public class GetListConcertsByDate : Request
    {
        private string data;

        public GetListConcertsByDate(string data)
        {
            this.data = data;
        }

        public virtual string Data
        {
            get
            {
                return this.data;
            }
        }
    }

    [Serializable]
    public class AddOrder : Request
    {
        private OrderDTO order;

        public AddOrder(OrderDTO order)
        {
            this.order = order;
        }

        public virtual OrderDTO Order
        {
            get
            {
                return this.order;
            }
        }
    }

    [Serializable]
    public class FindConcertDLS : Request
    {
        private string date;
        private string location;
        private string startTime;

        public FindConcertDLS(string date, string location, string startTime)
        {
            this.date = date;
            this.location = location;
            this.startTime = startTime;
        }

        public virtual string Date
        {
            get
            {
                return this.date;
            }
        }
        
        public virtual string Location
        {
            get
            {
                return this.location;
            }
        }
        
        public virtual string StartTime
        {
            get
            {
                return this.startTime;
            }
        }
        
    }
    [Serializable]
    public class FindArtist:Request
    {
        private int id;

        public FindArtist(int id)
        {
            this.id = id;
        }

        public virtual int Id
        {
            get
            {
                return this.id;
            }
        }
    }

    [Serializable]
    public class UpdateConcertTickets : Request
    {
        private int id;
        private int nrOfTickets;

        public UpdateConcertTickets(int id, int nrOfTickets)
        {
            this.id = id;
            this.nrOfTickets = nrOfTickets;
        }

        public virtual int Id
        {
            get
            {
                return this.id;
            }
        }

        public virtual int NrOfTickets
        {
            get
            {
                return this.nrOfTickets;
            }
        }
    }
    
    
}