using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;
        ICustomerService _customerService;
        ICreditCardService _creditCardService;
        public PaymentManager(
            IPaymentDal paymentDal,
            ICustomerService customerService,
            ICreditCardService creditCardService
            )
        {
            _paymentDal = paymentDal;
            _creditCardService = creditCardService;
            _customerService = customerService;
        }

        public IResult Add(Payment payment)
        {
            IResult result = BusinessRules.Run(
                CheckIsCreditCardExist(payment.CreditCardNumber, payment.ExpirationDate, payment.SecurityCode));

            if (result != null)
            {
                return result;
            }
            _paymentDal.Add(payment);

            return new SuccessResult(Messages.PaymentAdded);
        }

        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult(Messages.PaymentDeleted);
        }

        public IDataResult<Payment> Get(Payment payment)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(p=>p.Id==payment.Id));
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll());
        }
        public IDataResult<List<Payment>> GetPaymentById(int id)
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(p=>p.Id==id));
        }

        public IDataResult<Payment> GetPaymentDetailsById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult(Messages.PaymentUpdated);
        }

        private IResult CheckIsCreditCardExist(string cardNumber, string expirationDate, string securityCode)
        {
            if (!_creditCardService.GetAll().Data.Any(
                c => c.CreditCardNumber == cardNumber &&
                c.ExpirationDate == expirationDate &&
                c.SecurityCode == securityCode
                ))
            {
                return new ErrorResult(Messages.CreditCardNotFound);
            }
            return new SuccessResult();
        }
    }
}