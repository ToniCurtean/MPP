using System.Collections.Generic;
using System.Collections.ObjectModel;
using model;

namespace persistence
{
    public interface IConcertRepository:IRepository<int,Concert>
    {
        IEnumerable<Concert> GetConcertsByDate(string date);
        
        void UpdateConcertTickets(int id, int newTicketsAvailable,int newTicketsSold);

        Concert getConcertByDateLocationStart(string date, string location, string start);

        IList<ConcertInfo> getConcertInfos();

        IList<ConcertInfo> getConcertInfosByDate(string date);
    }
}