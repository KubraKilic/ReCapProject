using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapDatabaseContext>, IRentalDal
    {
        public bool CheckCantRentable(int id)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                bool checkRentable = context.Set<Rental>().Any(r => r.CarId == id && r.ReturnDate == null);
                return checkRentable;
            }
        }

        public bool CheckCar(int id)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                bool checkCar = context.Set<Car>().Any(r => r.Id == id);
                return checkCar;
            }
        }
    }
}
