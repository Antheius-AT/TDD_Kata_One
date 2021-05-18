using System;

namespace StringCalculator
{
    public static class Calculator
    {
        public static int Add (string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;

            var splitNumbers = numbers.Split(',');
            var result = 0;

            for (int i = 0; i < splitNumbers.Length; i++)
            {
                result += int.Parse(splitNumbers[i]);
            }

            return result;
        }
    }
}
