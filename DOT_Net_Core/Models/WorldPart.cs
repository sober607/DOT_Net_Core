﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOT_Net_Core.Models
{
    public class WorldPart
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Country> Countries { get; set; }

    }
}
