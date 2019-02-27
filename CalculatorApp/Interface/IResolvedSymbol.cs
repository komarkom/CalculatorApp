namespace CalculatorApp.Interface
{
    public interface IResolvedSymbol
    {
        string OperatorStr { get; set; }
        string OperatorStrToRegex { get; set; }
        byte Priority { get; set; }
    }
}