using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Abstract;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());
            ColorManager colorManager = new ColorManager(new InMemoryColorDal());
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Car car1 = new Car { CarId = 6, BrandId = 3, ColorId = 3, DailyPrice = 1250, ModelYear = "2012", Description = "Yeni ehliyet sahipleri için" };
            Car car2 = new Car { CarId = 7, BrandId = 2, ColorId = 1, DailyPrice = 4250, ModelYear = "2023", Description = "Lüks severlere" };
            Car car3 = new Car { CarId = 1, BrandId = 3, ColorId = 5, DailyPrice = 850, ModelYear = "2016", Description = "Aile için ekonomik" };
            carManager.Add(car1);
            carManager.Add(car2);
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.CarId+" "+item.BrandId+" "+item.ColorId+" "+item.ModelYear+" "+item.DailyPrice+" "+item.Description);
            }
            carManager.Update(car3);
            carManager.Delete(car2);
            Console.WriteLine("-------------");
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.CarId + " " + item.BrandId + " " + item.ColorId + " " + item.ModelYear + " " + item.DailyPrice + " " + item.Description);
            }
            Console.WriteLine("-------------");
            foreach (var item in brandManager.GetAll())
            {
                Console.WriteLine(item.BrandId + " " +item.BrandName );
            }
            Console.WriteLine("-------------");
            foreach (var item in colorManager.GetAll())
            {
                Console.WriteLine(item.ColorId + " " + item.ColorName );
            }

        }
    }
}