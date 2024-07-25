using JustLoginBuzzFizzApp.Printers;
using JustLoginBuzzFizzApp.Processors;
using JustLoginBuzzFizzApp.Rules;

namespace JustLoginBuzzFizzApp.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        private readonly IPrinter _printer;

        public FizzBuzzService(IPrinter printer)
        {
            _printer = printer;
        }

        public void RunFizzBuzz(int start,int end)
        {
            if (start > end)
            {
                throw new ArgumentException("Start must be less than or equal to end.");
            }
            var rules = new List<IFizzBuzzRule>
            {
                new FizzBuzzRule(),
                new FizzRule(),
                new BuzzRule(),
                new DefaultRule()
            };

            var processor = new FizzBuzzProcessor(rules);

            for (int i = start; i <= end; i++)
            {
                string result = processor.Process(i);
                _printer.Print(result);
            }
        }
    }
}
