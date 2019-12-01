﻿using System.Collections.Generic;

namespace Palindrome
{
    public class PalindromeTransform
    {
        // Function to check if a substring is palindrome
        public static bool IsPalindrome(string word, int leftIndex, int rightIndex)
        {
            while (leftIndex < rightIndex)
            {
                if (word[leftIndex] != word[rightIndex])
                {
                    return false;
                }

                leftIndex++;
                rightIndex--;
            }

            return true;
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
            var indexes = new List<int>();
            int lPointer = 0;
            int rPointer = word.Length - 1;
            int mismatchCount = 0;

            while (lPointer <= rPointer && indexes.Count == 0)
            {
                if (word[lPointer] != word[rPointer])
                {
                    mismatchCount++;
                    if (mismatchCount > 1)
                    {
                        return null;
                    }

                    // Check if remove left pointer will result in a palindrome
                    if (word[lPointer + 1] == word[rPointer])
                    {
                        if (IsPalindrome(word, lPointer + 1, rPointer))
                        {
                            indexes.Add(lPointer);
                        }
                    }

                    // Check if remove right pointer will result in a palindrome
                    if (word[lPointer] != word[rPointer - 1]) continue;
                    if (IsPalindrome(word, lPointer, rPointer - 1)) indexes.Add(rPointer);
                }
                else
                {
                    lPointer++;
                    rPointer--;
                }
            }

            return indexes;
        }
    }
}
