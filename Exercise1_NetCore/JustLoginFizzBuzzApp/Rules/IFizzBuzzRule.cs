namespace JustLoginBuzzFizzApp.Rules
{
    public interface IFizzBuzzRule
    {
        bool IsMatch(int number);
        string GetOutput(int number);
    }
}
