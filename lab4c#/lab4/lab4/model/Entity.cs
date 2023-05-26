using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.model
{
    public class Entity<TID>
    {
        public TID id {  get; set; }

        public Entity(TID id) { this.id = id; }


    }
}
