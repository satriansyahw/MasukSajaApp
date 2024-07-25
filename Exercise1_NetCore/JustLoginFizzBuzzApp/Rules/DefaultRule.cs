namespace JustLoginBuzzFizzApp.Rules
{
    public class DefaultRule : IFizzBuzzRule
    {
        public string GetOutput(int number)
        {
            return number.ToString();
        }

        public bool IsMatch(int number)
        {
            return true;
        }
    }
}
