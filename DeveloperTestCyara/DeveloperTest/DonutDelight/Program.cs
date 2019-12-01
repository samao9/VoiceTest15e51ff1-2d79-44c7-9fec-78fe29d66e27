using System;
using System.Linq;

namespace DonutDelight
{
    class Program
    {
        static void Main()
        {
            string input;
            Console.Write("Enter Integer: ");
            input = Console.ReadLine();

            int size = Convert.ToInt32(input);

            var r = OrderSizes.GetOrderForSize(size);
            r.ForEach(x =>
            {
                Console.WriteLine(x);
            });
            Console.WriteLine("__________");
            Console.WriteLine(r.Sum());

            Console.WriteLine("Invalid order sizes: ");
            var t = OrderSizes.GetInvalidOrders(50);
            t.ForEach(x => Console.WriteLine(x));
            Console.ReadKey();
        }
    }
}
