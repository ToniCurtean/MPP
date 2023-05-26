﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.model
{
    public class Entity<TID>
    {
        public TID Id { get; set; }

        public Entity(TID id)
        {
            Id = id;
        }
    }
}
