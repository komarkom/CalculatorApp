using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.Implementation;

namespace CalculatorApp
{
    public class DefaultCalculator : Calculator
    {
        public DefaultCalculator() : base(new InputValidate(), new InputSeparate(), new ConverterToReversPolishNotation(),
            new ResolvedOperations())
        {

        }
    }
}
