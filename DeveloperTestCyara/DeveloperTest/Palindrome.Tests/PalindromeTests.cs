using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;

namespace Palindrome.Tests
{
    public class PalindromeTests
    {
        [TestFixture]
        public class IsPalindromeMethodTests
        {
            [TestCaseSource(typeof(PalindromeTestData), nameof(PalindromeTestData.Palindrome))]
            public void IsPalindrome_Palindrome_ReturnTrue(string s)
            {
                var result = PalindromeTransform.IsPalindrome(s, 0, s.Length - 1);
                Assert.IsTrue(result);
            }

            [TestCaseSource(typeof(PalindromeTestData), nameof(PalindromeTestData.NonPalindrome))]
            public void IsPalindrome_NonPalindrome_ReturnTrue(string s)
            {
                var result = PalindromeTransform.IsPalindrome(s, 0, s.Length - 1);
                Assert.IsFalse(result);
            }
        }

        [TestFixture]
        public class GetTransformIndexesMethodTests
        {
            [TestCaseSource(typeof(PalindromeTestData), nameof(PalindromeTestData.TransformableOneSol))]
            public void GetTransformIndexes_OneSol_ReturnIndex(string s, List<int> expected)
            {
                var index = PalindromeTransform.GetTransformIndexes(s);
                Assert.AreEqual(expected, index);
            }

            [TestCaseSource(typeof(PalindromeTestData), nameof(PalindromeTestData.TransformableTwoSol))]
            public void GetTransformIndexes_TwoSol_ReturnIndexes(string s, List<int> expected)
            {
                var indexes = PalindromeTransform.GetTransformIndexes(s);
                Assert.AreEqual(expected, indexes);
            }

            [TestCaseSource(typeof(PalindromeTestData), nameof(PalindromeTestData.Palindrome))]
            public void GetTransformIndexes_Palindrome_ReturnEmpty(string s)
            {
                var index = PalindromeTransform.GetTransformIndexes(s);
                Assert.IsTrue(index.Count == 0);
            }

            [TestCase("dfadf")]
            [TestCase("adcracecar")]
            [TestCase("racecariii")]
            public void GetTransformIndexes_NonTransformable_ReturnNull(string s)
            {
                var index = PalindromeTransform.GetTransformIndexes(s);
                Assert.IsTrue(index == null);
            }

            [TestCaseSource(typeof(PalindromeTestData), nameof(PalindromeTestData.InvalidInputs))]
            public void GetTransformIndexes_InvalidInput_ThrowException(string s)
            {
                Exception ex = Assert.Throws<Exception>(()=> PalindromeTransform.GetTransformIndexes(s));

                Assert.That(ex.Message, Is.EqualTo(PalindromeTransform.INPUT_CONSTRAINT));
            }
        }
    }
}
