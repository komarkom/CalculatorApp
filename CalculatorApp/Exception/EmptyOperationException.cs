namespace CalculatorApp.Exception
{
    public class EmptyOperationException: System.Exception
    {
        public EmptyOperationException()
        {
        }
        public EmptyOperationException(string message)
            : base(message)
        {
        }
        public EmptyOperationException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
