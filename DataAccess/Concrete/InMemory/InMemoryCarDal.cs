using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=500,ModelYear="2007",Description="2007 Model"},
                new Car{Id=2,BrandId=1,ColorId=2,DailyPrice=150,ModelYear="2008",Description="2008 Model"},
                new Car{Id=3,BrandId=2,ColorId=3,DailyPrice=200,ModelYear="2001",Description="2001 Model"},
                new Car{Id=4,BrandId=2,ColorId=4,DailyPrice=375,ModelYear="2009",Description="2009 Model"},
                new Car{Id=5,BrandId=3,ColorId=1,DailyPrice=400,ModelYear="2000",Description="2000 Model"},


            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            _cars.Remove(_cars.SingleOrDefault(c => c.Id == car.Id));
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;      
            carToUpdate.Description = car.Description;
        }

        public void Update2(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
