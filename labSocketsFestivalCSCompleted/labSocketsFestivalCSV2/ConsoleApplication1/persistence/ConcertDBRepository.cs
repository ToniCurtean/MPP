using System;
using System.Collections.Generic;
using System.Data;
using model;

namespace persistence
{
    public class ConcertDBRepository:IConcertRepository
    {
        
        private IDictionary<string, string> props;

        public ConcertDBRepository(IDictionary<string, string> props)
        {
            this.props = props;
        }
        
        public void Save(Concert entity)
        {
            throw new System.NotImplementedException();
        }

        public Concert FindOne(int id)
        {
            var connection = DbUtils.getConnection(props);
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from concerts where id=@id";

                var paramID = command.CreateParameter();
                paramID.ParameterName = "@id";
                paramID.Value = id;
                command.Parameters.Add(paramID);

                using (var dataR = command.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        Concert concert = new Concert(dataR.GetInt32(0), dataR.GetString(1), dataR.GetString(2),
                            dataR.GetInt32(3), dataR.GetInt32(4), dataR.GetInt32(5), dataR.GetString(6));
                        return concert;
                    }
                }
            }
            return null;
        }

        public IEnumerable<Concert> FindAll()
        {
            var connection = DbUtils.getConnection(props);
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
            return concerts;
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, Concert e)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Concert> GetConcertsByDate(string date)
        {
            var connection = DbUtils.getConnection(props);
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
            return concerts;
        }

        public void UpdateConcertTickets(int id, int newTicketsAvailable, int newTicketsSold)
        {
            var connection = DbUtils.getConnection(props);
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
                    throw new Exception("Not updated!");
                }
            }
        }

        public Concert getConcertByDateLocationStart(string date, string location, string start)
        {
            
            var connection = DbUtils.getConnection(props);
            using (var command = connection.CreateCommand())
            {
                command.CommandText="SELECT * FROM concerts where date=@data and concertLocation=@location and startTime=@start";

                var paramDate = command.CreateParameter();
                paramDate.ParameterName = "@data";
                paramDate.Value = date;
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
                    if (dataR.Read())
                    {
                        Concert concert = new Concert(dataR.GetInt32(0),dataR.GetString(1),dataR.GetString(2),dataR.GetInt32(3),dataR.GetInt32(4),dataR.GetInt32(5),dataR.GetString(6));
                        return concert;
                    }
                }
            }
            return null;
        }

        public IList<ConcertInfo> getConcertInfos()
        {
            IList<ConcertInfo> concertInfo = new List<ConcertInfo>();
            IDbConnection connection = DbUtils.getConnection(props);
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText =
                    "select A.name,C.id,C.concertDate,C.concertLocation,C.ticketsAvailable,C.ticketsSold," +
                    "C.startingTime from concerts C inner join artists A on C.artistID=A.id";
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        string artist = dataR.GetString(0);
                        int concertId = dataR.GetInt32(1);
                        string date = dataR.GetString(2);
                        string location = dataR.GetString(3);
                        int ticketsAvailable = dataR.GetInt32(4);
                        int ticketsSold = dataR.GetInt32(5);
                        string startTime = dataR.GetString(6);
                        ConcertInfo concertInf = new ConcertInfo(artist, concertId, date, location, ticketsAvailable, ticketsSold, startTime);
                        concertInfo.Add(concertInf);
                    }
                }
            }
            return concertInfo;
        }

        public IList<ConcertInfo> getConcertInfosByDate(string data)
        {
            IList<ConcertInfo> concertInfo = new List<ConcertInfo>();
            IDbConnection connection = DbUtils.getConnection(props);
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText =
                    "select A.name,C.id,C.concertDate,C.concertLocation,C.ticketsAvailable,C.ticketsSold," +
                    "C.startingTime from concerts C inner join artists A on C.artistID=A.id where C.concertDate=@date";

                var parDate = comm.CreateParameter();
                parDate.ParameterName = "@date";
                parDate.Value = data;
                comm.Parameters.Add(parDate);
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        string artist = dataR.GetString(0);
                        int concertId = dataR.GetInt32(1);
                        string date = dataR.GetString(2);
                        string location = dataR.GetString(3);
                        int ticketsAvailable = dataR.GetInt32(4);
                        int ticketsSold = dataR.GetInt32(5);
                        string startTime = dataR.GetString(6);
                        ConcertInfo concertInf = new ConcertInfo(artist, concertId, date, location, ticketsAvailable, ticketsSold, startTime);
                        concertInfo.Add(concertInf);
                    }
                }
            }
            return concertInfo;
        }
    }
}