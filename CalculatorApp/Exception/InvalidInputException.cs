namespace CalculatorApp.Exception
{
    public class IncorrentInputStatement: System.Exception
    {
        public IncorrentInputStatement()
        {
        }
        public IncorrentInputStatement(string message)
            : base(message)
        {
        }
        public IncorrentInputStatement(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
