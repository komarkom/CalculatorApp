using System.Collections.Generic;

namespace CalculatorApp.Interface
{
    public interface IInputValidate
    {
        bool IsValid(string input);
        bool IsValid(string input, ResolvedOperations resolvedOperations, ICollection<string> decimalDelimiters);
    }
}