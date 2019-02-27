using CalculatorApp.Interface;

namespace CalculatorApp.Implementation
{
    public class ResolvedBracket : IResolvedSymbol
    {
        public string OperatorStr { get; set; }
        public string OperatorStrToRegex { get; set; }
        public byte Priority { get; set; }
    }
}