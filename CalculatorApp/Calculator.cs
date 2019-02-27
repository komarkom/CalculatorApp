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
        private IInputValidate InputValidate { get; set; }
        private IInputSeparate InputSeparate { get; set; }
        private IInputConverterToReversPolishNotation InputConverterToReversPolishNotation { get; set; }
        private readonly ResolvedOperations _resolvedOperations;
        private ICollection<string> DecimalDelimiters { get; set; }

        public Calculator()
        {
            InputValidate = new InputValidate();
            InputSeparate = new InputSeparate();
            InputConverterToReversPolishNotation = new ConverterToReversPolishNotation();
            _resolvedOperations = new ResolvedOperations();

            DecimalDelimiters = new List<string>() {",", "."};
        }

        public Calculator(IInputValidate inputValidate, IInputSeparate inputSeparate,
            IInputConverterToReversPolishNotation inputConverterToReversPolishNotation,
            ResolvedOperations resolvedOperations)
        {
            InputValidate = inputValidate;
            InputSeparate = inputSeparate;
            _resolvedOperations = resolvedOperations;
            InputConverterToReversPolishNotation = inputConverterToReversPolishNotation;
            DecimalDelimiters = new List<string>() {",", "."};
        }

        public double? Evaluate(string statement)
        {
            try
            {
                if (!InputValidate.IsValid(statement))
                    throw new ArgumentException();

                List<string> separatedInput = InputSeparate.SeparateString(statement, _resolvedOperations).ToList();
                if (separatedInput.Count == 0)
                    throw new SeparateException();

                List<string> notationstring = InputConverterToReversPolishNotation
                    .Convert(separatedInput, _resolvedOperations).ToList();
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
            var strOperation = _resolvedOperations.Operations.Select(x => x.OperatorStr).ToList();
            foreach (var statement in reversPolishNotation)
            {
                if (strOperation.Contains(statement))
                {
                    if (!(double.TryParse(stack.Pop(), out var second) && double.TryParse(stack.Pop(), out var first)))
                        throw new FormatException();

                    var operation = _resolvedOperations.Operations.FirstOrDefault(x => x.OperatorStr == statement)?.Operation;
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
