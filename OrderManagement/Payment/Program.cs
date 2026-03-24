using Payment.Configuration;
using Payment.Factory;
using Payment.Interface;

namespace Payment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Payment Service Loading...\n" +
                "Choose 1 for Cash payment,\n" +
                "2 for UPI payment,\n" +
                "3 for Card payment\n");

            

            int option;

            while(!int.TryParse(Console.ReadLine(), out option) || option <= 0 || option > 3)
            {
                Console.WriteLine("Please enter a valid number");
            }
            
            Console.WriteLine($"User has choosen {PaymentTypeConfig.paymentType[option]}\n");

            Console.WriteLine("Enter the amount for payment");
            double amount;

            while (!double.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.WriteLine("Please enter a valid amount");
            }

            PaymentProcess process = new PaymentProcess();
            process.Process(option, amount);

        }
    }
}
