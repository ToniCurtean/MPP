using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.model
{
    public class Artist : Entity<int>
    {
        private string  name;

        private string musicType;
        public Artist(int id, string name, string musicType) : base(id)
        {
            this.name = name;
            this.musicType = musicType;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string MusicType
        {
            get { return MusicType; }
            set { musicType = value; }
        }
    }
}
