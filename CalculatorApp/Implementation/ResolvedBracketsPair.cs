using CalculatorApp.Interface;

namespace CalculatorApp.Implementation
{
    public class ResolvedBracketsPair : IBracketPair
    {
        public ResolvedBracket OpenBracket { get; set; }
        public ResolvedBracket CloseBracket { get; set; }
    }
}