/* Assignment 2
 * The Book Domain Object
 * 
 * Revision History
 *      Gustavo Bonifacio Rodrigues, 2020.02.05: Created
 */

using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BookManagementAssignment2Tests")]
namespace DomainLayer
{
    /// <summary>
    /// Domain class representing a book, with Title, Author, ISBN and published date.
    /// </summary>
    public class Book : IBook
    {
        #region Class Fields
        private string Title;
        private int ISBN;
        private string Author;
        private DateTime PublishedDate;
        #endregion

        #region Interface Properties
       
        /// <inheritdoc />
        public string BookTitle
        {
            get 
            { 
                if (String.IsNullOrWhiteSpace(this.Title))
                {
                    return String.Empty;
                }
                else
                {
                    return this.Title;
                }
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                { 
                    this.Title = String.Empty; 
                }
                else
                { 
                    this.Title = value; 
                }
            }
        }
        /// <inheritdoc/>
        public int BookISBN
        {
            get => ISBN;
            set => ISBN = value;
        }
        /// <inheritdoc/>
        public string BookAuthor
        {
            get 
            { 
                if (String.IsNullOrWhiteSpace(Author))
                {
                    return String.Empty;
                }
                else
                {
                    return this.Author;
                }
            }
            set 
            { 
                if (String.IsNullOrWhiteSpace(value))
                {
                    this.Author = String.Empty;
                }
                else
                {
                    this.Author = value;
                }
            }
        }
        /// <inheritdoc/>
        public DateTime BookPublishedDate
        {
            get { throw new NotImplementedException(); }
            set 
            {
                if (DateTime.Today < value)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    this.BookPublishedDate = value;
                }
                
            }
        }
        #endregion
    }
}
