using System.Collections;
using System.Collections.Generic;
using WindowsFormsApp2.model;
using WindowsFormsApp2.repository;

namespace WindowsFormsApp2
{
    public class ServiceConcert
    {
        private ConcertsDBRepository concertsDbRepository;

        public ServiceConcert(ConcertsDBRepository concertsDbRepository)
        {
            this.concertsDbRepository = concertsDbRepository;
        }

        public IEnumerable<Concert> findAll() {
            return concertsDbRepository.FindAll();
        }

        public IEnumerable<Concert> getConcertsByDate(string date)
        {
            return concertsDbRepository.getConcertsByDate(date);
        }

        public void updateConcertTickets(int id, int numberOfTickets) {
            Concert concert = concertsDbRepository.FindOne(id);
            int newTicketsAvailable = concert.TicketsAvailable - numberOfTickets;
            int newTicketsSold = concert.TicketsSold + numberOfTickets;
            concertsDbRepository.UpdateConcertTickets(id, newTicketsAvailable, newTicketsSold);
        }

        public Concert getConcertByDateLocationStart(string date, string location, string startTime)
        {
            return concertsDbRepository.getConcertByDateLocationStart(date, location, startTime);
        }
        
    }
}