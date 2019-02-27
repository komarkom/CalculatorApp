using System.Collections.Generic;

namespace CalculatorApp.Interface
{
    public interface IInputConverterToReversPolishNotation
    {
        ICollection<string> Convert(ICollection<string> input, ResolvedOperations resolvedOperations);
    }
}