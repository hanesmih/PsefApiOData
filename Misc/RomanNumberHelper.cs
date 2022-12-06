using System.Collections.Generic;
using System.Text;

namespace PsefApiOData.Misc
{
    /// <summary>
    /// Roman Number Conversion helpers.
    /// https://stackoverflow.com/questions/7040289/converting-integers-to-roman-numerals
    /// </summary>
    public static class RomanNumberHelper
    {
        /// <summary>
        /// Converts number to roman number.
        /// </summary>
        /// <param name="number">Roman number to convert.</param>
        /// <returns>Roman number.</returns>
        public static string ToRomanNumber(int number)
        {
            StringBuilder roman = new StringBuilder();

            foreach (KeyValuePair<int, string> item in _numberToRoman)
            {
                while (number >= item.Key)
                {
                    roman.Append(item.Value);
                    number -= item.Key;
                }
            }

            return roman.ToString();
        }

        /// <summary>
        /// Converts roman number to number.
        /// </summary>
        /// <param name="roman">Roman number to conver.</param>
        /// <returns>Number.</returns>
        public static int FromRomanNumber(string roman)
        {
            int total = 0;
            int current, previous;
            char currentRoman, previousRoman = '\0';

            for (int i = 0; i < roman.Length; i++)
            {
                currentRoman = roman[i];
                previous = previousRoman != '\0' ? _romanToNumber[previousRoman] : '\0';
                current = _romanToNumber[currentRoman];

                if (previous != 0 && current > previous)
                {
                    total = total - (2 * previous) + current;
                }
                else
                {
                    total += current;
                }

                previousRoman = currentRoman;
            }

            return total;
        }

        private static readonly Dictionary<char, int> _romanToNumber = new Dictionary<char, int>
    {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 },
    };
        private static readonly Dictionary<int, string> _numberToRoman = new Dictionary<int, string>
    {
        { 1000, "M" },
        { 900, "CM" },
        { 500, "D" },
        { 400, "CD" },
        { 100, "C" },
        { 90, "XC" },
        { 50, "L" },
        { 40, "XL" },
        { 10, "X" },
        { 9, "IX" },
        { 5, "V" },
        { 4, "IV" },
        { 1, "I" },
    };
    }
}