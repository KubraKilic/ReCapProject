using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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


        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //business codes

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }

        public IResult Delete(int id)
        {
             _carDal.Delete(_carDal.GetById(c=>c.Id==id));
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.AllCarsListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return  new SuccessDataResult<Car>( _carDal.GetById(c=>c.Id==id));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.BrandId==brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return  new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var carDetails = _carDal.GetCarDetails();
            foreach (var car in carDetails)
            {
                if (car.ImagePath==null)
                {
                    car.ImagePath= Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\WebAPI\Images\logo.jpg");
                }
            }
            return new SuccessDataResult<List<CarDetailDto>>(carDetails);
        }

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
    }
}
