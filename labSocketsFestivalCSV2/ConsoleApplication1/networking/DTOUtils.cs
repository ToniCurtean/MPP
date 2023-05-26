using model;

namespace networking
{
    public class DTOUtils
    {
        public static Cashier getFromDTO(CashierDTO dto)
        {
            int id = dto.Id;
            string username = dto.Username;
            string password = dto.Password;
            return new Cashier(id, username, password);
        }

        public static CashierDTO getDTO(Cashier cashier)
        {
            string username = cashier.Username;
            string password = cashier.Password;
            int id = cashier.Id;
            CashierDTO dto = new CashierDTO(username, password);
            dto.Id = id;
            return dto;
        }

        public static OrderDTO getDTO(Order order)
        {
            int concertId = order.ConcertId;
            string buyer = order.BuyerName;
            int nrOfTickets = order.NumberOfTickets;
            int id = order.Id;
            OrderDTO dto = new OrderDTO(concertId, buyer, nrOfTickets);
            dto.Id = id;
            return dto;
        }

        public static Artist getFromDTO(ArtistDTO artist)
        {
            string name = artist.Name;
            string musicType = artist.MusicType;
            int id = artist.Id;
            return new Artist(id, name, musicType);
        }

        public static Concert getFromDTO(ConcertDTO dto)
        {
            int id = dto.Id;
            string date = dto.ConcertDate;
            string location = dto.ConcertLocation;
            int nrAvailable = dto.TicketsAvailable;
            int nrSold = dto.TicketsSold;
            int artistId = dto.ArtistId;
            string startTime = dto.StartingTime;
            return new Concert(id, date, location, nrAvailable, nrSold, artistId, startTime);
        }

        public static ConcertDTO getDTO(Concert concert)
        {
            int id = concert.Id;
            string date = concert.Date;
            string location = concert.ConcertLocation;
            int nrAvailable = concert.TicketsAvailable;
            int nrSold = concert.TicketsSold;
            int artistId = concert.ArtistId;
            string startTime = concert.StartTime;
            ConcertDTO concertDto = new ConcertDTO(date, location, nrAvailable, nrSold, artistId, startTime);
            concertDto.Id = id;
            return concertDto;
        }
        public static Concert[] getFromDTO(ConcertDTO[] dtos)
        {
            Concert[] concerts = new Concert[dtos.Length];
            for (int i = 0; i < dtos.Length; i++)
            {
                concerts[i] = getFromDTO(dtos[i]);
            }
            return concerts;
        }
        
        public static ConcertDTO[] getDTO(Concert[] concerts)
        {
            ConcertDTO[] dtos = new ConcertDTO[concerts.Length];
            for (int i = 0; i < concerts.Length; i++)
            {
                dtos[i] = getDTO(concerts[i]);
            }
            return dtos;
        }

        public static ArtistDTO getDTO(Artist artist)
        {
            int id = artist.Id;
            string name = artist.Name;
            string musicType = artist.MusicType;
            ArtistDTO dto = new ArtistDTO(name, musicType);
            dto.Id = id;
            return dto;
        }

        public static Order getFromDTO(OrderDTO dto)
        {
            int id = dto.Id;
            int concertId = dto.ConcertId;
            int nrOfTickets = dto.NumberOfTickets;
            string buyerName = dto.BuyerName;
            return new Order(id, concertId, buyerName, nrOfTickets);
        }

        public static ConcertInfo getFromDTO(ConcertInfoDTO dto)
        {
            string artist = dto.artistName;
            int concertId = dto.concertId;
            string date = dto.date;
            string location = dto.concertLocation;
            int ticketsAvailable = dto.ticketsAvailable;
            int ticketsSold = dto.ticketsSold;
            string startTime = dto.startTime;
            return new ConcertInfo(artist, concertId, date, location, ticketsAvailable, ticketsSold, startTime);
        }

        public static ConcertInfoDTO getDTO(ConcertInfo concertInfo)
        {
            string artist = concertInfo.artistName;
            int concertId = concertInfo.concertId;
            string date = concertInfo.date;
            string location = concertInfo.concertLocation;
            int ticketsAvailable = concertInfo.ticketsAvailable;
            int ticketsSold = concertInfo.ticketsSold;
            string startTime = concertInfo.startTime;
            return new ConcertInfoDTO(artist, concertId, date, location, ticketsAvailable, ticketsSold, startTime);
        }
        
        public static ConcertInfo[] getFromDTO(ConcertInfoDTO[] dtos)
        {
            ConcertInfo[] concertsInfo = new ConcertInfo[dtos.Length];
            for (int i = 0; i < dtos.Length; i++)
            {
                concertsInfo[i] = getFromDTO(dtos[i]);
            }
            return concertsInfo;
        }
        
        public static ConcertInfoDTO[] getDTO(ConcertInfo[] concertsInfo)
        {
            ConcertInfoDTO[] dtos = new ConcertInfoDTO[concertsInfo.Length];
            for (int i = 0; i < concertsInfo.Length; i++)
            {
                dtos[i] = getDTO(concertsInfo[i]);
            }
            return dtos;
        }
        
        
    }
}