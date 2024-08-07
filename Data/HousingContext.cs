using CS_WPF_Lab9_Rental_Housing.DAL.Data.ModelConfigurations;
using CS_WPF_Lab9_Rental_Housing.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CS_WPF_Lab9_Rental_Housing.DAL.Data
{
    /// <summary>
    /// Table Context.
    /// </summary>
    public class HousingContext : DbContext
    {
        public string ConnectionString { get; private set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuration of tables.
            modelBuilder.ApplyConfiguration(new HouseConfig());
            modelBuilder.ApplyConfiguration(new ApartmentConfig());
            modelBuilder.ApplyConfiguration(new PhotoConfig());

            base.OnModelCreating(modelBuilder);
        }

    }
}
