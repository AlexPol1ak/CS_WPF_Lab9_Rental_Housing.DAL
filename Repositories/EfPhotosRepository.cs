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
    public class EfPhotosRepository : IRepository<Photo>
    {
        private readonly DbSet<Photo> photos;

        public EfPhotosRepository(HousingContext housingContext)
        {
            this.photos = housingContext.Photos;
        }

        public void Create(Photo entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Photo> Find(Expression<Func<Photo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Photo Get(int id, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Photo> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Photo entity)
        {
            throw new NotImplementedException();
        }
    }
}
