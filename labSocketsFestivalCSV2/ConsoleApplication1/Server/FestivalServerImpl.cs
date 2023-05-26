using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;
using System.Threading.Tasks;
using model;
using persistence;
using services;

namespace Server
{
    public class FestivalServerImpl:IFestivalServices
    {
        private IArtistRepository artistDBRepository;

        private ICashierRepository cashierDBRepository;

        private IConcertRepository concertDBRepository;

        private IOrderRepository orderDBRepository;

        private IDictionary<string,IFestivalObserver> loggedCashiers;

        public FestivalServerImpl(IArtistRepository artistDbRepository, ICashierRepository cashierDbRepository, IConcertRepository concertDbRepository, IOrderRepository orderDbRepository)
        {
            artistDBRepository = artistDbRepository;
            cashierDBRepository = cashierDbRepository;
            concertDBRepository = concertDbRepository;
            orderDBRepository = orderDbRepository;
            loggedCashiers = new Dictionary<string, IFestivalObserver>();
        }

        public void login(string username, string passowrd, IFestivalObserver festivalObserver)
        {
            Cashier cashier = cashierDBRepository.GetCashierByUserPassword(username, passowrd);
            if(cashier!=null)
            {
                if (loggedCashiers.ContainsKey(cashier.Username))
                    throw new FestivalException("Cashier already logged in!");
                loggedCashiers[cashier.Username] = festivalObserver;
            }else
                throw new FestivalException("Couldn't log in");
        }

        public Artist findOne(int id)
        {
            return artistDBRepository.FindOne(id);
        }

        public IEnumerable<Concert> findAllConcerts()
        {
            return concertDBRepository.FindAll();
        }

        public IEnumerable<Concert> getConcertsByDate(string date)
        {
            return concertDBRepository.GetConcertsByDate(date);
        }

        public Concert getConcertByDateLocationStart(string date, string location, string startTime)
        {
            return concertDBRepository.getConcertByDateLocationStart(date, location, startTime);
        }

        public Concert updateConcertTickets(int id, int numberOfTickets)
        {
            Concert concert=concertDBRepository.FindOne(id);
            int newTicketsAvailable=concert.TicketsAvailable-numberOfTickets;
            int newTicketsSold=concert.TicketsSold+numberOfTickets;
            concertDBRepository.UpdateConcertTickets(id,newTicketsAvailable,newTicketsSold);
            return concertDBRepository.FindOne(id);
        }

        public void save(int concertID, string buyerName, int numberOfTickets)
        {
            Order order = new Order(0,concertID, buyerName, numberOfTickets);
            Concert concert = concertDBRepository.FindOne(order.ConcertId);
            concertDBRepository.UpdateConcertTickets(concert.Id,concert.TicketsAvailable-numberOfTickets, concert.TicketsSold+numberOfTickets);
            notifyUpdate();
        }

        private void notifyUpdate()
        {
            Console.WriteLine("aici tati");
            IEnumerable<Cashier> cashiers = cashierDBRepository.FindAll();
            foreach (Cashier cashier in cashiers)
            {
                if (loggedCashiers.ContainsKey(cashier.Username))
                {
                    IFestivalObserver client = loggedCashiers[cashier.Username];
                    Task.Run(() => client.Update());
                }
            }
        }

        public void logout(Cashier cashier, IFestivalObserver client)
        {
            IFestivalObserver localClient = loggedCashiers[cashier.Username];
            if (localClient==null)
                throw new FestivalException("Cashier "+cashier.Id+" is not logged in.");
            loggedCashiers.Remove(cashier.Username);
        }

        public IList<ConcertInfo> getConcertInfos()
        {
            return concertDBRepository.getConcertInfos();
        }

        public IList<ConcertInfo> getConcertInfosByDate(string date)
        {
            return concertDBRepository.getConcertInfosByDate(date);
        }
    }
}