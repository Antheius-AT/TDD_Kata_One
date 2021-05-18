using System;
using System.Collections.Generic;
using System.Linq;
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

        [Test]
        [TestCase("5\n2")]
        [TestCase("1\n5")]
        public void Does_Add_Method_Accept_NewLine_As_Separator(string input)
        {
            var result = Calculator.Add(input);

            var split = input.Split('\n');

            var expected = int.Parse(split[0]) + int.Parse(split[1]);

            Assert.That(expected == result);
        }

        [Test]
        [TestCase("//o\n5o2o3")]
        [TestCase("//+\n5+3+10")]
        public void Does_Method_Support_Different_Delimiters(string input)
        {
            var result = Calculator.Add(input);

            var splitContainingDelimiter = input.Split('\n');
            var delimiter = splitContainingDelimiter.First().Last();
            var numbers = splitContainingDelimiter.Last().Split(delimiter);

            var expected = 0;

            foreach (var item in numbers)
            {
                expected += int.Parse(item);
            }

            Assert.That(expected == result);
        }

        [Test]
        [TestCase("-5,-10,1,-33")]
        public void Does_Calling_Add_With_Negatives_Throw_Exception_With_Correct_Message(string input)
        {
            Assert.Throws(typeof(ArgumentException), () =>
            {
                Calculator.Add(input);
            }, "negatives not allowed: -5, -10, 1, -33");
        }

        [Test]
        public void Does_Add_Ignore_Numbers_Greater_Than_1000()
        {
            var result = Calculator.Add("1,1001,1002,1003,2000,3456");

            Assert.That(result == 1);
        }
    }
}