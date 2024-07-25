using JustLoginBuzzFizzApp.Commons;
using JustLoginBuzzFizzApp.Rules;

namespace JustLoginBuzzFizzTests.Rules
{
    [TestFixture]
    public class FizzBuzzRuleTests
    {
        private FizzBuzzRule _fizzBuzzRule;

        [SetUp]
        public void Setup()
        {
            _fizzBuzzRule = new FizzBuzzRule();
        }

        [Test]
        public void IsMatch_NumberIsMultipleOfThreeAndFive_ReturnsTrue()
        {
            Assert.IsTrue(_fizzBuzzRule.IsMatch(15));
            Assert.IsTrue(_fizzBuzzRule.IsMatch(30));
        }

        [Test]
        public void IsMatch_NumberIsNotMultipleOfThreeAndFive_ReturnsFalse()
        {
            Assert.IsFalse(_fizzBuzzRule.IsMatch(3));
            Assert.IsFalse(_fizzBuzzRule.IsMatch(5));
        }

        [Test]
        public void GetOutput_ReturnsFizzBuzz()
        {
            Assert.AreEqual(Constants.FizzBuzz, _fizzBuzzRule.GetOutput(15));
        }
    }
}
