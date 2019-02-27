using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator();
            if (args.Length == 1)
            {
                try
                {
                    Console.WriteLine(calc.Evaluate(args[0]).ToString());
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Incorrect input");
                }
            }
            else
            {
                Console.WriteLine("Enter \"q\" for quit");
                string statement = "";
                do
                {
                    Console.Write("Input statement: ");
                    statement = Console.ReadLine();
                    if(statement == "q")
                        break;
                    try
                    {
                        Console.WriteLine(calc.Evaluate(statement).ToString());
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Incorrect input");
                    }
                } while (true);
            }
        }
    }
}
