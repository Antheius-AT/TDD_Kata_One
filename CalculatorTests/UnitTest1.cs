using NUnit.Framework;
using StringCalculator;

namespace CalculatorTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("1,2")]
        [TestCase("5,6")]
        [TestCase("10,20")]
        public void Does_Numbers_Separated_With_Comma_Return_Add(string input)
        {
            Calculator.Add(input);
        }
    }
}