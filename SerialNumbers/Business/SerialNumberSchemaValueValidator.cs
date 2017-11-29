using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SerialNumbers.Business
{
    public class SerialNumberSchemaValueValidator : ISerialNumberSchemaValueValidator
    {
        private const string PARAMETER_END_BRACKET = "}";
        private const string PARAMETER_FORMAT_SEPARATOR = ":";
        private const string PATTERN = @"\{\d+(\:[^\{\}]*[\d\W]+)?\}";

        public void Validate(string mask, params string[] args)
        {
            if (mask == null) throw new ArgumentNullException(nameof(mask));

            var numberOfArgs = GetNumberOfArgs(args);
            var isValid = IsValid(mask, numberOfArgs);
            if (!isValid) throw new InvalidOperationException("The schema definition mask is incorrect. The number of arguments doesn't fit to expected parameters like '{0}' etc.!");
        }

        private static int GetNumberOfArgs(IReadOnlyCollection<string> args)
        {
            if (args == null) return 1;

            return args.Count + 1;
        }

        private static string GetParameterPrefix(string parameterString)
        {
            return parameterString.Contains(PARAMETER_FORMAT_SEPARATOR)
                ? parameterString.Substring(0,
                    parameterString.IndexOf(PARAMETER_FORMAT_SEPARATOR, StringComparison.InvariantCultureIgnoreCase))
                : RemoveEndBracket(parameterString);
        }

        private static bool IsValid(string pattern, string mask, int numberOfArgs)
        {
            var matches = Regex.Matches(mask, pattern);
            var uniqueMatchCount = matches.OfType<Match>().Select(m => GetParameterPrefix(m.Value)).Distinct().Count();
            return uniqueMatchCount == numberOfArgs;
        }

        private static bool IsValid(string mask, int numberOfArgs)
        {
            return IsValid(PATTERN, mask, numberOfArgs);
        }

        private static string RemoveEndBracket(string parameterString)
        {
            return parameterString.Replace(PARAMETER_END_BRACKET, string.Empty);
        }
    }
}