﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {

                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 BrandId=car.BrandId,
                                 ColorId=car.ColorId,
                                 CarName = car.CarName,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 Description=car.Description
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }

        public void Update2(Car car)
        {

            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                Car updatedCar = context.Set<Car>().SingleOrDefault(c => c.Id == car.Id);
                if (car.CarName != null)
                {
                    updatedCar.CarName = car.CarName;
                }
                if (car.BrandId != 0)
                {
                    updatedCar.BrandId = car.BrandId;
                }
                if (car.ColorId != 0)
                {
                    updatedCar.ColorId = car.ColorId;
                }
                if (car.DailyPrice != 0)
                {
                    updatedCar.DailyPrice = car.DailyPrice;
                }
                if (car.Description != null)
                {
                    updatedCar.Description = car.Description;
                }
                var updatedEntity = context.Entry(updatedCar);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
