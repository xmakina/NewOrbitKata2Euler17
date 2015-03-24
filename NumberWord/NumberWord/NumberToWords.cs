namespace NumberWord
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NumberToWords
    {
        private static readonly Dictionary<int, string> NumbersDictionary = new Dictionary<int, string>
                                                                       {
                                                                           { 1, "one" },
                                                                           { 2, "two" },
                                                                           { 3, "three" },
                                                                           { 4, "four" },
                                                                           { 5, "five" },
                                                                           { 6, "six" },
                                                                           { 7, "seven" },
                                                                           { 8, "eight" },
                                                                           { 9, "nine" },
                                                                           { 10, "ten" },
                                                                           { 11, "eleven" },
                                                                           { 12, "twelve" },
                                                                           { 13, "thirteen" },
                                                                           { 14, "fourteen" },
                                                                           { 15, "fifteen" },
                                                                           { 16, "sixteen" },
                                                                           { 17, "seventeen" },
                                                                           { 18, "eighteen" },
                                                                           { 19, "nineteen" },
                                                                           { 20, "twenty" },
                                                                           { 30, "thirty" },
                                                                           { 40, "forty" },
                                                                           { 50, "fifty" },
                                                                           { 60, "sixty" },
                                                                           { 70, "seventy" },
                                                                           { 80, "eighty" },
                                                                           { 90, "ninety" },
                                                                           { 1000, "one thousand" }
                                                                       };

        /// <summary>
        /// Converts a number into words
        /// </summary>
        /// <param name="input">The number to be converted</param>
        /// <returns>The number as words</returns>
        public static string Convert(int input)
        {
            if (input < 1)
            {
                throw new ArgumentException("input must be greater than zero", "input");
            }

            if (input > 1000)
            {
                throw new ArgumentException("input must be less than one thousand", "input");
            }

            if (NumbersDictionary.ContainsKey(input))
            {
                return NumbersDictionary[input];
            }

            var units = input % 10;
            
            // The numbers 11 to 19 do not use the usual format of "xty-y" so we should handle them differently
            var teens = input % 100;
            var tens = (input - units) % 100;

            // Reduce the hundreds down to units so we can convert them and append hundred, rather than grow the dictionary
            var hundreds = ((input - tens - units) % 1000) / 100;

            var result = new StringBuilder();

            if (hundreds > 0)
            {
                result.Append(Convert(hundreds)).Append(" hundred");
            }

            if ((tens > 0 || units > 0) && result.ToString().Length > 0)
            {
                result.Append(" and ");
            }

            if (teens > 0 && teens < 20)
            {
                // The teens are in our dictionary, so they can be converted directly
                result.Append(Convert(teens));
            }
            else
            {
                if (tens > 0)
                {
                    result.Append(Convert(tens));
                }

                if (tens > 0 && units > 0)
                {
                    result.Append("-");
                }

                if (units > 0)
                {
                    result.Append(Convert(units));
                }
            }

            return result.ToString();
        }
    }
}