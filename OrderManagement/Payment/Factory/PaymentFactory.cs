using Payment.Base;
using Payment.Configuration;
using Payment.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Factory
{
    internal class PaymentFactory
    {
        //declared as static because we don't want to create an object for this
        public static PaymentService GetPayment(paymentType type)
        {
            return type switch
            {
                paymentType.Cash => new CashPayment(),
                paymentType.UPI => new UPIPayment(),
                paymentType.Card => new CardPayment(),
                _ => throw new Exception("Invalid option")
            };
        }
    }
}
