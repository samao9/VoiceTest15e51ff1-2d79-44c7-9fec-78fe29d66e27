using System.Collections;
using System.Collections.Generic;

namespace Palindrome.Tests
{
    public class PalindromeTestData
    {
        public static IEnumerable Palindrome
        {
            get
            {
                yield return "aba";
                yield return "aabaa";
                yield return "racecar";
                yield return "aaaaaa";
                yield return "a";
            }
        }

        public static IEnumerable NonPalindrome
        {
            get
            {
                yield return "string";
                yield return "ababab";
                yield return "iracecar";
                yield return "sdfasdfasdf";
            }
        }

        public static IEnumerable TransformableOneSol
        {
            get
            {
                yield return new object[] { "raicecar", new List<int> { 2 } };
                yield return new object[] { "raceciar", new List<int> { 5 } };
                yield return new object[] { "kabcba", new List<int> { 0 } };
                yield return new object[] { "abcddcjba", new List<int> { 6 } };
            }
        }

        public static IEnumerable TransformableTwoSol
        {
            get
            {
                yield return new object[] { "raciecar", new List<int> { 3, 4 } };
                yield return new object[] { "raci car", new List<int> { 3, 4 } };
                yield return new object[] { "baba", new List<int> { 0, 3 } };
                yield return new object[] { "abab", new List<int> { 0, 3 } };
                yield return new object[] { "abcd45dcba", new List<int> { 4, 5 } };
                yield return new object[] { "ab", new List<int> { 0, 1 } };
            }
        }
    }
}