using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp;
using CalculatorApp.Exception;

namespace CalculatorApp.Test
{
    [TestClass]
    public class CalculatorAppUnitTest
    {
        private readonly Calculator _calculator = new DefaultCalculator();

        [TestMethod]
        public void SingleSum()
        {
            string input = "2+3";
            double? expectedResult = 5;

            var actualResult = _calculator.Evaluate(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SingleSub()
        {
            string input = "4-6";
            double? expectedResult = -2;

            double? actualResult  = _calculator.Evaluate(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SingleMul()
        {
            string input = "2*3";
            double? expectedResult = 6;

            double? actualResult  = _calculator.Evaluate(input);

            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestMethod]
        public void SingleDiv()
        {
            string input = "12/3";
            double? expectedResult = 4;

            double? actualResult  = _calculator.Evaluate(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SimpleAddMul()
        {
            string input = "2+3*4";
            double? expectedResult = 14;

            double? actualResult  = _calculator.Evaluate(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void MinusFirst()
        {
            string input = "-12+3";
            double? expectedResult = -9;

            double? actualResult  = _calculator.Evaluate(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void MinusAfterBrackets()
        {
            string input = "1+(-12+3)";
            double? expectedResult = -8;

            double? actualResult  = _calculator.Evaluate(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void PlusFirst()
        {
            string input = "+12+3";
            double? expectedResult = 15;

            double? actualResult  = _calculator.Evaluate(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void MulFirst()
        {
            string input = "*12+3";
            double? expectedResult = 3;

            double? actualResult  = _calculator.Evaluate(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void DivFirst()
        {
            string input = "/4+3";
            double? expectedResult = 3;

            double? actualResult  = _calculator.Evaluate(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AllOperationWithoutBrackets()
        {
            string input = "10/2-7+3*2*4";
            double? expectedResult = 22;

            double? actualResult  = _calculator.Evaluate(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AllOperationWithBrackets()
        {

            string input = "10/(2-7+3)*4";
            double? expectedResult = -20;

            double? actualResult  = _calculator.Evaluate(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void BracketsWithInnerBrackets()
        {

            string input = "(2-(7+3))*2";
            double? expectedResult = -16;

            double? actualResult  = _calculator.Evaluate(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void DecimalPoint()
        {
            string input = "22/3*3.0480";
            double? expectedResult = 22.352;

            double? actualResult  = _calculator.Evaluate(input);

            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestMethod]
        public void ManyDecimal()
        {
            string input = "22/4*2.159+1.11-0.11";
            double? expectedResult = 12.8745;

            double? actualResult  = _calculator.Evaluate(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void DecimalComma()
        {
            string input = "22/4*2,159";
            double? expectedResult = 11.8745;

            double? actualResult  = _calculator.Evaluate(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrentInputStatement))]
        public void IncorrectBracketsClosedBeforeOpened()
        {
            string input = "- 12)1//(";
            _calculator.Evaluate(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidBracketsException))]
        public void MissingBrackets()
        {
            string input = "(12*(5-1)";
            _calculator.Evaluate(input);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void ZeroDivision()
        {
            string input = "10/(5-5)";
            _calculator.Evaluate(input);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivZeroByZero()
        {
            string input = "0/0";
            _calculator.Evaluate(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NullInput()
        {
            string input = null;
            _calculator.Evaluate(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyInput()
        {
            string input = "";
            _calculator.Evaluate(input);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void OddPointInput()
        {
            string input = "5+41..1-6";
            _calculator.Evaluate(input);
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrentInputStatement))]
        public void OddPlusInput()
        {
            string input = "5++41-6";
            _calculator.Evaluate(input);
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrentInputStatement))]
        public void OddMinusInput()
        {
            string input = "5--41-6";
            _calculator.Evaluate(input);
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrentInputStatement))]
        public void OddMultInput()
        {
            string input = "5**41-6";
            _calculator.Evaluate(input);
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrentInputStatement))]
        public void OddDivInput()
        {
            string input = "5/*41-6";
            _calculator.Evaluate(input);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void LiteralInput()
        {
            string input = "Hello World";
            _calculator.Evaluate(input);
        }

        [TestMethod]
        public void PowerInput()
        {
            string input = "2^4";
            double? expectedResult = 16;

            double? actualResult  = _calculator.Evaluate(input);

            Assert.AreEqual(expectedResult, actualResult);
        }        
        
        [TestMethod]
        public void EuclideanDivisionInput()
        {
            string input = "7%2";
            double? expectedResult = 1;

            double? actualResult  = _calculator.Evaluate(input);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
