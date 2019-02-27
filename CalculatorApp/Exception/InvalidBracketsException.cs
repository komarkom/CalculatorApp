namespace CalculatorApp.Exception
{
    public class InvalidBracketsException: System.Exception
    {
        public InvalidBracketsException()
        {
        }
        public InvalidBracketsException(string message)
            : base(message)
        {
        }
        public InvalidBracketsException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
