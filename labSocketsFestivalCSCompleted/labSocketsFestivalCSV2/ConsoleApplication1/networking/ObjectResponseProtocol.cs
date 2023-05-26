using System;
using model;

namespace networking
{
    public interface Response
    {
    }

    [Serializable]
    public class OkResponse : Response
    {
        
    }

    [Serializable]
    public class ErrorResponse : Response
    {
        private string message;

        public ErrorResponse(string message)
        {
            this.message = message;
        }

        public virtual string Message
        {
            get
            {
                return message;
            }
        }
    }

    [Serializable]
    public class GetListConcertResponse : Response
    {
        private ConcertDTO[] concerts;

        public GetListConcertResponse(ConcertDTO[] concerts)
        {
            this.concerts = concerts;
        }

        public virtual ConcertDTO[] Concerts
        {
            get
            {
                return this.concerts;
            }
        }
    }

    [Serializable]
    public class GetConcertInfoResponse : Response
    {
        private ConcertInfoDTO[] infos;

        public GetConcertInfoResponse(ConcertInfoDTO[] infos)
        {
            this.infos = infos;
        }

        public virtual ConcertInfoDTO[] Infos
        {
            get
            {
                return this.infos;
            }
        }
        
    }

    [Serializable]
    public class GetConcertInfoByDateResponse : Response
    {
        private ConcertInfoDTO[] infos;

        public GetConcertInfoByDateResponse(ConcertInfoDTO[] infos)
        {
            this.infos = infos;
        }

        public virtual ConcertInfoDTO[] Infos
        {
            get
            {
                return this.infos;
            }
        }
    }

    [Serializable]
    public class GetListConcertByDateResponse : Response
    {
        private ConcertDTO[] concerts;

        public GetListConcertByDateResponse(ConcertDTO[] concerts)
        {
            this.concerts = concerts;
        }

        public virtual ConcertDTO[] Concerts
        {
            get
            {
                return this.concerts;
            }
        }
    }
    
    [Serializable]
    public class GetConcertDLSResponse:Response
    {
        private ConcertDTO concert;

        public GetConcertDLSResponse(ConcertDTO concertDto)
        {
            this.concert = concertDto;
        }

        public virtual ConcertDTO Concert
        {
            get
            {
                return this.concert;
            }
        }
    }

    [Serializable]
    public class GetArtistResponse : Response
    {
        private ArtistDTO artist;

        public GetArtistResponse(ArtistDTO artist)
        {
            this.artist = artist;
        }

        public virtual ArtistDTO Artist
        {
            get
            {
                return this.artist;
            }
        }
    }

    [Serializable]
    public class OrderAddedResponse : Response
    {
        private OrderDTO order;

        public OrderAddedResponse(OrderDTO order)
        {
            this.order = order;
        }

        public virtual OrderDTO Order
        {
            get
            {
                return this.order;
            }
        }
    }

    [Serializable]
    public class UpdatedConcertTicketsResponse : Response
    {
        private ConcertDTO concert;

        public UpdatedConcertTicketsResponse(ConcertDTO dto)
        {
            this.concert = dto;
        }

        public virtual ConcertDTO Concert
        {
            get
            {
                return this.concert;
            }
        }
    }
    
    public interface UpdateResponse : Response
    {
    }
    
    [Serializable]
    public class AddedOrderResponse : UpdateResponse
    {
        
    }
    
}