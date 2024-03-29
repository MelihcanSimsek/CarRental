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
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityFrameworkBase<Car, ReCapContext>, ICarDal
    {
        

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>>? filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 BrandId = brand.BrandId,
                                 ColorId = color.ColorId,
                                 CarName=car.CarName,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 CarDescription = car.CarDescription,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 ImagePath=(from img in context.CarImages
                                            where car.CarId == img.CarId
                                            select img.ImagePath).SingleOrDefault()
                             };

                return filter == null ?  result.ToList() : result.Where(filter).ToList();

            }
        }
    }
}
