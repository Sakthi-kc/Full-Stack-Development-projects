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
            Console.ForegroundColor = ConsoleColor.Green;

            Pay(amount);

            Console.ResetColor();
        }

        protected abstract void Pay(double amount);
    }
}
