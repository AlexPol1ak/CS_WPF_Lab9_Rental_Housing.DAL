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
    public class EfHousesRepository : IRepository<House>
    {
        private readonly DbSet<House> houses;

        public EfHousesRepository(HousingContext housingContext)
        {
            this.houses = housingContext.Housing;
        }

        public void Create(House entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<House> Find(Expression<Func<House, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public House Get(int id, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public IQueryable<House> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(House entity)
        {
            throw new NotImplementedException();
        }
    }
}
