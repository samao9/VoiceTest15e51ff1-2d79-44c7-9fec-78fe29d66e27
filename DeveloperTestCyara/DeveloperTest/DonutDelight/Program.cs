using System;
using System.Linq;

namespace DonutDelight
{
    class Program
    {
        static void Main()
        {
            string input;
            Console.Write("Enter Positive Integer: ");
            input = Console.ReadLine();

            int size = Convert.ToInt32(input);

            var r = OrderSizes.GetBoxCountForOrder(size);

            var t = r.Select(x => $"{x.Value} x {x.Key}");

            string output = String.Join("+", t.ToArray()) + $"= {size}";
            Console.WriteLine(output);

            t = r.Select(x => $"{x.Value} boxes of {x.Key} donuts");
            string explanation = String.Join(" plus ", t.ToArray());
            Console.WriteLine(explanation);

            Console.ReadKey();
        }
    }
}
