using JustLoginBuzzFizzApp.Rules;

namespace JustLoginBuzzFizzApp.Processors
{
    public class FizzBuzzProcessor
    {
        private readonly List<IFizzBuzzRule> _rules;

        public FizzBuzzProcessor(List<IFizzBuzzRule> rules)
        {
            _rules = rules ?? throw new System.ArgumentNullException(nameof(rules));
        }

        public string Process(int number)
        {
            foreach (var rule in _rules)
            {
                if (rule.IsMatch(number))
                {
                    return rule.GetOutput(number);
                }
            }

            throw new System.InvalidOperationException("No matching rule found. This should never happen because DefaultRule always matches.");
        }
    }
}
