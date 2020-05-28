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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name="US", Population = 328231233, SickCount = 164741, DeadCount=97811, RecoveredCount = 289329, Vaccine = false }
                );

            modelBuilder.Entity<Human>().HasData(
                new Human { Id = 1, FirstName = "Obi-wan", LastName = "Kenobi", Age = 38, IsSick = false, Gender = "Male", CountryId = 1 },
                new Human { Id = 2, FirstName = "Sanwise", LastName = "Gamgee", Age = 54, IsSick = false, Gender = "Male", CountryId = 1 }
                );
        }

    }
}
