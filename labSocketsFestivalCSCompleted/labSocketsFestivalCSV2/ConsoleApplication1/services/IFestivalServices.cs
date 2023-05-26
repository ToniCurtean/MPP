using System.Collections.Generic;
using model;

namespace services
{
    public interface IFestivalServices
    {
        void login(string username, string passowrd, IFestivalObserver festivalObserver);
        Artist findOne(int id);

        IEnumerable<Concert> findAllConcerts();

        IEnumerable<Concert> getConcertsByDate(string date);

        Concert getConcertByDateLocationStart(string date, string location, string startTime);

        Concert updateConcertTickets(int id, int numberOfTickets);

        void save(int concertID,string buyerName, int numberOfTickets);

        void logout(Cashier cashier,IFestivalObserver client);

        IList<ConcertInfo> getConcertInfos();
        IList<ConcertInfo> getConcertInfosByDate(string date);
    }
}