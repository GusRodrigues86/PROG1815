/* inClass 5 
 *  Person.cs
 *  Representation of a person as spec sheet
 *  
 *  Revision History
 *      Gustavo Bonifacio Rodrigues, 2020.03.25: Created
 */

using System;

namespace inclass5.Domain
{
    /// <summary>
    /// Represents a Person.
    /// The Person object is mutable.
    /// </summary>
    public class Person
    {
        #region Fields
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        #endregion
        #region Properties
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public DateTime DateOfBirth
        {
            // prevents exposure of the dateOfBirth field
            get { return new DateTime(dateOfBirth.Ticks); }
            // prevents shared memory and uncontrollable mutation
            set { dateOfBirth = new DateTime(value.Ticks); }
        }
        #endregion
        #region Constructor
        public Person()
        {
            // prevents null
            this.firstName = string.Empty;
            this.lastName = string.Empty;
        }
        #endregion
        #region Required Method
        /// <summary>
        /// Calculates your age based on a date.
        /// The date to compare cannot be &lt; your date of birth.
        /// </summary>
        /// <param name="dateToCompare">The date to compare.</param>
        /// <returns>Your age in years, as an integer.</returns>
        public int Age() =>
            new DateTime(DateTime.Today.Subtract(dateOfBirth).Ticks).Year - 1;
        #endregion

    }
}
