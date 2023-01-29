using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarDescription).NotEmpty();
            RuleFor(c => c.CarDescription).MinimumLength(2);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.ModelYear).Must(StartWithTwo).WithMessage("Araba Modeli 21. yüzyıldan olmalıdır.");
        }
       
        private bool StartWithTwo(string arg)
        {
            return arg.StartsWith("2");
        }
    }
}
