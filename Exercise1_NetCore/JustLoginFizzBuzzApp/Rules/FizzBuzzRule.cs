using JustLoginBuzzFizzApp.Commons;

namespace JustLoginBuzzFizzApp.Rules
{
    public class FizzBuzzRule : IFizzBuzzRule
    {
        public string GetOutput(int number)
        {
            return Constants.FizzBuzz;
        }

        public bool IsMatch(int number)
        {
            return number % 3 == 0 && number % 5 == 0;
        }
    }
}
