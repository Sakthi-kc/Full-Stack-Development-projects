using Payment.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Services
{
    internal class CardPayment : PaymentService
    {
        protected override void PayByService(double amount)
        {
            Console.WriteLine($"Received {amount} via Card");
        }
    }
}
