/* Assignment 2
 * 
 * Revision History
 *      Gustavo Bonifacio Rodrigues, 2020.01.31: Created
 */

using System;
using static System.String; // static use of String parsers
using System.Text;
using System.Text.RegularExpressions;

namespace GBRValidation.Service
{
    /// <summary>
    /// Holds validation methods to be used with Book Form of assignment 2
    /// </summary>
    public static class GBRValidation
    {
        /// <summary>
        /// Validate user date input to format dd mmm yyyy
        /// </summary>
        /// <param name="input">the input in format dd mmm yyyy</param>
        /// <returns></returns>
        public static bool GBRDateValidation(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            Regex dateRegex = new Regex(
                @"^\d{1,2}[\w\s]" + // dd
                @"(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)[\w\s]" +  // mmm
                @"[0-9]{1,4}$", // yyyy
                RegexOptions.IgnoreCase);
            if (!dateRegex.IsMatch(input))
            {
                return false;
            }
            DateTime today = DateTime.Today;
            // if today < provided, invalid
            try
            {
                DateTime provided = DateTime.Parse(input);
                if (DateTime.Compare(today, provided) < 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Takes the user input and validates if is a valid canadian postal code
        /// <para>Valid canadian postal codes are:</para>
        /// <list type="bullet">
        /// <item>A2A2A2</item>
        /// <item>A2A 2A2</item>
        /// </list>
        /// <para>A valid postal code will be formatted to A2A 2A2</para>
        /// </summary>
        /// <param name="input">The user input</param>
        /// <returns>True if and only if the validation is good</returns>
        public static bool GBRPostalCodeValidation(ref string input)
        {
            // Canadian Postal code
            Regex regex = new Regex(@"^[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ]\s?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]$", RegexOptions.IgnoreCase);
            if (regex.IsMatch(input))
            {
                if (input.Length == 6)
                {
                    input = input.Substring(0, 3).ToUpper() + " " + input.Substring(3, 3).ToUpper();
                }
                else
                {
                    input = input.ToUpper();
                }
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
            // regex to allow phone numbers as 123-123-1234
            Regex regex = new Regex(@"^\d{3}[-]\d{3}[-]\d{4}$");
            // regex to allow phone numbers as 123.123.1234
            Regex regex2 = new Regex(@"^\d{3}[.]\d{3}[.]\d{4}$");
            Regex regex3 = new Regex(@"^\d{10}$");
            return (regex.IsMatch(input.Trim()) || regex2.IsMatch(input.Trim()) || regex3.IsMatch(input.Trim()));
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
            return GBRPascalCase(input);
        }

        /// <summary>
        /// Validates if the supplied input has more than two names.
        /// </summary>
        /// <param name="input">the Author name</param>
        /// <returns>True if and only if the author name is compose of 2 or more names</returns>
        public static bool GBRValidateAuthorName(string input)
        {
            input = input.Trim();
            if (input.Split(' ').Length > 1)
            {
                return true;
            }
            if (input.Split(' ').Length == 0)
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// Validates the supplied email. Empty email is also valid.
        /// </summary>
        /// <param name="input">User input</param>
        /// <returns>True if and only if the input is a valid email address</returns>
        public static bool GBRValidateEmail(string input)
        {
            if (IsNullOrWhiteSpace(input))
            {
                return true;
            }
            // this class MailAdress may be terrible option.
            // user@host is a valid email by the mail address docs. tests fails if apply this convention.
            // lets try this MS case
            // https://github.com/Microsoft/referencesource/blob/master/System.ComponentModel.DataAnnotations/DataAnnotations/EmailAddressAttribute.cs
            Regex emailRegex = new Regex(
                @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$"
                , RegexOptions.IgnoreCase);
            if (emailRegex.IsMatch(input))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Validate if the Title is null or whitespaced. Otherwise, true.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool GBRValidateBookTitle(string input) =>
            (IsNullOrWhiteSpace(input)) ? false : true;

        /// <summary>
        /// Remove any punctuation from the string.
        /// </summary>
        /// <param name="input">the string to</param>
        /// <returns></returns>
        public static string GBRPunctuationRemover(string input) =>
            new Regex(@"\p{P}").Replace(input, " ");

        /// <summary>
        /// Converts the supplied string into Pascal Case.
        /// 
        /// <para>The input must be non-null. and without leading or trailing whitespaces.</para>
        /// </summary>
        /// <param name="input">The word to be converted to Pascal Case</param>
        /// <returns>The word that was converted to Pascal Case</returns>
        private static string GBRPascalCase(string input)
        {
            // we may have empty strings being supplied.
            if (IsNullOrWhiteSpace(input))
            {
                return Empty;
            }
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

