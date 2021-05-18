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

        [Test]
        [TestCase("5,6,7,8")]
        [TestCase("1,2,3")]
        [TestCase("5,10,20,30,50,60,1,2,3,3,3,3")]
        public void Does_Add_Method_Work_With_Multiple_Numbers(string input)
        {
            var result = Calculator.Add(input);

            var split = input.Split(',');
            var accumulator = 0;

            foreach (var item in split)
            {
                accumulator += int.Parse(item);
            }

            Assert.That(accumulator == result);
        }
    }
}