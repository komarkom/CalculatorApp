using CalculatorApp.Implementation;

namespace CalculatorApp.Interface
{
    public interface IBracketPair
    {
        ResolvedBracket OpenBracket { get; set; }
        ResolvedBracket CloseBracket { get; set; }
    }
}