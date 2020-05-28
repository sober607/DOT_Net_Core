using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DOT_Net_Core.Models
{
    public class DOT_Net_CoreContext : DbContext
    {

        public DOT_Net_CoreContext(DbContextOptions options) : base(options)
        {


        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Human> Humans { get; set; }

       

    }
}
