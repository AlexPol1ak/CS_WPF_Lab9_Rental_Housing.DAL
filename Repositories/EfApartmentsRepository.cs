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
    /// Encapsulates CRUD operations on the Apartments table.
    /// </summary>
    public class EfApartmentsRepository : IRepository<Apartment>
    {
        private readonly DbSet<Apartment> apartments;

        public EfApartmentsRepository(HousingContext housingContext)
        {
            this.apartments = housingContext.Apartments;
        }

        public bool Contains(Apartment entity)
        {
            return apartments.Contains(entity);
        }

        public void Create(Apartment entity)
        {
            apartments.Add(entity);
        }

        public bool Delete(int id)
        {
            var a = apartments.Find(id);
            if(a is  null) return false;
            apartments.Remove(a);
            return true;
        }

        public IQueryable<Apartment> Find(Expression<Func<Apartment, bool>> predicate)
        {
            return apartments.Where(predicate);
        }

        public Apartment Get(int id, params string[] includes)
        {
            IQueryable<Apartment> query = apartments;
            foreach(string include in includes)
            {
                query = query.Include(include);
            }
             return query.First(a=>a.ApartmentId == id);
        }

        public IQueryable<Apartment> GetAll()
        {
            return apartments.AsQueryable();
        }

        public void Update(Apartment entity)
        {
            apartments.Update(entity);
        }
    }
}
