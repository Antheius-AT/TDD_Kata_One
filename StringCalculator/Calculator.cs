using System;
using System.Linq;

namespace StringCalculator
{
    public static class Calculator
    {
        public static int Add (string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;

            string delimiter = ",";

            if (numbers.StartsWith("//"))
                delimiter = numbers.Replace("//", string.Empty).First().ToString();

            var splitChars = new string[] { "\n", delimiter };
            var splitNumbers = numbers.Replace("//", string.Empty).Split(splitChars, StringSplitOptions.RemoveEmptyEntries);

            var result = 0;

            for (int i = 0; i < splitNumbers.Length; i++)
            {
                result += int.Parse(splitNumbers[i]);
            }

            return result;
        }
    }
}
