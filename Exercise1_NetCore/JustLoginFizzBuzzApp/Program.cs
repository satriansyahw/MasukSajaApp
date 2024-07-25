using JustLoginBuzzFizzApp.Printers;
using JustLoginBuzzFizzApp.Services;

namespace JustLoginBuzzFizzApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPrinter printer = new ConsolePrinter();
            IFizzBuzzService service = new FizzBuzzService(printer);
            service.RunFizzBuzz(1,100);
        }
    }
}