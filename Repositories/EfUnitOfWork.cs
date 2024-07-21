using CS_WPF_Lab9_Rental_Housing.DAL.Data;
using CS_WPF_Lab9_Rental_Housing.Domain.Entities;
using CS_WPF_Lab9_Rental_Housing.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_WPF_Lab9_Rental_Housing.DAL.Repositories
{
    /// <summary>
    /// Provides access to model repositories.
    /// </summary>
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly HousingContext context;
        private IRepository<House> housesRepository;
        private IRepository<Apartment> apartmentsRepository;
        private IRepository<Photo> photosRepository;

        public EfUnitOfWork(string connectionString)
        {
            ConnectionString = connectionString;
            context = new HousingContext(ConnectionString);
            context.Database.EnsureCreated();
        }

        public string ConnectionString { get; private set; }

        public IRepository<House> HousesRepository => housesRepository ??= new EfHousesRepository(context);

        public IRepository<Apartment> ApartmentsRepository => apartmentsRepository ??= new EfApartmentsRepository(context);

        public IRepository<Photo> PhotosRepository => photosRepository ??=new EfPhotosRepository(context);

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
