using System.Collections.Generic;
using System.Data;
using labRepositoryCs.model;
using log4net;

namespace labRepositoryCs.repository
{
    public class CashiersDBRepository:ICashiersRepository
    {
        private IDictionary<string, string> properties;
        private static ILog log = LogManager.GetLogger(typeof(CashiersDBRepository));

        public CashiersDBRepository(IDictionary<string, string> properties)
        {
            log.Info("Initializing CashiersDBRepository");
            this.properties = properties;
        }
        
        public Cashier FindOne(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Cashier> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Cashier Save(Cashier e)
        {
            throw new System.NotImplementedException();
        }

        public Cashier Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public Cashier Update(int id, Cashier e)
        {
            throw new System.NotImplementedException();
        }

        public Cashier getCashierByUsernamePassword(string username, string password)
        {
            log.InfoFormat("find cashier by username and password {0} {0}",username,password);
            IDbConnection connection = DBUtils.getConnection(properties);
            Cashier cashier = null;
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from cashiers where username=@username and password=@password";
                var paramUsername = command.CreateParameter();
                paramUsername.ParameterName = "@username";
                paramUsername.Value = username;
                command.Parameters.Add(paramUsername);

                var paramPassowrd = command.CreateParameter();
                paramPassowrd.ParameterName = "@password";
                paramPassowrd.Value = password;
                command.Parameters.Add(paramPassowrd);
                
                using (var dataR = command.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        cashier = new Cashier(dataR.GetInt16(0),dataR.GetString(1),dataR.GetString(2));
                    }
                }
            }
            log.InfoFormat("The cashier found {0}",cashier);
            return cashier;
        }
    }
}