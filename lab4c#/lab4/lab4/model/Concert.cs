namespace lab4.model
{
    public class Concert:Entity<int>
    {
        public string date { get; set; }
        public string concertLocation { get; set; }
        public int ticketsAvailable { get; set; }
        public int ticketsSold { get; set; }
        public int artistId { get; set; }

        public Concert(int id,string date,string concertLocation,int ticketsAvailable,int ticketsSold,int artistId) : base(id)
        {
            this.date = date;
            this.concertLocation = concertLocation;
            this.ticketsAvailable = ticketsAvailable;
            this.ticketsSold = ticketsSold;
            this.artistId = artistId;
        }

    }
}
