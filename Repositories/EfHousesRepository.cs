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
    /// Encapsulates CRUD operations on the Houses table.
    /// </summary>
    public class EfHousesRepository : IRepository<House>
    {
        private readonly DbSet<House> houses;

        public EfHousesRepository(HousingContext housingContext)
        {
            this.houses = housingContext.Housing;
        }

        public void Create(House entity)
        {
            houses.Add(entity);
        }

        public bool Delete(int id)
        {
            var h = houses.Find(id);
            if(h is null) return false;
            houses.Remove(h);
            return true;
        }

        public IQueryable<House> Find(Expression<Func<House, bool>> predicate)
        {
            return houses.Where(predicate);
        }

        public House Get(int id, params string[] includes)
        {
            IQueryable<House> query = houses;
            foreach(var include in includes)
            {
                query = query.Include(include);
            }
            return query.First(h=> h.HouseId == id);
        }

        public IQueryable<House> GetAll()
        {
            return houses.AsQueryable();
        }

        public void Update(House entity)
        {
            houses.Update(entity);
        }

    }
}
