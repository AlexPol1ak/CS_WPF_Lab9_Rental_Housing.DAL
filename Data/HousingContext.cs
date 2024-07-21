using CS_WPF_Lab9_Rental_Housing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_WPF_Lab9_Rental_Housing.DAL.Data
{
    public class HousingContext : DbContext
    {
        public string ConnectionString {get; private set;}

        public HousingContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public DbSet<House> Housing { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

    }
}
