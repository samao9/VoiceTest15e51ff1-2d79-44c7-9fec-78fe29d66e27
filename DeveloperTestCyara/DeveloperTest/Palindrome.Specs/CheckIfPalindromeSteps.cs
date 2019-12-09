using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Palindrome.Specs
{
    [Binding]
    public class CheckIfPalindromeSteps
    {
        private string _inputString;
        private bool _result;
        [Given(@"I have entered ""(.*)"" as the input")]
        public void GivenIHaveEnteredAsTheInput(string word)
        {
            _inputString = word;
        }

        [When(@"I verfty if the input is palindrome")]
        public void WhenIVerftyIfTheInputIsPalindrome()
        {
            _result = PalindromeTransform.IsPalindrome(_inputString);
        }

        [Then(@"I should get true as result")]
        public void ThenIShouldGetTrueAsResult()
        {
            Assert.AreEqual(true, _result);
        }

        [Then(@"I should get false as result")]
        public void ThenIShouldGetFalseAsResult()
        {
            Assert.AreEqual(false, _result);
        }


    }
}
