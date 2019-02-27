using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CalculatorApp.Interface;

namespace CalculatorApp.Implementation
{
    public class InputValidate : IInputValidate
    {
        public bool IsValid(string input)
        {
            if (input == null || string.IsNullOrEmpty(input))
                return false;
            return true;
        }

        public bool IsValid(string input, ResolvedOperations resolvedOperations, ICollection<string> decimalDelimiters)
        {
            if (input == null || string.IsNullOrEmpty(input))
                return false;
            var pattern = new StringBuilder();
            pattern.Append("[0-9");
            foreach (var decimalDelimiter in decimalDelimiters)
            {
                pattern.Append(decimalDelimiter);
            }
            foreach (var operation in resolvedOperations.Operations.Select(x=>x.OperatorStrToRegex).ToList())
            {
                pattern.Append(operation);
            }
            pattern.Append("]+");
            var match = Regex.Match(input, pattern.ToString(), RegexOptions.IgnoreCase);
            if (!match.Success)
                return false;
            return true;
        }
    }
}