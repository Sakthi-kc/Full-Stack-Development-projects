using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Configuration
{
    internal class PaymentTypeConfig
    {
        public static Dictionary<int, string> paymentType = new Dictionary<int, string>()
            {
                { 1, "Cash" },
                { 2, "UPI" },
                { 3, "Card" }
            };
    }
}
