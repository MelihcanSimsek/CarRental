using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetCarsByBrandId(int branId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<Car>> GetByDailyPrice(decimal min,decimal max);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarDetailsById(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColor(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrand(int brandId);
        IDataResult<Car> GetById(int id);
        IResult AddTransactionalTest(Car car);
    }
}
