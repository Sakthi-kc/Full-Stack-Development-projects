using Payment.Configuration;
using Payment.Factory;
using Payment.Interface;

namespace Payment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Payment Service Loading...\nChoose payment type:\n");

            foreach (var type in Enum.GetValues(typeof(paymentType)))
            {
                Console.WriteLine($"{(int)type} for {type} payment");
            }

            Console.WriteLine();

            int option;

            //checks if the option is present in this typeof(enum class)
            while(!int.TryParse(Console.ReadLine(), out option) || !Enum.IsDefined(typeof(paymentType), option))
            {
                Console.WriteLine("Please enter a valid number");
            }

            paymentType selectedType = (paymentType)option;

            Console.WriteLine($"User has choosen {selectedType}\n");

            Console.WriteLine("Enter the amount for payment");
            double amount;

            while (!double.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.WriteLine("Please enter a valid amount");
            }

            Console.WriteLine();

            //static members belong to the class hence called with class name not instance
            var processor = new Processor(PaymentFactory.GetPayment);
            
            processor.PaymentProcess(selectedType, amount);

        }
    }
}
