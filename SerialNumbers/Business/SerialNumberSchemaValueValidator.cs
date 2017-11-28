using System.Linq;
using System.Text.RegularExpressions;

namespace SerialNumbers.Business
{
    internal class SerialNumberSchemaValueValidator : ISerialNumberSchemaValueValidator
    {
        private const string PATTERN = @"{(.*?)}";

        public bool IsValid(string mask, params string[] args)
        {
            // TODO vkacmarik: validate number of arguments in formatted string
            var numberOfArgs = args?.Length + 1 ?? 1;
            return IsValid(mask, numberOfArgs);
        }

        private static bool IsValid(string pattern, string mask, int numberOfArgs)
        {
            var matches = Regex.Matches(mask, pattern);
            var uniqueMatchCount = matches.OfType<Match>().Select(m => m.Value).Distinct().Count();
            return uniqueMatchCount == numberOfArgs;
        }

        private static bool IsValid(string mask, int numberOfArgs)
        {
            var patterns = new[] { PATTERN };
            return patterns.All(pattern => IsValid(pattern, mask, numberOfArgs));
        }
    }
}