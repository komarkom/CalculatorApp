namespace CalculatorApp.Exception
{
    public class ConvertException: System.Exception
    {
        public ConvertException()
        {
        }
        public ConvertException(string message)
            : base(message)
        {
        }
        public ConvertException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
