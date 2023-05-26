using System;

namespace networking
{
    [Serializable]
    public class ConcertInfoDTO
    {
        public string artistName { get; set;}

        public int concertId { get; set;}
        
        public string date { get; set;}

        public string concertLocation { get; set;}
        public int ticketsAvailable { get; set;}
        public int ticketsSold { get; set;}
        public string startTime { get; set; }

        public ConcertInfoDTO(string artistName, int concertId, string date, string concertLocation, int ticketsAvailable, int ticketsSold, string startTime)
        {
            this.artistName = artistName;
            this.concertId = concertId;
            this.date = date;
            this.concertLocation = concertLocation;
            this.ticketsAvailable = ticketsAvailable;
            this.ticketsSold = ticketsSold;
            this.startTime = startTime;
        }
    }
}