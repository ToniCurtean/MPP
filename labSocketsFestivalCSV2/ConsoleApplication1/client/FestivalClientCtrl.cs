using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using model;
using services;

namespace client
{
    public class FestivalClientCtrl:IFestivalObserver
    {

        private readonly IFestivalServices server;
        
        public FestivalWindow festivalWindow { get; set; }

        private Cashier loggedCashier;
        
        public Cashier cashier { get; set; }

        public FestivalClientCtrl(IFestivalServices server)
        {
            this.server = server;
            loggedCashier = null;
        }

        public void login(string username, string password)
        {
            try
            {
                server.login(username, password, this);
                //Console.WriteLine("Login succeededd");
                loggedCashier = new Cashier(0, username, password);
               //Console.WriteLine("Current user {0}", loggedCashier.Username);
               FestivalWindow festivalWindow = new FestivalWindow(this, loggedCashier);
               this.festivalWindow = festivalWindow;
               var t = new Thread(() => Application.Run(festivalWindow));
               t.Start();
            }
            catch (Exception e)
            {
                throw new FestivalException(e.Message);
            }
            
        }

        public void LogOut()
        {
            try
            {
                server.logout(loggedCashier, this);
                cashier = null;
            }
            catch (Exception ex)
            {
                throw new FestivalException(ex.Message);
            }
        }
        
        public ConcertInfo[] GetConcertsInfos()
        {
            Console.WriteLine("is aici");
            return (ConcertInfo[])server.getConcertInfos();
        }

        public Artist GetArtist(int artistId)
        {
            return server.findOne(artistId);
        }

        public ConcertInfo[] getConcertInfosByDate(string date)
        {
            return (ConcertInfo[])server.getConcertInfosByDate(date);
        }

        public void buyTickets(int concertId, string buyerName, int nrTickets)
        {
            server.save(concertId,buyerName,nrTickets);
        }
        
        public void Update()
        {
            festivalWindow.BeginInvoke(new FestivalWindow.UpdateContent(festivalWindow.LoadConcerts));
        }
    }
}