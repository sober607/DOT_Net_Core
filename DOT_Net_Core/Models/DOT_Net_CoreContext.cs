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

        public DbSet<News> News { get; set; }

        public DbSet<WorldPart> WorldParts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorldPart>().HasData(
                new WorldPart
                {
                    Id = 1,
                    Name = "Asia"

                },

                                new WorldPart
                                {
                                    Id = 2,
                                    Name = "Australia"

                                },

                                                                new WorldPart
                                                                {
                                                                    Id = 6,
                                                                    Name = "America"

                                                                },
                new WorldPart
                {
                    Id = 3,
                    Name = "Africa"

                },

                                new WorldPart
                                {
                                    Id = 4,
                                    Name = "Europe"

                                },

                                                                new WorldPart
                                                                {
                                                                    Id = 5,
                                                                    Name = "Antarctic"

                                                                }

                );
        }

    }
}
