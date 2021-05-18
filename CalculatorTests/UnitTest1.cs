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
            var result = Calculator.Add(input);

            var split = input.Split(",");
            var expected = int.Parse(split[0]) + int.Parse(split[1]);

            Assert.That(expected == result);
        }

        [Test]
        public void Does_Input_Empty_Result_In_Zero()
        {
            var result = Calculator.Add(string.Empty);

            Assert.That(0 == result);
        }
    }
}