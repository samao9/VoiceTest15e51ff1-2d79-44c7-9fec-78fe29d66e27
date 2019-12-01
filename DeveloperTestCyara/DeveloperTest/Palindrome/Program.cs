using System;

namespace Palindrome
{
    class Program
    {
        static void Main()
        {
            string input;
            Console.Write("Enter Integer: ");
            input = Console.ReadLine();

            var output = PalindromeTransform.GetTransformIndexes(input);

            if (output == null)
            {
                Console.WriteLine("Not transformable");
            } else if (output.Count == 0)
            {
                Console.WriteLine("Already a palindrome");
            }
            else
            {
                output.ForEach(x => Console.WriteLine(x));
            }

            Console.ReadKey();
        }
    }
}
