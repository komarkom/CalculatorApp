using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CalculatorApp.Exception;
using CalculatorApp.Interface;

namespace CalculatorApp.Implementation
{
    public class InputSeparate : IInputSeparate
    {
        public IEnumerable<string> SeparateString(string input, ResolvedOperations resolvedOperations)
        {
            input = input.Replace(" ", "").Replace(",", ".");

            List<string> res = new List<string>();
            var operators = resolvedOperations.Operations;
            var brackets = resolvedOperations.BracketsPair;
            var operatorsSymbol = operators.Select(x => x.OperatorStr).ToList();
            var allResolvedSymbol = operatorsSymbol;
            allResolvedSymbol.Add(brackets.OpenBracket.OperatorStr);
            allResolvedSymbol.Add(brackets.CloseBracket.OperatorStr);
            int pos = 0;
            int openCount = 0, closeCount = 0;

//            if (operatorsSymbol.Contains(input[pos].ToString()))
//                input = "0" + input;
            while (pos < input.Length)
            {
                string s = "" + input[pos];
                if (s.Equals(brackets.OpenBracket.OperatorStr))
                    openCount++;
                else if (s.Equals(brackets.CloseBracket.OperatorStr))
                    closeCount++;
                if (!allResolvedSymbol.Contains(input[pos].ToString()))
                {
                    if (Char.IsDigit(input[pos]))
                    {
                        for (int i = pos + 1; i < input.Length && (Char.IsDigit(input[i]) || input[i] == '.'); i++)
                            s += input[i];
                    }
                }
                res.Add(s);
                pos += s.Length;
            }

            if (openCount != closeCount)
                throw new InvalidBracketsException($"Brackets count: open - {openCount}, close - {closeCount}");
            return res;
        }
    }
}