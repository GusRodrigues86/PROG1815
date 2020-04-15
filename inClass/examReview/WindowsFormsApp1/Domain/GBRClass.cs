/* GBRClass.cs
 *  Class representing the specs file
 *  
 *  Revision History
 *      Gustavo Bonifacio Rodrigues, 15.04.2020: Created
 */
using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1.Domain
{
    /// <summary>
    /// Class complying with Specs file
    /// </summary>
    class GBRClass
    {
        #region static fields
        /// <summary>
        /// enforce invariant for system culture.
        /// </summary>
        private static CultureInfo CULTURE = new CultureInfo("en-CA", false);
        /// <summary>
        /// Path to the file
        /// </summary>
        private const string FILE_NAME = "GBRClass.txt";
        #endregion

        #region Fields
        private int id;
        private string code;
        private string name;
        #endregion

        #region Properties
        /// <summary>
        /// The ID, between 10 and 99
        /// </summary>
        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
        /// <summary>
        /// Punctuation is a single punctuation character. No digits, or letters, or space.
        /// </summary>
        public string Code
        {
            get => this.code;
            set => this.code = value.Trim();
        }
        /// <summary>
        /// The name
        /// </summary>
        public string Name
        {
            get => this.name;
            set => this.name = value.Trim();
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates an instance of the Class with default, non-null values.
        /// </summary>
        public GBRClass()
        {
            this.code = "";
            this.name = "";
        }
        #endregion

        /// <summary>
        /// Checks for the Invariance.
        /// Id must be two digits, non-negative number.
        /// Code must be a punctuation character.
        /// Name must be composed only by letters, case insensitive
        /// </summary>
        public void Edit()
        {
            string errors = "";
            // id must be positive 2 digit.
            if (id < 10 || id > 99)
            {
                errors += "Valid ID range is 10 to 99.\n";
            }
            // code must be a single char length.
            // code must be a punctuation symbol.
            Regex regex = new Regex(@"\p{P}");
            if (string.IsNullOrEmpty(code)  || !regex.IsMatch(code))
            {
                errors += "Invalid code.\n";
            }
            if ( code.Length != 1)
            {
                errors += "Cannot have more than one code.\n";
            }
            regex = new Regex(@"^[a-z]+$", RegexOptions.IgnoreCase);
            if (string.IsNullOrWhiteSpace(name) || !regex.IsMatch(name))
            {
                errors += "Invalid name. Only letters allowed.\n";
            }

            if (!string.IsNullOrWhiteSpace(errors))
            {
                throw new Exception(errors);
            }
        }

        /// <summary>
        /// Appends the current object to the file
        /// </summary>
        public void Add()
        {
            // validate current instance.
            try
            {
                this.Edit();

                using (StreamWriter writer = new StreamWriter(FILE_NAME, true))
                {
                    writer.WriteLine(this.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"The following data is invalid to be saved:\n{ex.Message}");
            }
        }
        public override string ToString()
        {
            return $"{id}\t{code}\t{name}";
        }
    }
}
