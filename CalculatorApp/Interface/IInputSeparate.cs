using System.Collections;
using System.Collections.Generic;

namespace CalculatorApp.Interface
{
    public interface IInputSeparate
    {
        IEnumerable<string> SeparateString(string input, ResolvedOperations resolvedOperations);
    }
}