namespace model
{
    public class Artist:Entity<int>
    {
        private string name;

        private string musicType;
        
        public Artist(int id) : base(id)
        {
        }

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