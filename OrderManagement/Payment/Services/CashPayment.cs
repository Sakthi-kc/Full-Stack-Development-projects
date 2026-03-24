using Payment.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Services
{
    internal class CashPayment : PaymentService
    {
        protected override void Pay(double amount)
        {
            Console.WriteLine($"Received {amount} via Cash");
        }
    }
}
