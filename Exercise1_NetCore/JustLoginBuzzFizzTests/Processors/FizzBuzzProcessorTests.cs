using JustLoginBuzzFizzApp.Processors;
using JustLoginBuzzFizzApp.Rules;

namespace JustLoginBuzzFizzTests.Processors
{
    [TestFixture]
    public class FizzBuzzProcessorTests
    {
        private FizzBuzzProcessor _processor;

        [SetUp]
        public void Setup()
        {
            var rules = new List<IFizzBuzzRule>
            {
                new FizzBuzzRule(),
                new FizzRule(),
                new BuzzRule(),
                new DefaultRule()
            };

            _processor = new FizzBuzzProcessor(rules);
        }

        [TestCase(5, "Buzz")]
        [TestCase(3, "Fizz")]
        [TestCase(1, "1")]
        [TestCase(7, "7")]
        [TestCase(11, "11")]
        [TestCase(15, "FizzBuzz")]
        public void Process_Number_ReturnsExpectedResult(int number, string expected)
        {
            var result = _processor.Process(number);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Process_NoMatchingRule_ThrowsInvalidOperationException()
        {
            var processorWithoutDefaultRule = new FizzBuzzProcessor(new List<IFizzBuzzRule>
            {
                new FizzBuzzRule(),
                new FizzRule(),
                new BuzzRule()
            });

            Assert.Throws<System.InvalidOperationException>(() => processorWithoutDefaultRule.Process(7));
        }
    }
}
