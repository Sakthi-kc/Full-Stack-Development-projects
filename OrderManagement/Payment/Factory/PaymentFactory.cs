using Payment.Base;
using Payment.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Factory
{
    internal class PaymentFactory
    {
        //declared as static because we don't want to create an object for this
        public static PaymentService GetPayment(int option)
        {
            return option switch
            {
                1 => new CashPayment(),
                2 => new UPIPayment(),
                3 => new CardPayment(),
                _ => throw new Exception("Invalid option")
            };
        }
    }
}
