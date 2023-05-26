using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Sockets;
using System.Threading;
using model;
using networking;
using persistence;
using services;

namespace Server
{
    public class StartServer
    {
        static void Main(string[] agrs)
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("ConnectionString",GetConnectionStringByName("music_festival"));
            IArtistRepository artistRepository = new ArtistDBRepository(dict);
            ICashierRepository cashierRepository = new CashierDBRepository(dict);
            IConcertRepository concertRepository = new ConcertDBRepository(dict);
            IOrderRepository orderRepository = new OrderDBRepository(dict);
            
            foreach(Concert concert in concertRepository.FindAll())
            {
                Console.WriteLine(concert.ConcertLocation);
            }
            
            foreach(ConcertInfo concert in concertRepository.getConcertInfosByDate("27.03.2023"))
            {
                Console.WriteLine(concert.concertLocation);
            }
            
            IFestivalServices serviceImpl = new FestivalServerImpl(artistRepository,cashierRepository,concertRepository,orderRepository);

            SerialChatServer server = new SerialChatServer("127.0.0.1", 55556, serviceImpl);
            server.Start();
            Console.WriteLine("Server started ...");
            //Console.WriteLine("Press <enter> to exit...");
            Console.ReadLine();
        }

        private static string GetConnectionStringByName(string musicFestival)
        {
            string returnValue = "";
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[musicFestival];
            if (settings != null)
            {
                returnValue = settings.ConnectionString;
            }

            return returnValue;
        }
    }
    
    public class SerialChatServer: ConcurrentServer 
    {
        private IFestivalServices server;
        private FestivalClientObjectWorker worker;
        public SerialChatServer(string host, int port, IFestivalServices server) : base(host, port)
        {
            this.server = server;
            Console.WriteLine("SerialChatServer...");
        }
        protected override Thread createWorker(TcpClient client)
        {
            Console.WriteLine("CREATE WORKER....");
            worker = new FestivalClientObjectWorker(server, client);
            return new Thread(new ThreadStart(worker.run));
        }
    }
    
    
    
    
    
    
}