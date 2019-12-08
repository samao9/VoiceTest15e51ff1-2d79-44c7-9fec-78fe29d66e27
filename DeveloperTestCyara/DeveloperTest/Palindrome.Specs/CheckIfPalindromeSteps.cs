using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Palindrome.Specs
{
    [Binding]
    public class CheckIfPalindromeSteps
    {
        private bool result;
        [Given(@"I have entered ""([a-z]*)"" as the input")]
        public void GivenIHaveEnteredAsTheInput(string word)
        {
            result = PalindromeTransform.IsPalindrome(word);
        }
        
        [Then(@"I got a true as result")]
        public void ThenIGotATrueAsResult()
        {
            Assert.AreEqual(true, result);
        }

        [Then(@"I got a false as result")]
        public void ThenIGotAFalseAsResult()
        {
            Assert.AreEqual(false, result);
        }
    }
}
