using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.model
{
    public class Artist : Entity<int>
    {
        public string name { get; set; }

        public string musicType { get;set; }
        public Artist(int id, string name, string musicType) : base(id)
        {
            this.name = name;
            this.musicType = musicType;
        }

    }
}
