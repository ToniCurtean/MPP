using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using model;
using services;

namespace networking
{
    public class FestivalServerObjectProxy:IFestivalServices
    {

        private string host;
        private int port;

        private IFestivalObserver client;
        
        private NetworkStream stream;
		
        private IFormatter formatter;
        private TcpClient connection;

        private Queue<Response> responses;
        private volatile bool finished;
        private EventWaitHandle _waitHandle;

        public FestivalServerObjectProxy(string host,int port)
        {
            this.host = host;
            this.port = port;
            responses = new Queue<Response>();
        }
        
        public void login(string username, string passowrd, IFestivalObserver festivalObserver)
        {
            initializeConnection();
            Console.WriteLine("AIICIII!!!!");
            CashierDTO dto = DTOUtils.getDTO(new Cashier(0,username, passowrd));
            sendRequest(new LoginRequest(dto));
            Response response = readResponse();
            if (response is OkResponse)
            {
                this.client = festivalObserver;
                return;
            }
            if (response is ErrorResponse)
            {
                ErrorResponse err =(ErrorResponse)response;
                closeConnection();
                throw new FestivalException(err.Message);
            }
        }

        public Artist findOne(int id)
        {
            Console.WriteLine("aici mor!");
            sendRequest(new FindArtist(id));
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new FestivalException(err.Message);
            }

            GetArtistResponse resp = (GetArtistResponse)response;
            ArtistDTO dto = resp.Artist;
            Artist artist = DTOUtils.getFromDTO(dto);
            return artist;
        }

        public IEnumerable<Concert> findAllConcerts()
        {
            Console.WriteLine("SUNT IN FIND ALL CONCERTS");
            sendRequest(new GetListConcerts());
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new FestivalException(err.Message);
            }

            GetListConcertResponse resp = (GetListConcertResponse)response;
            ConcertDTO[] dto = resp.Concerts;
            Concert[] concerts = DTOUtils.getFromDTO(dto);
            return concerts;
        }
        
        public IList<ConcertInfo> getConcertInfos()
        {
            sendRequest(new GetConcertInfos());
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new FestivalException(err.Message);
            }

            GetConcertInfoResponse resp = (GetConcertInfoResponse)response;
            ConcertInfoDTO[] dtos = resp.Infos;
            ConcertInfo[] concertInfos = DTOUtils.getFromDTO(dtos);
            return concertInfos;
        }

        public IList<ConcertInfo> getConcertInfosByDate(string date)
        {
            sendRequest(new GetConcertInfosByDate(date));
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new FestivalException(err.Message);
            }

            GetConcertInfoByDateResponse resp = (GetConcertInfoByDateResponse)response;
            ConcertInfoDTO[] dtos = resp.Infos;
            ConcertInfo[] concertInfos = DTOUtils.getFromDTO(dtos);
            return concertInfos;
        }

        public IEnumerable<Concert> getConcertsByDate(string date)
        {
            sendRequest(new GetListConcertsByDate(date));
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new FestivalException(err.Message);
            }

            GetListConcertByDateResponse resp = (GetListConcertByDateResponse)response;
            ConcertDTO[] dto = resp.Concerts;
            Concert[] concerts = DTOUtils.getFromDTO(dto);
            return concerts;
        }

        public Concert getConcertByDateLocationStart(string date, string location, string startTime)
        {
            sendRequest(new FindConcertDLS(date,location,startTime));
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new FestivalException(err.Message);
            }

            GetConcertDLSResponse resp = (GetConcertDLSResponse)response;
            ConcertDTO dto = resp.Concert;
            Concert concert = DTOUtils.getFromDTO(dto);
            return concert;
        }

        public Concert updateConcertTickets(int id, int numberOfTickets)
        {
            sendRequest(new UpdateConcertTickets(id,numberOfTickets));
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new FestivalException(err.Message);
            }

            UpdatedConcertTicketsResponse resp = (UpdatedConcertTicketsResponse)response;
            ConcertDTO dto = resp.Concert;
            Concert concert = DTOUtils.getFromDTO(dto);
            return concert;
        }

        public void save(int concertID, string buyerName, int numberOfTickets)
        {
            OrderDTO dto = DTOUtils.getDTO(new Order(0, concertID, buyerName, numberOfTickets));
            sendRequest(new AddOrder(dto));
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new FestivalException(err.Message);
            }
        }

        public void logout(Cashier cashier, IFestivalObserver client)
        {
            CashierDTO udto =DTOUtils.getDTO(cashier);
            sendRequest(new LogoutRequest(udto));
            Response response =readResponse();
            closeConnection();
            if (response is ErrorResponse)
            {
                ErrorResponse err =(ErrorResponse)response;
                throw new FestivalException(err.Message);
            }
        }
        

        private void closeConnection()
        {
            finished=true;
            try
            {
                stream.Close();
			
                connection.Close();
                _waitHandle.Close();
                client=null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }
        
        private void sendRequest(Request request)
        {
            try
            {
                formatter.Serialize(stream, request);
                stream.Flush();
            }
            catch (Exception e)
            {
                throw new FestivalException("Error sending object "+e);
            }

        }

        private Response readResponse()
        {
            Response response =null;
            try
            {
                _waitHandle.WaitOne();
                lock (responses)
                {
                    //Monitor.Wait(responses); 
                    response = responses.Dequeue();
                
                }
				

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return response;
        }
        
        
        private void initializeConnection()
        {
            try
            {
                connection=new TcpClient(host,port);
                stream=connection.GetStream();
                formatter = new BinaryFormatter();
                finished=false;
                _waitHandle = new AutoResetEvent(false);
                startReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        private void startReader()
        {
            Thread tw =new Thread(run);
            tw.Start();
        }
        
        public virtual void run()
        {
            while(!finished)
            {
                try
                {
                    object response = formatter.Deserialize(stream);
                    Console.WriteLine("response received "+response);
                    if (response is UpdateResponse)
                    {
                        handleUpdate((UpdateResponse)response);
                    }
                    else
                    {
							
                        lock (responses)
                        {
                                					
								 
                            responses.Enqueue((Response)response);
                               
                        }
                        _waitHandle.Set();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Reading error "+e);
                }
					
            }
        }

        private void handleUpdate(UpdateResponse response)
        {
            if (response is AddedOrderResponse)
            {
                ///AddedOrderResponse resp = (AddedOrderResponse)response;
                ///ConcertInfoDTO[] dtos = resp.Infos;
                ///ConcertInfo[] infos = DTOUtils.getFromDTO(dtos);
                try
                {
                    client.Update();
                }
                catch (FestivalException e)
                {
                    Console.WriteLine("IN UPDATE LISTA");
                    Console.WriteLine(e.StackTrace);
                }
            }
        }
    }
}