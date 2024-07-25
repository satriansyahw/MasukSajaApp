using JustLoginBuzzFizzApp.Printers;

namespace JustLoginBuzzFizzTests.Printers
{
    [TestFixture]
    public class ConsolePrinterTests
    {
        private ConsolePrinter _printer;
        private StringWriter _stringWriter;

        [SetUp]
        public void Setup()
        {
            _printer = new ConsolePrinter();
            _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);
        }

        [TearDown]
        public void TearDown()
        {
            _stringWriter.Dispose();
        }

        [Test]
        public void Print_Message_PrintsToConsole()
        {
            string message = "Hello, World!";
            _printer.Print(message);
            Assert.AreEqual(message + Environment.NewLine, _stringWriter.ToString());
        }
    }
}
