using JustLoginBuzzFizzApp.Commons;
using JustLoginBuzzFizzApp.Rules;

namespace JustLoginBuzzFizzTests.Rules
{
    [TestFixture]
    public class BuzzRuleTests
    {
        private BuzzRule _buzzRule;

        [SetUp]
        public void Setup()
        {
            _buzzRule = new BuzzRule();
        }

        [Test]
        public void IsMatch_NumberIsMultipleOfFive_ReturnsTrue()
        {
            Assert.IsTrue(_buzzRule.IsMatch(5));
            Assert.IsTrue(_buzzRule.IsMatch(10));
        }

        [Test]
        public void IsMatch_NumberIsNotMultipleOfFive_ReturnsFalse()
        {
            Assert.IsFalse(_buzzRule.IsMatch(3));
        }

        [Test]
        public void GetOutput_ReturnsBuzz()
        {
            Assert.AreEqual(Constants.Buzz, _buzzRule.GetOutput(5));
        }
    }
}
