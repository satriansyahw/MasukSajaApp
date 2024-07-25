using JustLoginBuzzFizzApp.Commons;

namespace JustLoginBuzzFizzApp.Rules
{
    public class BuzzRule : IFizzBuzzRule
    {
        public string GetOutput(int number)
        {
            return Constants.Buzz;
        }

        public bool IsMatch(int number)
        {
            return number % 5 == 0;
        }
    }
}
