using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>();
            builder.RegisterType<BrandManager>().As<IBrandService>();
            builder.RegisterType<ColorManager>().As<IColorService>();
            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<RentalManager>().As<IRentalService>();
            builder.RegisterType<EfCarDal>().As<ICarDal>();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>();
            builder.RegisterType<EfColorDal>().As<IColorDal>();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
        }
    }
}
