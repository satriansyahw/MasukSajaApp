using JustLoginBuzzFizzApp.Commons;

namespace JustLoginBuzzFizzApp.Rules
{
    public class FizzRule : IFizzBuzzRule
    {
        public string GetOutput(int number)
        {
            return Constants.Fizz ;
        }

        public bool IsMatch(int number)
        {
            return number % 3 == 0;
        }
    }
}
