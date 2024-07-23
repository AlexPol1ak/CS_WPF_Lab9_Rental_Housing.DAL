using CS_WPF_Lab9_Rental_Housing.DAL.Data;
using CS_WPF_Lab9_Rental_Housing.Domain.Entities;
using CS_WPF_Lab9_Rental_Housing.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CS_WPF_Lab9_Rental_Housing.DAL.Repositories
{
    /// <summary>
    /// Encapsulates CRUD operations on the Photos table.
    /// </summary>
    public class EfPhotosRepository : IRepository<Photo>
    {
        private readonly DbSet<Photo> photos;

        public EfPhotosRepository(HousingContext housingContext)
        {
            this.photos = housingContext.Photos;
        }

        public bool Contains(Photo entity)
        {
            throw new NotImplementedException();
        }

        public void Create(Photo entity)
        {
            photos.Add(entity);
        }

        public bool Delete(int id)
        {
            var p = photos.Find(id);
            if (p is null) return false;
            photos.Remove(p);
            return true;
        }

        public IQueryable<Photo> Find(Expression<Func<Photo, bool>> predicate)
        {
            return photos.Where(predicate);
        }

        public Photo Get(int id, params string[] includes)
        {

            IQueryable<Photo> query = photos;
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
            return query.First(a => a.PhotoId == id);
        }

        public IQueryable<Photo> GetAll()
        {
            return photos.AsQueryable();
        }

        public void Update(Photo entity)
        {
            photos.Update(entity);
        }

        public int Count()
        {
            return photos.Count();
        }
    }
}
