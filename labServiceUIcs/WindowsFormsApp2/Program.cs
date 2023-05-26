using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.model;
using WindowsFormsApp2.repository;


namespace WindowsFormsApp2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Uri configUri = new Uri("D:\\faculta\\anun2\\SEM2\\MPP\\labSeviceUIcs\\WindowsFormsApp2\\WindowsFormsApp2\\log4net.config");
            log4net.Config.XmlConfigurator.Configure(configUri);
            IDictionary<String, string> props = new SortedList<String, String>();
            props.Add("ConnectionString", GetConnectionStringByName("musicfestivalDB"));
            
            ArtistsDBRepository artistRepository=new ArtistsDBRepository(props);

            CashiersDBRepository cashierRepository = new CashiersDBRepository(props);

            ConcertsDBRepository concertRepository = new ConcertsDBRepository(props);

            OrdersDBRepository orderRepository=new OrdersDBRepository(props);

            ServiceArtist serviceArtist=new ServiceArtist(artistRepository);

            ServiceCashier serviceCashier=new ServiceCashier(cashierRepository);

            ServiceConcert serviceConcert=new ServiceConcert(concertRepository);

            ServiceOrder serviceOrder=new ServiceOrder(orderRepository);

            Service service=new Service(serviceArtist,serviceCashier,serviceConcert,serviceOrder);

            Login login = new Login();

            login.Service = service;
            
            Application.EnableVisualStyles();
            ////Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(login);
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