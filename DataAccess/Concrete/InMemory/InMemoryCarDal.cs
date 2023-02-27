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
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=3,ModelYear="2015",DailyPrice=750,CarDescription="Aile için ekonomik"},
                new Car{CarId=2,BrandId=2,ColorId=1,ModelYear="2017",DailyPrice=1750,CarDescription="Gezi tutkunları için"},
                new Car{CarId=3,BrandId=1,ColorId=2,ModelYear="2018",DailyPrice=2350,CarDescription="Aile için orta düzey"},
                new Car{CarId=4,BrandId=3,ColorId=2,ModelYear="2020",DailyPrice=2950,CarDescription="Düğün arabası"},
                new Car{CarId=5,BrandId=1,ColorId=2,ModelYear="2022",DailyPrice=3750,CarDescription="Yeni nesil araba"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car? carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(car);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car? carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.CarDescription = car.CarDescription;
        }
    }
}
