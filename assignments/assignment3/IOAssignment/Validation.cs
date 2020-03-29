/* Assignment 3
 * Validation.cs
 *  Helper methods to perform input validation
 *  
 *  Revision History
 *      Gustavo Bonifacio Rodrigues, 2020.03.20: Created
 */
using System;
using System.Text.RegularExpressions;

namespace IOAssignment
{
    /// <summary>
    /// Perform form validation
    /// </summary>
    public static class Validation
    {
        /// <summary>
        /// Validates if the supplied id is composed only of digits.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>True iff the input is composed only of digits.</returns>
        public static bool ValidId(string input) =>
            new Regex(@"^\d+$").IsMatch(input);

        /// <summary>
        /// Validates if the provided date is &lt;= than today.
        /// </summary>
        /// <param name="input">The provided date.</param>
        /// <returns>True iff the date &lt;= today.</returns>
        public static bool ValidDate(DateTime input) =>
            (input.CompareTo(DateTime.Today) <= 0) ? true : false;

        /// <summary>
        /// Validates if the input is not empty or whitespaced.
        /// </summary>
        /// <param name="input">The provided input.</param>
        /// <returns>True iff is not empty or whitespaced.</returns>
        public static bool ValidNonEmptyInput(string input) =>
            !string.IsNullOrWhiteSpace(input);

        /// <summary>
        /// Validates if the provided input is the type of a decimal number, where the dot (.) is used as reference between decimal places.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>True iff is a number, and dot (.) is used as decimal separator.</returns>
        public static bool InputIsDecimal(string input) =>
            new Regex(@"^\d*\.?\d*$").IsMatch(input);

        /// <summary>
        /// Validates if the input is bigger than zero.
        /// </summary>
        /// <param name="input">the input, as double.</param>
        /// <returns>True iff the input is bigger than zero.</returns>
        public static bool IsBiggerThanZero(double input) => 
            input > 0;

        /// <summary>
        /// Validates if the input is bigger than zero.
        /// </summary>
        /// <param name="input">the input, as int.</param>
        /// <returns>True iff the input is bigger than zero.</returns>
        public static bool IsBiggerThanZero(int input) => 
            input > 0;

    }
}
