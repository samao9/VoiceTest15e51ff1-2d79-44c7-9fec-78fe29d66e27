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
                yield return "asdfasdf";
            }
        }

        public static IEnumerable InvalidInputs
        {
            get
            {
                yield return " ";
                yield return "0";
                yield return "!";
                yield return "a0a";
                yield return "a?a";
                yield return "a&0a";
            }
        }


        public static IEnumerable TransformableOneSol
        {
            get
            {
                yield return new object[] {"raicecar", new List<int> {2}};
                yield return new object[] {"raceciar", new List<int> {5}};
                yield return new object[] {"kabcba", new List<int> {0}};
                yield return new object[] {"abcddcbaj", new List<int> {8}};
            }
        }

        public static IEnumerable TransformableTwoSol
        {
            get
            {
                yield return new object[] {"raciecar", new List<int> {4, 3}};
                yield return new object[] {"baba", new List<int> {0, 3}};
                yield return new object[] {"ab", new List<int> {0, 1}};
            }
        }
    }
}