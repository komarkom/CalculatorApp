using System;
using CalculatorApp.Interface;

namespace CalculatorApp.Implementation
{
    public class ResolvedOperation : IResolvedSymbol
    {
        public string OperatorStr { get; set; }
        public string OperatorStrToRegex { get; set; }
        public byte Priority { get; set; }

        public delegate double? OperationFunc(double first, double second);
        public OperationFunc Operation { get; set; }
    }
}