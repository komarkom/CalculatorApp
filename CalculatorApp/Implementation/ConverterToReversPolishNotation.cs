using System.Collections.Generic;
using System.Linq;
using CalculatorApp.Exception;
using CalculatorApp.Interface;

namespace CalculatorApp.Implementation
{
    public class ConverterToReversPolishNotation : IInputConverterToReversPolishNotation
    {
        public ICollection<string> Convert(ICollection<string> input, ResolvedOperations resolvedOperations)
        {
            Stack<string> stack = new Stack<string>();
            List<string> res = new List<string>();
            var operations = resolvedOperations.Operations.Cast<IResolvedSymbol>().ToList();
            var operationsSymbols = resolvedOperations.Operations.Select(x => x.OperatorStr).ToList();
            var brackets = resolvedOperations.BracketsPair;
            operations.Add(brackets.OpenBracket);
            operations.Add(brackets.CloseBracket);

            var allResolvedSymbol = operations.Select(x => x.OperatorStr).ToList();
            int pos = 0;
            while (pos < input.Count)
            {
                string s = input.ElementAt(pos);
                if (operationsSymbols.Contains(s) && pos > 0 && operationsSymbols.Contains(input.ElementAt(pos - 1)))
                    throw new IncorrentInputStatement();
                if (allResolvedSymbol.Contains(s))
                {
                    if (s.Equals(brackets.CloseBracket.OperatorStr))
                    {
                        if (stack.Count == 0)
                            throw new InvalidBracketsException();

                        string stackElement = stack.Pop();
                        while (!stackElement.Equals(brackets.OpenBracket.OperatorStr) && stack.Count > 0)
                        {
                            res.Add(stackElement);
                            if (stack.Count == 0 && !stackElement.Equals(brackets.OpenBracket.OperatorStr))
                                throw new InvalidBracketsException();
                            stackElement = stack.Pop();
                        }
                    }
                    else if (stack.Count == 0 || s.Equals(brackets.OpenBracket.OperatorStr))
                        stack.Push(s);
                    else if (operations.First(x=>x.OperatorStr.Equals(s)).Priority > operations.First(x=>x.OperatorStr.Equals(stack.Peek())).Priority)
                    {
                        stack.Push(s);
                    }
                    else
                    {
                        res.Add(stack.Pop());
                        stack.Push(s);
                    }
                }
                else
                {
                    res.Add(s);
                }

                pos++;
            }

            while (stack.Count > 0)
                res.Add(stack.Pop());
            return res;
        }
    }
}