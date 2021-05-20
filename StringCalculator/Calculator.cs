﻿using System;
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
            string[] delimiterArray = null;

            if (numbers.StartsWith("//["))
            {
                var splitDelimiterArray = new string(numbers.Skip(2).TakeWhile(c => c != '\n').ToArray()).Replace("[", string.Empty).Replace("]", string.Empty).Split(' ');

                if (splitDelimiterArray.Length > 1)
                {
                    delimiterArray = new string[splitDelimiterArray.Length];

                    for (int i = 0; i < delimiterArray.Length; i++)
                    {
                        delimiterArray[i] = splitDelimiterArray[i];
                    }
                }
                else
                    delimiterArray = splitDelimiterArray;

                numbers = new string(numbers.SkipWhile(c => c != '\n').ToArray());
            }

            else if (numbers.StartsWith("//"))
            {
                delimiter = numbers.Replace("//", string.Empty).First().ToString();
                numbers = new string(numbers.Skip(3).ToArray());
            }

            string[] splitChars;

            if (delimiterArray != null)
            {
                splitChars = new string[delimiterArray.Length + 1];
                splitChars[0] = "\n";
                Array.Copy(delimiterArray, 0, splitChars, 1, delimiterArray.Length);
            }
            else
            {
                splitChars = new string[] { "\n", delimiter };
            }

            var splitNumbers = numbers.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);

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
