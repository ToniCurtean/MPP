using System;
using System.Collections.Generic;
using model;

namespace networking
{
    [Serializable]
    public class ListDTO
    {
        private List<Concert> concerts;
        
        public ListDTO(List<Concert> concerts) {
            this.concerts = concerts;
        }

        public List<Concert> Concerts
        {
            get { return this.concerts; }
            set { this.concerts = value; }
        }
    }
}