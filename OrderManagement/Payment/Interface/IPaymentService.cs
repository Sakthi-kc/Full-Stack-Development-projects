using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Interface
{
    internal interface IPaymentService
    {
        void PrintReceipt();
        void PlaceOrder(double amount);
    }
}
