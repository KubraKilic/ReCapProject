using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join customer in context.Customers
                             on rental.CustomerId equals customer.UserId
                             join user in context.Users
                             on customer.UserId equals user.Id
                             select new RentalDetailDto
                             {

                                CarBrandName=brand.BrandName,
                                CustomerFirstName=user.FirstName,
                                CustomerLastName=user.LastName,
                                RentDate=rental.RentDate,
                                ReturnDate=rental.ReturnDate,
                                CompanyName=customer.CompanyName

                             };

                   return result.ToList();        
                             
                             
            }
        }
    }
}
