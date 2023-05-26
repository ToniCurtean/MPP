using System;

namespace networking
{
    [Serializable]
    public class ConcertDTO
    {
        private int id;
        private string concertDate;
        private string concertLocation;
        private int ticketsAvailable;
        private int ticketsSold;
        private int artistId;
        private string startingTime;
        
        public ConcertDTO(string concertDate, string concertLocation, int ticketsAvailable, int ticketsSold, int artistId, string startingTime) {
            this.concertDate = concertDate;
            this.concertLocation = concertLocation;
            this.ticketsAvailable = ticketsAvailable;
            this.ticketsSold = ticketsSold;
            this.artistId = artistId;
            this.startingTime = startingTime;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string ConcertDate
        {
            get => concertDate;
            set => concertDate = value;
        }

        public string ConcertLocation
        {
            get => concertLocation;
            set => concertLocation = value;
        }

        public int TicketsAvailable
        {
            get => ticketsAvailable;
            set => ticketsAvailable = value;
        }

        public int TicketsSold
        {
            get => ticketsSold;
            set => ticketsSold = value;
        }

        public int ArtistId
        {
            get => artistId;
            set => artistId = value;
        }

        public string StartingTime
        {
            get => startingTime;
            set => startingTime = value;
        }
    }
}