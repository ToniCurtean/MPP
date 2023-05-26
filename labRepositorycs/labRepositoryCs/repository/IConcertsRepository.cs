using System.Collections.Generic;
using System.Collections.ObjectModel;
using labRepositoryCs.model;

namespace labRepositoryCs.repository
{
    public interface IConcertsRepository:IRepository<int,Concert>
    {
        IEnumerable<Concert> getConcertsByDate(string date);

        int UpdateConcertTickets(int id, int newTicketsAvailable,int newTicketsSold);

        Concert getConcertByDateLocationStart(string date, string location, string start);
    }
}