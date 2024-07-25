namespace JustLoginBuzzFizzApp.Printers
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}
