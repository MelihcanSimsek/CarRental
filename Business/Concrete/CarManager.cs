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
using System.Linq;
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

        [SecuredOperation("Car.add,Admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.get")]
        public IResult Add(Car car)
        {
                _carDal.Add(car);
                return new SuccessResult(Message.CarAdded);
     
        }
        
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if(car.DailyPrice<10)
            {
                throw new Exception("test");
            }
            Add(car);
            return null;
        }

        [CacheRemoveAspect("ICarService.get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Message.CarDeleted);
        }
       
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Message.CarsListed);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max), Message.CarsListed);
        }

        [PerformanceAspect(3)]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id));
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Message.CarsDetailsListed);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrand(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId));
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetailsByColor(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsById(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c=>c.CarId == id));
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int branId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == branId), Message.CarsListed);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Message.CarsListed);
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);

            return new SuccessResult();
        }
    }
}
