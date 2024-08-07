using CS_WPF_Lab9_Rental_Housing.DAL.Data;
using CS_WPF_Lab9_Rental_Housing.Domain.Entities;
using CS_WPF_Lab9_Rental_Housing.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CS_WPF_Lab9_Rental_Housing.DAL.Repositories
{
    /// <summary>
    /// Encapsulates CRUD operations on the Houses table.
    /// </summary>
    public class EfHousesRepository : IRepository<House>
    {
        // Table of houses.
        private readonly DbSet<House> houses;

        public EfHousesRepository(HousingContext housingContext)
        {
            this.houses = housingContext.Housing;
        }

        #region Basic CRUD operations
        /// <summary>
        /// Create house
        /// </summary>
        /// <param name="entity"> House entity</param>
        public void Create(House entity)
        {
            houses.Add(entity);
        }

        /// <summary>
        /// Delete a house by ID.
        /// </summary>
        /// <param name="id">House ID</param>
        /// <returns>False if the record is not found otherwise True</returns>
        public bool Delete(int id)
        {
            var h = houses.Find(id);
            if (h is null) return false;
            houses.Remove(h);
            return true;
        }

        /// <summary>
        /// Houses search
        /// </summary>
        /// <param name="predicate"></param>
        public IQueryable<House> Find(Expression<Func<House, bool>> predicate)
        {
            return houses.Where(predicate);
        }

        /// <summary>
        /// Get house by ID.
        /// </summary>
        /// <param name="id">House ID</param>
        /// <param name="includes"></param>
        public House Get(int id, params string[] includes)
        {
            IQueryable<House> query = houses;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.First(h => h.HouseId == id);
        }

        /// <summary>
        /// Get all houses.
        /// </summary>
        /// <returns>All houses</returns>
        public IQueryable<House> GetAll()
        {
            return houses.AsQueryable();
        }

        /// <summary>
        /// Update house.
        /// </summary>
        /// <param name="entity">House entity</param>
        public void Update(House entity)
        {
            houses.Update(entity);
        }

        /// <summary>
        /// Check to see if there's one at home.
        /// </summary>
        /// <param name="entity">House entity</param>
        public bool Contains(House entity)
        {
            return houses.Contains(entity);
        }

        /// <summary>
        /// Get the number of all houses.
        /// </summary>
        /// <returns> Number of all houses</returns>
        public int Count()
        {
            return houses.Count();
        }
        #endregion
    }
}
