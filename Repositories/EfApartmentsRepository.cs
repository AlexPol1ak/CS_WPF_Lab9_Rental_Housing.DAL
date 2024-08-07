using CS_WPF_Lab9_Rental_Housing.DAL.Data;
using CS_WPF_Lab9_Rental_Housing.Domain.Entities;
using CS_WPF_Lab9_Rental_Housing.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CS_WPF_Lab9_Rental_Housing.DAL.Repositories
{
    /// <summary>
    /// Encapsulates CRUD operations on the Apartments table.
    /// </summary>
    public class EfApartmentsRepository : IRepository<Apartment>
    {
        // Apartments table
        private readonly DbSet<Apartment> apartments;

        public EfApartmentsRepository(HousingContext housingContext)
        {
            this.apartments = housingContext.Apartments;
        }

        #region Basic CRUD operations
        /// <summary>
        /// Check to see if there's an apartment
        /// </summary>
        public bool Contains(Apartment entity)
        {
            return apartments.Contains(entity);
        }

        /// <summary>
        /// Creat apartment
        /// </summary>
        /// <param name="entity">Apartment entity</param>
        public void Create(Apartment entity)
        {
            apartments.Add(entity);
        }

        /// <summary>
        /// Delete apartment by ID/
        /// </summary>
        /// <param name="id">Apartment ID</param>
        public bool Delete(int id)
        {
            var a = apartments.Find(id);
            if (a is null) return false;
            apartments.Remove(a);
            return true;
        }

        /// <summary>
        /// Apartment search
        /// </summary>
        public IQueryable<Apartment> Find(Expression<Func<Apartment, bool>> predicate)
        {
            return apartments.Where(predicate);
        }

        /// <summary>
        /// Get an apartment by ID
        /// </summary>
        /// <param name="id">Apartment ID</param>
        public Apartment Get(int id, params string[] includes)
        {
            IQueryable<Apartment> query = apartments;
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
            return query.First(a => a.ApartmentId == id);
        }
        /// <summary>
        /// Get all the apartments.
        /// </summary>
        public IQueryable<Apartment> GetAll()
        {
            return apartments.AsQueryable();
        }

        /// <summary>
        /// Update apartments.
        /// </summary>
        /// <param name="entity"></param>
        public void Update(Apartment entity)
        {
            apartments.Update(entity);
        }

        /// <summary>
        /// The number of all apartments.
        /// </summary>
        public int Count()
        {
            return apartments.Count();
        }
        #endregion
    }
}
