namespace model
{
    public class Entity<TID>
    {
        private TID id;

        public Entity(TID id)
        {
            this.id = id;
        }

        public TID Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
    }
}