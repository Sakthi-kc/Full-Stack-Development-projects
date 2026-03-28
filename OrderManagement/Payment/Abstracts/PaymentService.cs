using Payment.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Base
{
    internal abstract class PaymentService : IPaymentService
    {
        public void PrintReceipt()
        {
            Console.WriteLine("Receipt loading...");
        }

        public void PlaceOrder(double amount)
        {
            PrintReceipt();

            Console.ForegroundColor = ConsoleColor.Green;
            PayByService(amount);
            Console.ResetColor();
        }

        protected abstract void PayByService(double amount);
    }
}
