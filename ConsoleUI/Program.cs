using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandId = 10, BrandName = "Ferrari" });
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Delete(new Color { ColorId = 6, ColorName = "Orange" });
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var carDetail in carManager.GetCarDetails())
            {
                Console.WriteLine(carDetail.BrandName+" "+carDetail.ColorName+" "+carDetail.ModelYear+" "+carDetail.CarDescription+" "+carDetail.DailyPrice);
            }
            Console.ReadKey();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", item.CarId, item.BrandId, item.ColorId, item.ModelYear, item.DailyPrice, item.CarDescription);
            }
            Console.WriteLine("\n");
            foreach (var item in carManager.GetByDailyPrice(1500, 4000))
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", item.CarId, item.BrandId, item.ColorId, item.ModelYear, item.DailyPrice, item.CarDescription);
            }
            carManager.Add(new Car { CarId = 7, BrandId = 1, ColorId = 3, ModelYear = "2014", DailyPrice = 1400, CarDescription = "for database test" });
            Console.WriteLine("\n");
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", item.CarId, item.BrandId, item.ColorId, item.ModelYear, item.DailyPrice, item.CarDescription);
            }
        }
    }
}