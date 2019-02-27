using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CalculatorApp.Exception;
using CalculatorApp.Interface;
using CalculatorApp.Implementation;

namespace CalculatorApp
{
    public class Calculator
    {
        public IInputValidate InputValidate { get; set; }
        public IInputSeparate InputSeparate { get; set; }
        public IInputConverterToReversPolishNotation InputConverterToReversPolishNotation { get; set; }
        public readonly ResolvedOperations ResolvedOperations;
        private ICollection<string> DecimalDelimiters { get; set; }

        public Calculator()
        {
            InputValidate = new InputValidate();
            InputSeparate = new InputSeparate();
            InputConverterToReversPolishNotation = new ConverterToReversPolishNotation();
            ResolvedOperations = new ResolvedOperations();

            DecimalDelimiters = new List<string>() {",", "."};
        }

        public Calculator(IInputValidate inputValidate, IInputSeparate inputSeparate,
            IInputConverterToReversPolishNotation inputConverterToReversPolishNotation,
            ResolvedOperations resolvedOperations)
        {
            InputValidate = inputValidate;
            InputSeparate = inputSeparate;
            ResolvedOperations = resolvedOperations;
            InputConverterToReversPolishNotation = inputConverterToReversPolishNotation;
            DecimalDelimiters = new List<string>() {",", "."};
        }

        public double? Evaluate(string statement)
        {
            try
            {
                if (!InputValidate.IsValid(statement))
                    throw new ArgumentException();

                List<string> separatedInput = InputSeparate.SeparateString(statement, ResolvedOperations).ToList();
                if (separatedInput.Count == 0)
                    throw new SeparateException();

                List<string> notationstring = InputConverterToReversPolishNotation
                    .Convert(separatedInput, ResolvedOperations).ToList();
                if (notationstring.Count == 0)
                    throw new ConvertException();

                return Compute(notationstring);
            }
            catch (System.Exception e)
            {
                throw;
            }
        }

        private double? Compute(ICollection<string> reversPolishNotation)
        {
            var stack = new Stack<string>();
            var strOperation = ResolvedOperations.Operations.Select(x => x.OperatorStr).ToList();
            foreach (var statement in reversPolishNotation)
            {
                if (strOperation.Contains(statement))
                {
                    if (!(double.TryParse(stack.Pop(), out var second) && double.TryParse(stack.Pop(), out var first)))
                        throw new FormatException();

                    var operation = ResolvedOperations.Operations.FirstOrDefault(x => x.OperatorStr == statement)?.Operation;
                    if (operation != null)
                        stack.Push(operation(first, second)?.ToString(CultureInfo.InvariantCulture));
                    else throw new MissingOperationException();
                }
                else stack.Push(statement);
            }

            if (!double.TryParse(stack.Pop(), out double result))
                throw new FormatException();
            return result;
        }

    }
}
