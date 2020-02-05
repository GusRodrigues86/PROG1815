﻿/* Assignment 2
 * 
 * Revision History
 *      Gustavo Bonifacio Rodrigues, 2020.01.31: Created
 */

using System;
using static System.String; // static use of String parsers
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace GBRValidation.Service
{
    public static class GBRValidation
    {
        /// <summary>
        /// Takes the user input and validates if is a valid canadian postal code
        /// <para>Valid canadian postal codes are:</para>
        /// <list type="bullet">
        /// <item>A2A2A2</item>
        /// <item>A2A 2A2</item>
        /// </list>
        /// <para>A valid postal code will be formatted to A2A 2A2</para>
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool GBRPostalCodeValidation(ref string input)
        {
            // Canadian Postal code
            Regex regex = new Regex(@"\^[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ]\s?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]$", RegexOptions.IgnoreCase);
            if (regex.IsMatch(input))
            {
                if (input.Length == 6)
                {
                    input = input.Substring(0, 3) + " " + input.Substring(3,3);
                }
                input.ToUpper();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Takes the user input and validates if is a valid phone number. Empty phone number is valid as well
        /// 
        /// <para>Valid phone numbers are valid if:</para>
        /// <para>123-456-7890</para>
        /// <para>123.456.7890</para>
        /// <para>1234567890</para>
        /// </summary>
        /// <param name="input">The supplied phone number to be validated</param>
        /// <returns>True if and only if the phone number matches one of the three
        /// patterns</returns>
        public static bool GBRPhoneNumberValidation(string input)
        {
            if (IsNullOrWhiteSpace(input))
            {
                return true;
            }
            // regex to allow phone numbers as 123 123 1234 with and without whitespaces or white spaced replaced by . or - or combinations of it.
            Regex regex = new Regex(@"^(\d{3})([-\s.])?(\d{3})([-\s.])?(\d{4})$");
            return regex.IsMatch(input);
        }

        /// <summary>
        /// Takes the user input and validates if is a valid ISBN.
        /// 
        /// Will return true if and only if the input is a valid ISBN number 
        /// </summary>
        /// <param name="input">The ISBN to be validated</param>
        /// <returns>True if and only if is a valid ISBN number</returns>
        public static bool GBRISBNValidation(string input)
        {
            if (IsNullOrWhiteSpace(input))
            {
                return true;
            }

            Regex regex = new Regex(@"\d{13}");
            return regex.IsMatch(input);
        }

        /// <summary>
        /// Title Grammer will normalize book title to Pascal Case.
        /// 
        /// <para>The normalized book title has no withspace in the beggining or in the end.</para>
        /// </summary>
        /// <param name="input">The title to be Pascal Cased</param>
        /// <returns>The provided string in Pascal case or an empty string if null.</returns>
        public static string GBRTitleGrammer(string input)
        {
            // input is null -> empty string.
            if (IsNullOrWhiteSpace(input))
            {
                return Empty;
            }
            // input is one character long -> check with 
            // input not null -> trim beggining and end and Pascal Case it.
            input = input.Trim(); // remove any leading and trailing whitespaces.
            input = GBRPunctuationRemover(input);
            return PascalCase(input);
        }

        /// <summary>
        /// Validates if the supplied input has more than two names.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="errorMessage">The error message, if false</param>
        /// <returns></returns>
        public static bool GBRValidateAuthorName(string input, out string errorMessage)
        {
            if (input.Split(' ').Length > 1)
            {
                errorMessage = "";
                return true;
            }
            if (input.Split(' ').Length == 0)
            {
                errorMessage = "Author full name required";
                return false;
            }
            errorMessage = "Need at least one first name and one last name";
            return false;
        }

        /// <summary>
        /// Validates the supplied email
        /// </summary>
        /// <param name="input">User input</param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool GBRValidateEmail(string input)
        {
            try
            {
                MailAddress testEmail = new MailAddress(input);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
            catch (Exception ex) when (ex is ArgumentNullException || ex is ArgumentException)
            {
                return false;
            }
        }

        /// <summary>
        /// Remove any punctuation from the string.
        /// </summary>
        /// <param name="input">the string to</param>
        /// <returns></returns>
        public static string GBRPunctuationRemover(string input) =>
            new Regex(@"\p{P}").Replace(input, " ");

        /// <summary>
        /// Converts user input to Pascal Case.
        /// 
        /// <para>The input must be non-null. and without leading or trailing whitespaces.</para>
        /// </summary>
        /// <param name="input">The word to be converted to Pascal Case</param>
        /// <returns>The word that was converted to Pascal Case</returns>
        private static string PascalCase(string input)
        {
            // we may have empty strings being supplied.
            if (IsNullOrWhiteSpace(input))
            { return Empty; }
            input = input.Trim().ToLowerInvariant();
            string[] array = input.Split(' ');

            // for larges input, SB is more efficient than any string concatenation.
            // StringBuilder will never be larger than the original input
            StringBuilder sb = new StringBuilder(input.Length);

            for (int i = 0; i < array.Length; i++)
            {
                // we may receive a double spaced word.
                if (!IsNullOrWhiteSpace(array[i]))
                {
                    char[] temp = array[i].Trim().ToCharArray();
                    // prevent uppercase digits.
                    if (Char.IsLetter(temp[0]))
                    {
                        temp[0] = (char) (temp[0] - 32);
                    }

                    sb.Append(temp);

                    // add whitespace between words
                    if ((i + 1) != array.Length)
                    {
                        sb.Append(" ");
                    }

                }
            }

            return sb.ToString();
        }


    }
}