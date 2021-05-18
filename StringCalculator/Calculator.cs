using System;
using System.Collections.Generic;
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
            var negatives = new List<int>();

            for (int i = 0; i < splitNumbers.Length; i++)
            {
                var current = int.Parse(splitNumbers[i]);
                if (current < 0)
                {
                    negatives.Add(current);
                    continue;
                }

                if (current > 1000)
                    continue;

                result += int.Parse(splitNumbers[i]);
            }

            if (negatives.Count > 0)
                throw new ArgumentException($"negatives not allowed: {negatives}");

            return result;
        }
    }
}
