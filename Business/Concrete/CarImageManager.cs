using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Images;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
       ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file,CarImage carImage)
        {

            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImage.CarId));
            if (result!=null)
            {
                return result;
            }
            carImage.ImagePath = ImageCRUD.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage1)
        {
            var carImage = _carImageDal.GetById(carImg => carImg.Id == carImage1.Id);
            carImage.ImagePath = ImageCRUD.Update(file,carImage.ImagePath);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IResult Delete(int id)
        {
            var carImage = _carImageDal.GetById(carImg => carImg.Id == id);
            ImageCRUD.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.AllCarImagesListed);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.GetById(carImg => carImg.CarId == id));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id), Messages.AllCarImagesListedByCarId);
        }

        private IResult CheckIfCarImageLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(cImg => cImg.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageCountExcededError);
            }
            return new SuccessResult();
        }

       

    }
}
