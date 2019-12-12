using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Palindrome
{
    public class PalindromeTransform
    {
        public const string InputConstraint = "All characters should be in the range ascii [a-z] (lowercase only)";

        public static bool IsPalindrome(string word)
        {
            var c = word.Length - 1;
            return IsSubStringPalindrome(word, 0, c);
        }

        /// <summary>
        /// Function to check if a string can be transformed to palindrome by removing 1 char
        /// </summary>
        /// <remarks>
        ///  Keep two pointer from both ends of the string, move them towards middle allowing 1 mismatch
        ///  Returns null if not transformable, returns [indexes] if transformable, return [] if palindrome
        /// </remarks>
        public static List<int> GetTransformIndexes(string word)
        {
            if (!CheckInputRegex(word))
            {
                throw new Exception(InputConstraint);
            }
            var indexes = new List<int>();
            int lPointer = 0;
            int rPointer = word.Length - 1;
            int mismatchCount = 0;

            while (lPointer <= rPointer && indexes.Count == 0)
            {
                if (word[lPointer] == word[rPointer]) { lPointer++; rPointer--; }
                else
                {
                    mismatchCount++;
                    if (mismatchCount > 1)
                    {
                        return null;
                    }

                    // Check if remove left pointer will result in a palindrome
                    if (word[lPointer + 1] == word[rPointer])
                    {
                        if (IsSubStringPalindrome(word, lPointer + 1, rPointer))
                        {
                            indexes.Add(lPointer);
                        }
                    }

                    // Check if remove right pointer will result in a palindrome
                    if (word[lPointer] != word[rPointer - 1]) continue;
                    if (IsSubStringPalindrome(word, lPointer, rPointer - 1)) indexes.Add(rPointer);
                }
            }

            return indexes;
        }

        // Function to check if a substring is palindrome
        private static bool IsSubStringPalindrome(string word, int leftIndex, int rightIndex)
        {
            while (leftIndex < rightIndex)
            {
                if (word[leftIndex] != word[rightIndex]) return false;

                leftIndex++;
                rightIndex--;
            }

            return true;
        }

        private static bool CheckInputRegex(string word)
        {
            Regex lcaseA = new Regex("^[a-z]+$");
            return lcaseA.IsMatch(word);
        }

    }
}
