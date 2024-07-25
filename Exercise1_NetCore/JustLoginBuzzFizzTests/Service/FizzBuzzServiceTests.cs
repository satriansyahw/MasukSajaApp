using JustLoginBuzzFizzApp.Commons;
using JustLoginBuzzFizzApp.Printers;
using JustLoginBuzzFizzApp.Services;
using Moq;

namespace JustLoginBuzzFizzTests.Service
{
    [TestFixture]
    public class FizzBuzzServiceTests
    {
        private FizzBuzzService _service;
        private Mock<IPrinter> _mockPrinter;

        [SetUp]
        public void Setup()
        {
            _mockPrinter = new Mock<IPrinter>();
            _service = new FizzBuzzService(_mockPrinter.Object);
        }

        [Test]
        public void Run_PrintsCorrectResults_ForRange1To100()
        {
            _service.RunFizzBuzz(1, 100);

            VerifyPrintCallsForRange(1, 100);
        }

        [Test]
        public void Run_PrintsCorrectResults_ForRange50To60()
        {
            _service.RunFizzBuzz(50, 60);

            VerifyPrintCallsForRange(50, 60);
        }

        [Test]
        public void Run_ThrowsArgumentException_WhenStartIsGreaterThanEnd()
        {
            var ex = Assert.Throws<ArgumentException>(() => _service.RunFizzBuzz(10, 5));
            Assert.That(ex.Message, Is.EqualTo("Start must be less than or equal to end."));
        }

        private void VerifyPrintCallsForRange(int start, int end)
        {
            var expectedResults = new List<string>();
            for (int i = start; i <= end; i++)
            {
                expectedResults.Add(GetFizzBuzzResult(i));
            }

            foreach (var result in expectedResults)
            {
                _mockPrinter.Verify(p => p.Print(result), Times.AtLeastOnce);
            }
        }

        private string GetFizzBuzzResult(int number)
        {
            if (number % 3 == 0 && number % 5 == 0) return Constants.FizzBuzz;
            if (number % 3 == 0) return Constants.Fizz;
            if (number % 5 == 0) return Constants.Buzz;
            return number.ToString();
        }
    }
}
