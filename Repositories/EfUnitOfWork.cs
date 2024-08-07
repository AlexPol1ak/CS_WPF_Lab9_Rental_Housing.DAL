using CS_WPF_Lab9_Rental_Housing.DAL.Data;
using CS_WPF_Lab9_Rental_Housing.Domain.Entities;
using CS_WPF_Lab9_Rental_Housing.Domain.Interfaces;
using System.Linq.Expressions;

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

        /// <summary>
        /// Loads related entities
        /// </summary>
        /// <typeparam name="T">Primary entity type.</typeparam>
        /// <typeparam name="TProperty">Dependent entity Type.</typeparam>
        /// <param name="entity">Dependent Entity Type.</param>
        /// <param name="navigationProperty">
        /// An expression indicating a collection of related entities
        /// </param>
        public void LoadRelatedEntities<T, TProperty>(T entity, Expression<Func<T, IEnumerable<TProperty>>> navigationProperty)
                 where T : class
                 where TProperty : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (navigationProperty == null)
            {
                throw new ArgumentNullException(nameof(navigationProperty));
            }

            context.Entry(entity).Collection(navigationProperty).Load();
        }
    }
}
