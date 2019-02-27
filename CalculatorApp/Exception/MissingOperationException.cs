namespace CalculatorApp.Exception
{
    public class MissingOperationException: System.Exception
    {
        public MissingOperationException()
        {
        }
        public MissingOperationException(string message)
            : base(message)
        {
        }
        public MissingOperationException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
