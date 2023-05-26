using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labRepositoryCs.model
{
    public class Entity<TID>
    {
        private TID id;

        public Entity(TID id) { this.id = id; }

        private TID Id
        {
            get { return id; }
            set { id = value; }
        }
        
    }
}
