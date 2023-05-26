using System;
using System.Collections.Generic;
using model;

namespace persistence
{
    public class OrderDBRepository:IOrderRepository
    {
        private IDictionary<string, string> props;

        public OrderDBRepository(IDictionary<string, string> props)
        {
            this.props = props;
        }
        
        public void Save(Order entity)
        {
            var con = DbUtils.getConnection(props);
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into order(concertId,buyerName,numberOfTickets) values(@cId,@bName,@nr)";
                var paramCId = comm.CreateParameter();
                paramCId.ParameterName = "@cId";
                paramCId.Value = entity.ConcertId;
                comm.Parameters.Add(paramCId);

                var paramBName = comm.CreateParameter();
                paramBName.ParameterName = "@bName";
                paramBName.Value = entity.BuyerName;
                comm.Parameters.Add(paramBName);

                var paramNr = comm.CreateParameter();
                paramNr.ParameterName = "@nr";
                paramNr.Value = entity.NumberOfTickets;
                comm.Parameters.Add(paramNr);

                int rez = comm.ExecuteNonQuery();
                Console.WriteLine("MessageDB [save] rez={0}",rez);
            }
        }

        public Order FindOne(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Order> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, Order e)
        {
            throw new System.NotImplementedException();
        }
    }
}