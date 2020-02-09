/* Assignment 2
 * Interface representing the Book Domain Object
 * 
 * Revision History
 *      Gustavo Bonifacio Rodrigues, 2020.02.05: Created
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public interface IBook
    {
        /// <summary>
        /// The title of the book
        /// </summary>
        string BookTitle { get; set; }
        /// <summary>
        /// The 13 digit ISBN number
        /// </summary>
        int BookISBN { get; set; }
        string BookAuthor { get; set; }
        /// <summary>
        /// The published date for the book. must be <= than Today.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">If date exceed todays date.</exception>
        DateTime BookPublishedDate { get; set; }
    }
}
