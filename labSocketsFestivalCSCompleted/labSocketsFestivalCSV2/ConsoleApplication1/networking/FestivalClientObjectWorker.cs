using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using model;
using services;

namespace networking
{
    public class FestivalClientObjectWorker:IFestivalObserver
    {
        private IFestivalServices server;
        private TcpClient connection;

        private NetworkStream stream;
        private IFormatter formatter;
        private volatile bool connected;
        
        public FestivalClientObjectWorker(IFestivalServices server, TcpClient connection)
        {
            this.server = server;
            this.connection = connection;
            try
            {
				
                stream=this.connection.GetStream();
                formatter = new BinaryFormatter();
                connected=true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        
        public virtual void run()
        {
            while(connected)
            {
                try
                {
                    object request = formatter.Deserialize(stream);
                    object response =handleRequest((Request)request);
                    if (response!=null)
                    {
                        sendResponse((Response) response);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
				
                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            try
            {
                stream.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error "+e);
            }
        }

        private Response handleRequest(Request request)
        {
            Response response =null;
            if (request is LoginRequest)
            {
                Console.WriteLine("Login request ...");
                LoginRequest logReq =(LoginRequest)request;
                CashierDTO udto =logReq.Cashier;
                Cashier cashier =DTOUtils.getFromDTO(udto);
                try
                {
                    lock (server)
                    {
                        server.login(cashier.Username,cashier.Password,this);
                    }
                    return new OkResponse();
                }
                catch (FestivalException e)
                {
                    connected=false;
                    return new ErrorResponse(e.Message);
                }
            }
            if (request is LogoutRequest)
            {
                Console.WriteLine("Logout request");
                LogoutRequest logReq =(LogoutRequest)request;
                CashierDTO udto =logReq.Cashier;
                Cashier cashier =DTOUtils.getFromDTO(udto);
                try
                {
                    lock (server)
                    {

                        server.logout(cashier, this);
                    }
                    connected=false;
                    return new OkResponse();

                }
                catch (FestivalException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is GetListConcerts)
            {
                GetListConcerts req = (GetListConcerts)request;
                try
                {
                    lock (server)
                    {
                        IList<Concert> concertsList = new List<Concert>(server.findAllConcerts());
                        Concert[] concerts = concertsList.ToArray();
                        ConcertDTO[] dtos = DTOUtils.getDTO(concerts);
                        return new GetListConcertResponse(dtos);
                    }
                }
                catch (FestivalException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is GetListConcertsByDate)
            {
                GetListConcertsByDate req = (GetListConcertsByDate)request;
                try
                {
                    Concert[] concerts;
                    lock (server)
                    {
                        concerts = (Concert[])server.getConcertsByDate(req.Data);
                    }

                    ConcertDTO[] dtos = DTOUtils.getDTO(concerts);
                    return new GetListConcertByDateResponse(dtos);
                }
                catch (FestivalException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is FindArtist)
            {
                FindArtist req = (FindArtist)request;
                int artistId = req.Id;
                try
                {
                    lock (server)
                    {
                        Artist artist = server.findOne(artistId);
                        ArtistDTO dto = DTOUtils.getDTO(artist);
                        return new GetArtistResponse(dto);
                    }
                }
                catch (FestivalException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is FindConcertDLS)
            {
                FindConcertDLS req = (FindConcertDLS)request;
                try
                {
                    Concert concert;
                    lock (server)
                    {
                        concert = server.getConcertByDateLocationStart(req.Date, req.Location, req.StartTime);
                    }

                    ConcertDTO dto = DTOUtils.getDTO(concert);
                    return new GetConcertDLSResponse(dto);
                }
                catch (FestivalException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is AddOrder)
            {
                AddOrder req = (AddOrder)request;
                try
                {
                    lock (server)
                    {
                        OrderDTO dto = req.Order;
                        Order order = DTOUtils.getFromDTO(dto);
                        server.save(order.ConcertId, order.BuyerName, order.NumberOfTickets);
                    }

                    return new OkResponse();
                }
                catch (FestivalException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is UpdateConcertTickets)
            {
                UpdateConcertTickets req = (UpdateConcertTickets)request;
                try
                {
                    Concert concert;
                    lock (server)
                    {
                        concert = server.updateConcertTickets(req.Id, req.NrOfTickets);
                    }

                    ConcertDTO dto = DTOUtils.getDTO(concert);
                    return new UpdatedConcertTicketsResponse(dto);
                }
                catch (FestivalException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is GetConcertInfos)
            {
                GetConcertInfos req = (GetConcertInfos)request;
                try
                {
                    IList<ConcertInfo> concertsInfoList = new List<ConcertInfo>(server.getConcertInfos());
                    ConcertInfo[] concertInfos = concertsInfoList.ToArray();
                    ConcertInfoDTO[] dtos = DTOUtils.getDTO(concertInfos);
                    return new GetConcertInfoResponse(dtos);
                }
                catch (FestivalException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is GetConcertInfosByDate)
            {
                GetConcertInfosByDate req = (GetConcertInfosByDate)request;
                try
                {
                    IList<ConcertInfo> concertsInfoList = new List<ConcertInfo>(server.getConcertInfosByDate(req.Data));
                    ConcertInfo[] concertInfos = concertsInfoList.ToArray();
                    ConcertInfoDTO[] dtos = DTOUtils.getDTO(concertInfos);
                    return new GetConcertInfoByDateResponse(dtos);
                }
                catch (FestivalException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }
            return response;
        }
        
        public void Update()
        {
            
            ///ConcertInfoDTO[] dtos = DTOUtils.getDTO(concertInf);
            try
            {
                sendResponse(new AddedOrderResponse());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        private void sendResponse(Response response)
        {
            Console.WriteLine("sending response "+response);
            lock (stream)
            {
                formatter.Serialize(stream, response);
                stream.Flush();
            }

        }
    
    }
}