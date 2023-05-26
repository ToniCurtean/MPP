using System;
using System.Security.Authentication.ExtendedProtection.Configuration;

namespace networking
{
    [Serializable]
    public class ArtistDTO
    {
        private int id;
        private string name;
        private string musicType;

        public ArtistDTO(string name, string musicType)
        {
            this.name = name;
            this.musicType = musicType;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string MusicType
        {
            get => musicType;
            set => musicType = value;
        }
    }
}