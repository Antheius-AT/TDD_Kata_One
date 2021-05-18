using System;

namespace StringCalculator
{
    public static class Calculator
    {
        public static int Add (string numbers)
        {
            var splitNumbers = numbers.Split(',');

            if (splitNumbers.Length == 1)
                return int.Parse(splitNumbers[0]);

            if (splitNumbers.Length == 2)
                return int.Parse(splitNumbers[0]) + int.Parse(splitNumbers[1]);

            throw new ArgumentException();
        }
    }
}
