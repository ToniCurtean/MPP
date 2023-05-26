namespace WindowsFormsApp2.model
{
    public class Concert:Entity<int>
    {
        private string date;
        private string concertLocation;
        private int ticketsAvailable;
        private int ticketsSold;
        private int artistId;
        private string startTime;
        
        public Concert(int id,string date,string concertLocation,int ticketsAvailable,int ticketsSold,int artistId,string startTime) : base(id)
        {
            this.date = date;
            this.concertLocation = concertLocation;
            this.ticketsAvailable = ticketsAvailable;
            this.ticketsSold = ticketsSold;
            this.artistId = artistId;
            this.startTime = startTime;
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public string ConcertLocation
        {
            get { return concertLocation; }
            set { concertLocation = value; }
        }

        public int TicketsAvailable
        {
            get { return ticketsAvailable; }
            set { ticketsAvailable = value; }
        }

        public int TicketsSold
        {
            get { return ticketsSold; }
            set { ticketsSold = value; }
        }

        public int ArtistId
        {
            get { return artistId; }
            set { artistId = value; }
        }

        public string StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
    }
}
