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

namespace BookManagementAssignment2.Service
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
            return false;
        }

        /// <summary>
        /// Takes the user input and validates if is a valid phone number.
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
            return false;
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
            return false;
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
            return PascalCase(input.Trim());
        }

        /// <summary>
        /// Converts user input to Pascal Case.
        /// 
        /// <para>The input must be non-null. and without leading or trailing whitespaces.</para>
        /// </summary>
        /// <param name="input">The word to be converted to Pascal Case</param>
        /// <returns>The word that was converted to Pascal Case</returns>
        private static string PascalCase(string input)
        {
            input = input.ToLowerInvariant();
            string[] array = input.Split(' ');

            // for larges input, SB is more efficient than any string concatenation.
            // StringBuilder will never be larger than the original input
            StringBuilder sb = new StringBuilder(input.Length);

            for (int i = 0; i < array.Length; i++)
            {
                char[] temp = array[i].Trim().ToCharArray();
                temp[0] = (char) (temp[0] - 32);
                sb.Append(temp);

                // add whitespace between words
                if ((i + 1) != array.Length)
                {
                    sb.Append(" ");
                }
            }

            return sb.ToString();
        }


    }
}
