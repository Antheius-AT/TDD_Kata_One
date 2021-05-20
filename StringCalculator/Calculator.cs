using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace StringCalculator
{
    public static class Calculator
    {
        /// <summary>
        /// Takes a string representation of numbers and delimiters and returns the result of the calculation.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            var splitInput = SplitInput(input);
            var delimiterPart = splitInput[0];
            var dataPart = splitInput[1];

            var delimiterArray = ParseDelimiters(delimiterPart);
            var numbers = dataPart.Split(delimiterArray, StringSplitOptions.RemoveEmptyEntries);

            var result = DoCalculation(numbers);

            return result;
        }

        /// <summary>
        /// Splits input into delimiter part and data part for easier handling.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string[] SplitInput(string input)
        {
            var delimiterPart = string.Empty;
            var dataPart = string.Empty;

            if (input.StartsWith("//"))
            {
                delimiterPart = new string(input.TakeWhile(c => c != '\n').ToArray());
                dataPart = new string(input.Skip(delimiterPart.Length).ToArray());
            }
            else
            {
                dataPart = input;
            }

            return new string[] { delimiterPart, dataPart };
        }

        /// <summary>
        /// Parses the delimiter part of the input into an array of delimiters.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string[] ParseDelimiters(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new string[] { ",", "\n" };

            if (input.StartsWith("//["))
                return ParseMultiCharDelimiters(input);

            if (input.StartsWith("//"))
                return new string[] { "\n", input.Replace("//", string.Empty) };

            throw new ArgumentException();
        }

        /// <summary>
        /// Parses delimiters consisting of multiple characters.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string[] ParseMultiCharDelimiters(string input)
        {
            var preparedInput = new string(input.Skip(2).ToArray());
            var individualDelimitersArray = preparedInput.Split(' ');
            var parsedDelimiters = new List<string>();

            foreach (var item in individualDelimitersArray)
            {
                parsedDelimiters.Add(item.Replace("[", string.Empty).Replace("]", string.Empty));
            }

            parsedDelimiters.Add("\n");
            return parsedDelimiters.ToArray();
        }

        /// <summary>
        /// Does the calculation based on a string array of numbers as input.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private static int DoCalculation(string[] numbers)
        {
            var result = 0;
            var negatives = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                var current = int.Parse(numbers[i]);

                if (current < 0)
                {
                    negatives.Add(current);
                    continue;
                }

                if (current > 1000)
                    continue;

                result += int.Parse(numbers[i]);
            }

            if (negatives.Count > 0)
                throw new ArgumentException($"negatives not allowed: {negatives}");

            return result;
        }
    }
}
