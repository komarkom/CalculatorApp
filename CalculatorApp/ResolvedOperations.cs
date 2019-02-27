using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.Implementation;

namespace CalculatorApp
{
    public class ResolvedOperations
    {
        public ResolvedOperations()
        {
            Operations = new List<ResolvedOperation>()
            {
                new ResolvedOperation(){OperatorStr = "+", OperatorStrToRegex = "+",Priority = 1, Operation = (first, second) => first + second },
                new ResolvedOperation(){OperatorStr = "-", OperatorStrToRegex = "-",Priority = 1, Operation = (first, second) => first - second },
                new ResolvedOperation(){OperatorStr = "*", OperatorStrToRegex = "/*",Priority = 2, Operation = (first, second) => first * second },
                new ResolvedOperation(){OperatorStr = "/", OperatorStrToRegex = "//",Priority = 2, Operation = (first, second) => second == 0D ? throw new DivideByZeroException() : (double?) (first / second)
                },
            };

            BracketsPair = new ResolvedBracketsPair()
            {
                OpenBracket = new ResolvedBracket() {OperatorStr = "(", OperatorStrToRegex = "/(", Priority = 0},
                CloseBracket = new ResolvedBracket() {OperatorStr = ")", OperatorStrToRegex = "/)", Priority = 0}

            };
        }

        public ICollection<ResolvedOperation> Operations { get; set; }
        public ResolvedBracketsPair BracketsPair { get; set; }
    }
}
