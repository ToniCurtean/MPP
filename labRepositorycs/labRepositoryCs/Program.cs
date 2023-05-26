using System;
using System.Collections.Generic;
using System.Configuration;
using labRepositoryCs.model;
using labRepositoryCs.repository;
using log4net.Config;

namespace labRepositoryCs
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Uri configUri = new Uri("D:\\faculta\\anun2\\SEM2\\MPP\\labRepositorycs\\labRepositoryCs\\labRepositoryCs\\log4net.config");
            log4net.Config.XmlConfigurator.Configure(configUri);
            Console.WriteLine("Configuration Settings for musicfestivalDB {0}",GetConnectionStringByName("musicfestivalDB"));
            IDictionary<String, string> props = new SortedList<String, String>();
            props.Add("ConnectionString", GetConnectionStringByName("musicfestivalDB"));

            ArtistsDBRepository repository = new ArtistsDBRepository(props);
            Console.WriteLine("artisti din repo");
            foreach (Artist each in repository.FindAll())
            {
                Console.WriteLine(each.Name);   
            }

            CashiersDBRepository cashiersDbRepository = new CashiersDBRepository(props);
            Cashier cashier = cashiersDbRepository.getCashierByUsernamePassword("toni", "toni");
            Console.WriteLine(cashier.Username);

            OrdersDBRepository ordersDbRepository = new OrdersDBRepository(props);
            ordersDbRepository.Save(new Order(0, 1, "Toni", 2));

            ConcertsDBRepository concertsDbRepository = new ConcertsDBRepository(props);
            concertsDbRepository.UpdateConcertTickets(1, 2,3);
        }
        
        public static string GetConnectionStringByName(string name)
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings =ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }

    }
}