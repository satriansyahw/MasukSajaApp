using JustLoginBuzzFizzApp.Commons;
using JustLoginBuzzFizzApp.Rules;

namespace JustLoginBuzzFizzTests.Rules
{
    [TestFixture]
    public class FizzRuleTests
    {
        private FizzRule _fizzRule;

        [SetUp]
        public void Setup()
        {
            _fizzRule = new FizzRule();
        }

        [Test]
        public void IsMatch_NumberIsMultipleOfThree_ReturnsTrue()
        {
            Assert.IsTrue(_fizzRule.IsMatch(3));
            Assert.IsTrue(_fizzRule.IsMatch(6));
        }

        [Test]
        public void IsMatch_NumberIsNotMultipleOfThree_ReturnsFalse()
        {
            Assert.IsFalse(_fizzRule.IsMatch(5));
        }

        [Test]
        public void GetOutput_ReturnsFizz()
        {
            Assert.AreEqual(Constants.Fizz, _fizzRule.GetOutput(3));
        }
    }
}
