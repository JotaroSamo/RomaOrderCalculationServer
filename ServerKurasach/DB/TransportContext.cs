using Server.DB.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerKurasach.DB.Content;

namespace Server.DB
{
  class TransportContext:DbContext
    {
        public TransportContext()
        {
            Database.EnsureCreated();
        }


        public DbSet<Country> Countries { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Transport;Trusted_Connection=True;");
        }
    }
}
