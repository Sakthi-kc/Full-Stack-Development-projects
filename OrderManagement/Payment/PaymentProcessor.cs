using Microsoft.VisualBasic.FileIO;
using Payment.Configuration;
using Payment.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment
{
    internal class Processor
    {
        //delegate function which means function that takes int and return IPaymentService
        private readonly Func<paymentType, IPaymentService> _paymentFactory;

        public Processor(Func<paymentType, IPaymentService> paymentFactory)
        {
           _paymentFactory = paymentFactory;
        }

        public void PaymentProcess(paymentType type, double amount)
        {
            var payment = _paymentFactory(type);

            payment.PlaceOrder(amount);
        }
    }
}
