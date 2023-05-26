using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using WindowsFormsApp2.model;
using log4net;

namespace WindowsFormsApp2.repository
{
    public class ConcertsDBRepository:IConcertsRepository
    {
        
        private IDictionary<string, string> properties;
        private static ILog log = LogManager.GetLogger(typeof(CashiersDBRepository));

        public ConcertsDBRepository(IDictionary<string, string> properties)
        {
            log.Info("Initializing ConcertsDBRepository");
            this.properties = properties;
        }
        
        public Concert FindOne(int id)
        {
            log.InfoFormat("getting concert by id {0}",id);
            IDbConnection connection = DBUtils.getConnection(properties);
            Concert concert = null;
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from concerts where id=@id";

                var paramID = command.CreateParameter();
                paramID.ParameterName = "@id";
                paramID.Value = id;
                command.Parameters.Add(paramID);

                using (var dataR = command.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        concert = new Concert(dataR.GetInt32(0), dataR.GetString(1), dataR.GetString(2),
                            dataR.GetInt32(3), dataR.GetInt32(4), dataR.GetInt32(5), dataR.GetString(6));
                    }
                }
            }
            log.InfoFormat("found concert {0}",concert);
            return concert;
        }

        public IEnumerable<Concert> FindAll()
        {
            log.Info("getting all concerts");
            IDbConnection connection = DBUtils.getConnection(properties);
            IList <Concert> concerts= new List<Concert>();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from concerts";
                using (var dataR = command.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt16(0);
                        string date = dataR.GetString(1);
                        string concertLocation = dataR.GetString(2);
                        int ticketsAvailable = dataR.GetInt16(3);
                        int ticketsSold = dataR.GetInt16(4);
                        int artistId = dataR.GetInt16(5);
                        string startTime = dataR.GetString(6);
                        Concert concert = new Concert(id, date, concertLocation, ticketsAvailable, ticketsSold, artistId,startTime);
                        concerts.Add(concert);
                    }
                }
            }

            log.InfoFormat("finished finding all concerts");
            return concerts;
        }

        public Concert Save(Concert e)
        {
            throw new System.NotImplementedException();
        }

        public Concert Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public Concert Update(int id, Concert e)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Concert> getConcertsByDate(string date)
        {
            log.Info("getting all concerts by date");
            IDbConnection connection = DBUtils.getConnection(properties);
            IList <Concert> concerts= new List<Concert>();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from concerts where date=@date";

                var paramData = command.CreateParameter();
                paramData.ParameterName = "@date";
                paramData.Value = date;
                command.Parameters.Add(paramData);
                
                using (var dataR = command.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt16(0);
                        string data = dataR.GetString(1);
                        string concertLocation = dataR.GetString(2);
                        int ticketsAvailable = dataR.GetInt16(3);
                        int ticketsSold = dataR.GetInt16(4);
                        int artistId = dataR.GetInt16(5);
                        string startTime = dataR.GetString(6);
                        Concert concert = new Concert(id, date, concertLocation, ticketsAvailable, ticketsSold, artistId,startTime);
                        concerts.Add(concert);
                    }
                }
            }

            log.InfoFormat("finished finding all concerts");
            return concerts;
        }

        public int UpdateConcertTickets(int id, int newTicketsAvailable,int newTicketsSold)
        {
            log.InfoFormat("update concert tickets with id {0}",id);
            IDbConnection connection = DBUtils.getConnection(properties);

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "update concerts set ticketsAvailable=@newTicketsAvailable,ticketsSold=@newTicketsSold where id=@id";

                var paramTicketsA = command.CreateParameter();
                paramTicketsA.ParameterName = "@newTicketsAvailable";
                paramTicketsA.Value = newTicketsAvailable;
                command.Parameters.Add(paramTicketsA);

                var paramTicketsS = command.CreateParameter();
                paramTicketsS.ParameterName = "@newTicketsSold";
                paramTicketsS.Value = newTicketsSold;
                command.Parameters.Add(paramTicketsS);
                
                var paramId = command.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                command.Parameters.Add(paramId);

                var result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting update without updating");
                    throw new Exception("Not updated!");
                }
            }
            log.InfoFormat("updated order with id {0}",id);
            return id;
        }

        public Concert getConcertByDateLocationStart(string data, string location, string start)
        {
            log.InfoFormat("find concert by date,location and start");
            IDbConnection connection = DBUtils.getConnection(properties);
            Concert concert = null;
            using (var command = connection.CreateCommand())
            {
                command.CommandText="SELECT * FROM concerts where date=@data and concertLocation=@location and startTime=@start";

                var paramDate = command.CreateParameter();
                paramDate.ParameterName = "@data";
                paramDate.Value = data;
                command.Parameters.Add(paramDate);

                var paramLoc = command.CreateParameter();
                paramLoc.ParameterName = "@location";
                paramLoc.Value = location;
                command.Parameters.Add(paramLoc);

                var paramStart = command.CreateParameter();
                paramStart.ParameterName = "@start";
                paramStart.Value = start;
                command.Parameters.Add(paramStart);

                using (var dataR = command.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        concert = new Concert(dataR.GetInt32(0),dataR.GetString(1),dataR.GetString(2),dataR.GetInt32(3),dataR.GetInt32(4),dataR.GetInt32(5),dataR.GetString(6));
                    }
                }
            }
            log.InfoFormat("the concert found {0}",concert);
            return concert;
        }
    }
}