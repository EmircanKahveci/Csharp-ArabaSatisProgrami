using BusinessLayer.Concrete;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccessLayer.Repositories.Concrete;
using DataAccessLayer.Repositories.Concrete.Entity_Framework;
using Entities.Entities.Concrete;
using System;

namespace ReCapProject
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //CarDetailsTest(carManager);

            //GetAllTest(carManager);

            //GetCarsByBrandIdTest(carManager);

            

        }

       /* private static void CustomerAddTest(CustomerManager customerManager)
        {
            customerManager.Add(new Customer { Id = 1, CompanyName = "kodlama.io" });
            foreach (var c in customerManager.GetAll().Data)
            {
                Console.WriteLine(c.CompanyName);
            }
        }*/

        /*private static void GetCarsByBrandIdTest(CarManager carManager)
        {
            foreach (var car in carManager.GetCarsByBrandId(3).Data)
            {
                
            }
        }

        private static void GetAllTest(CarManager carManager)
        {
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }
        }

       /* private static void CarDetailsTest(CarManager carManager)
        {
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
            }
        }
      */
    }
}
