using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(int id)
        {

             _carDal.Delete(_carDal.Get(c=>c.Id==id));
            return new SuccessResult(Messages.CarDeleted);
        }


        [PerformanceAspect(5)]
        [CacheAspect]  
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.AllCarsListed);
        }


        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return  new SuccessDataResult<Car>( _carDal.Get(c=>c.Id==id));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.BrandId==brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return  new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailById(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c=>c.CarId==carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var carDetails = _carDal.GetCarDetails();
            foreach (var car in carDetails)
            {
                if (car.ImagePath==null)
                {
                    car.ImagePath= @"\WebAPI\Resources\Images\logo.jpg";
                }
            }
            return new SuccessDataResult<List<CarDetailDto>>(carDetails);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c=>c.BrandId==brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId));
        }

        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IResult Update2(Car car)
        {
            _carDal.Update2(car);
            return new SuccessResult(Messages.CarUpdated);
         
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Car car)
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarUpdatedByTransaction);
          
        }


    }
}
