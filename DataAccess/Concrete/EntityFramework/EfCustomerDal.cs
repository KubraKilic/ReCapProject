using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapDatabaseContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                var result = from customer in context.Customers
                             join user in context.Users
                             on customer.UserId equals user.Id
                             select new CustomerDetailDto
                             {
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 CompanyName = customer.CompanyName
                             };

                return result.ToList();

            }

        }
    }
}

