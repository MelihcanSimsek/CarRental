using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Abstract;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", item.CarId,item.BrandId,item.ColorId,item.ModelYear,item.DailyPrice,item.CarDescription);
            }
            Console.WriteLine("\n");
            foreach (var item in carManager.GetByDailyPrice(1500,4000))
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", item.CarId, item.BrandId, item.ColorId, item.ModelYear, item.DailyPrice, item.CarDescription);
            }
            carManager.Add(new Car { CarId = 7, BrandId = 1, ColorId = 3, ModelYear = "2014", DailyPrice = 1400, CarDescription = "for database test" });
            Console.WriteLine("\n");
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", item.CarId, item.BrandId, item.ColorId, item.ModelYear, item.DailyPrice, item.CarDescription);
            }

            Console.ReadKey();
        }
    }
}