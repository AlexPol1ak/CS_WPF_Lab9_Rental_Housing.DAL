using CS_WPF_Lab9_Rental_Housing.DAL.Data;
using CS_WPF_Lab9_Rental_Housing.Domain.Entities;
using CS_WPF_Lab9_Rental_Housing.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CS_WPF_Lab9_Rental_Housing.DAL.Repositories
{
    /// <summary>
    /// Encapsulates CRUD operations on the Photos table.
    /// </summary>
    public class EfPhotosRepository : IRepository<Photo>
    {
        // Photos table
        private readonly DbSet<Photo> photos;

        public EfPhotosRepository(HousingContext housingContext)
        {
            this.photos = housingContext.Photos;
        }

        #region Basic CRUD operations
        // Realization is not needed
        public bool Contains(Photo entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create photo entity
        /// </summary>
        /// <param name="entity">Photo entity</param>
        public void Create(Photo entity)
        {
            photos.Add(entity);
        }

        /// <summary>
        /// Delete photo by ID
        /// </summary>
        /// <param name="id">Photo ID</param>
        public bool Delete(int id)
        {
            var p = photos.Find(id);
            if (p is null) return false;
            photos.Remove(p);
            return true;
        }

        /// <summary>
        /// Photo search.
        /// </summary>
        public IQueryable<Photo> Find(Expression<Func<Photo, bool>> predicate)
        {
            return photos.Where(predicate);
        }
        
        /// <summary>
        /// Get photo by ID.
        /// </summary>
        public Photo Get(int id, params string[] includes)
        {

            IQueryable<Photo> query = photos;
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
            return query.First(a => a.PhotoId == id);
        }

        /// <summary>
        /// Get all photos.
        /// </summary>
        public IQueryable<Photo> GetAll()
        {
            return photos.AsQueryable();
        }

        /// <summary>
        /// Update photo.
        /// </summary>
        public void Update(Photo entity)
        {
            photos.Update(entity);
        }

        /// <summary>
        /// Number of all photos.
        /// </summary>
        public int Count()
        {
            return photos.Count();
        }
        #endregion
    }
}
