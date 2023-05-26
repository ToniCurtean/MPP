using System;
using System.Collections.Generic;
using System.Data;
using labRepositoryCs.model;
using log4net;
using Microsoft.Extensions.Logging;

namespace labRepositoryCs.repository
{
    public class OrdersDBRepository:IOrdersRepository
    {
        private IDictionary<string, string> properties;
        private static ILog log = LogManager.GetLogger(typeof(ArtistsDBRepository));

        public OrdersDBRepository(IDictionary<string, string> properties)
        {
            log.Info("Initializing OrdersDBRepository");
            this.properties = properties;
        }
        
        
        public Order FindOne(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Order> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Order Save(Order e)
        {
            log.InfoFormat("saving the order {0} in db",e.ToString());
            IDbConnection connection = DBUtils.getConnection(properties);
            using (var command = connection.CreateCommand())
            {
                command.CommandText="insert into orders(concertId,buyerName,numberOfTickets) values (@concertId,@buyerName,@numberOfTickets)";
                var paramConId = command.CreateParameter();
                paramConId.ParameterName = "@concertId";
                paramConId.Value = e.ConcertId;
                command.Parameters.Add(paramConId);
                
                var paramBuyer = command.CreateParameter();
                paramBuyer.ParameterName = "@buyerName";
                paramBuyer.Value = e.BuyerName;
                command.Parameters.Add(paramBuyer);
                
                var paramTickets = command.CreateParameter();
                paramTickets.ParameterName = "@numberOfTickets";
                paramTickets.Value = e.ConcertId;
                command.Parameters.Add(paramTickets);
                
                var result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting save without saving");
                    throw new Exception("Not added!");
                }
            }
            log.InfoFormat("saved entity {0}",e);
            return e;
        }

        public Order Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public Order Update(int id, Order e)
        {
            throw new System.NotImplementedException();
        }
    }
}