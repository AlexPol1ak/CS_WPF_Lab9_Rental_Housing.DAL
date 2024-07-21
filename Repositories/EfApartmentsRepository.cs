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
    public class EfApartmentsRepository : IRepository<Apartment>
    {
        private readonly DbSet<Apartment> apartments;

        public EfApartmentsRepository(HousingContext housingContext)
        {
            this.apartments = housingContext.Apartments;
        }

        public void Create(Apartment entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Apartment> Find(Expression<Func<Apartment, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Apartment Get(int id, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Apartment> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Apartment entity)
        {
            throw new NotImplementedException();
        }
    }
}
