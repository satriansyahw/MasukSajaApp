using JustLoginBuzzFizzApp.Rules;

namespace JustLoginBuzzFizzTests.Rules
{
    [TestFixture]
    public class DefaultRuleTests
    {
        private DefaultRule _defaultRule;

        [SetUp]
        public void Setup()
        {
            _defaultRule = new DefaultRule();
        }

        [Test]
        public void IsMatch_AlwaysReturnsTrue()
        {
            Assert.IsTrue(_defaultRule.IsMatch(1));
            Assert.IsTrue(_defaultRule.IsMatch(2));
            Assert.IsTrue(_defaultRule.IsMatch(100));
        }

        [Test]
        public void GetOutput_ReturnsNumberAsString()
        {
            Assert.AreEqual("1", _defaultRule.GetOutput(1));
            Assert.AreEqual("2", _defaultRule.GetOutput(2));
            Assert.AreEqual("100", _defaultRule.GetOutput(100));
        }
    }
}
