using CS_WPF_Lab9_Rental_Housing.DAL.Data;
using CS_WPF_Lab9_Rental_Housing.Domain.Entities;
using CS_WPF_Lab9_Rental_Housing.Domain.Interfaces;

namespace CS_WPF_Lab9_Rental_Housing.DAL.Repositories
{
    /// <summary>
    /// Provides access to model repositories.
    /// </summary>
    public class EfUnitOfWork : IUnitOfWork
    {
        public string ConnectionString { get; private set; }
        private readonly HousingContext context;
        #region Repositories
        private IRepository<House> housesRepository;
        private IRepository<Apartment> apartmentsRepository;
        private IRepository<Photo> photosRepository;
        
        public IRepository<House> HousesRepository
            => housesRepository ??= new EfHousesRepository(context);

        public IRepository<Apartment> ApartmentsRepository
            => apartmentsRepository ??= new EfApartmentsRepository(context);

        public IRepository<Photo> PhotosRepository
            => photosRepository ??= new EfPhotosRepository(context);
        #endregion

        public EfUnitOfWork(string connectionString)
        {
            ConnectionString = connectionString;
            context = new HousingContext(ConnectionString);
            context.Database.EnsureCreated();
        }

        /// <summary>
        /// Saves changes to tables.
        /// </summary>
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
