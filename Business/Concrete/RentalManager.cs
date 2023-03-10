using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = _rentalDal.Get(r => r.CarId == rental.CarId);
            var time = result == null ? -1 : DateTime.Compare((DateTime)result.ReturnDate, rental.RentDate);
            if (rental.ReturnDate == null || time >= 0)
            {
                return new ErrorResult(Message.RentalAddError);
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Message.RentalAdded);
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult RulesForAdding(Rental rental)
        {
            var result = BusinessRules.Run(
                CheckIfReturnDateIsBeforeRentDate(rental), CheckIfThisCarAlreadyRentedInSelectedDateRange(rental));
            if(result != null)
            {
                return result;
            }
            return new SuccessResult(Message.SelectedDateRangeIsOkay);


        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        private IResult CheckIfThisCarAlreadyRentedInSelectedDateRange(Rental rental)
        {
            var result = _rentalDal.Get(r => r.CarId == rental.CarId 
            && (r.RentDate.Date == rental.RentDate.Date 
            || (r.RentDate.Date < rental.RentDate.Date 
            && (r.ReturnDate == null
            || ((DateTime)r.ReturnDate).Date > rental.RentDate.Date))));

            if(result != null)
            {
                return new ErrorResult(Message.ThisCarAlreadyRentedInSelectedDateRange);
            }
            return new SuccessResult();

        }

        private IResult CheckIfReturnDateIsBeforeRentDate(Rental rental)
        {
            if(rental.ReturnDate != null)
            {
                if(rental.RentDate > rental.ReturnDate)
                {

                    return new ErrorResult(Message.ReturnDateIsBeforeRentDate);
                }
            }
            return new SuccessResult();

        }
    }
}
