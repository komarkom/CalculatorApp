namespace CalculatorApp.Exception
{
    public class SeparateException: System.Exception
    {
        public SeparateException()
        {
        }
        public SeparateException(string message)
            : base(message)
        {
        }
        public SeparateException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
