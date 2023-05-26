using System;
using System.Collections.Generic;
using System.Data;
using model;

namespace persistence
{
    public class CashierDBRepository : ICashierRepository
    {
        private IDictionary<string, string> props;

        public CashierDBRepository(IDictionary<string, string> props)
        {
            this.props = props;
        }
        
        public void Save(Cashier entity)
        {
            throw new System.NotImplementedException();
        }

        public Cashier FindOne(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Cashier> FindAll()
        {
            var connection = DbUtils.getConnection(props);
            IList <Cashier> cashiers= new List<Cashier>();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from cashiers";
                using (var dataR = command.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt16(0);
                        string username = dataR.GetString(1);
                        string password = dataR.GetString(2); 
                        Cashier cashier = new Cashier(id, username, password);
                        cashiers.Add(cashier);
                    }
                }
            }
            return cashiers;
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, Cashier e)
        {
            throw new System.NotImplementedException();
        }

        public Cashier GetCashierByUserPassword(string username, string password)
        {
            IDbConnection con = DbUtils.getConnection(props);
            Console.WriteLine("AIICIIII");
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from cashiers where username=@user and password=@pass";
                
                var paramUser = comm.CreateParameter();
                paramUser.ParameterName = "@user";
                paramUser.Value = username;
                comm.Parameters.Add(paramUser);

                var paramPass = comm.CreateParameter();
                paramPass.ParameterName = "@pass";
                paramPass.Value = password;
                comm.Parameters.Add(paramPass);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        Cashier cashier = new Cashier(dataR.GetInt32(0), dataR.GetString(1), dataR.GetString(2));
                        return cashier;
                    }
                }
            }

            return null;
        }
    }
}