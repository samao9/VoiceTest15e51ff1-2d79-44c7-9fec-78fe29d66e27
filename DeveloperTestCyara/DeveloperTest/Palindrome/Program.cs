using System;

namespace Palindrome
{
    class Program
    {
        static void Main()
        {
            string input;
            Console.Write("Enter lowercase letters in the range ascii[a-z]: ");
            input = Console.ReadLine();

            var result = PalindromeTransform.GetTransformIndexes(input);

            if (result == null)
            {
                Console.WriteLine("Not transformable");
                Console.WriteLine(-1);
            }
            else if (result.Count == 0)
            {
                Console.WriteLine("Already a palindrome");
                Console.WriteLine(-1);
            }
            else
            {
                string output = result[0].ToString();
                if (result.Count == 2) output += $", {result[1].ToString()}";

                Console.WriteLine(output);
                // Parse output

                Console.WriteLine(input);
                if (input != null)
                {
                    string explanation = $"Removing {input[result[0]]} at index {result[0]} results in a palindrome.";
                    if (result.Count == 2)
                        explanation =
                            $"Removing {input[result[0]]} at index {result[0]} or {input[result[1]]} at index {result[1]} results in a palindrome.";

                    Console.WriteLine(explanation);
                }
            }

            Console.ReadKey();
        }
    }
}
