using Microsoft.VisualBasic.FileIO;
using Payment.Factory;
using Payment.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment
{
    internal class PaymentProcess
    {
        public void Process(int option, double amount)
        {
            //static members belong to the class hence called with class name not instance
            IPaymentService payment = PaymentFactory.GetPayment(option);

            Console.WriteLine();

            payment.PrintReceipt();
            payment.PlaceOrder(amount);
        }
    }
}
