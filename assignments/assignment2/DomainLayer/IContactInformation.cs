/* Assignment 2
 * The Interface Representing all fields of the Domain Object
 * 
 * Revision History
 *      Gustavo Bonifacio Rodrigues, 2020.02.05: Created
 */
namespace DomainLayer
{
    public interface IContactInformation
    {
        /// <summary>
        /// The Mailing address
        /// </summary>
        string ContactInformationMailingAddress { get; set; }
        /// <summary>
        /// The Street or Rural Route
        /// </summary>
        string ContactInformationStreetOrRoute { get; set; }
        /// <summary>
        /// The Town or County
        /// </summary>
        string ContactInformationTown { get; set; }
        /// <summary>
        /// The Country
        /// </summary>
        string ContactInformationCountry { get; set; }
        /// <summary>
        /// The Province
        /// </summary>
        string ContactInformationProvince { get; set; }
        /// <summary>
        /// The Postal Code
        /// </summary>
        string ContactInformationPostalCode { get; set; }
        /// <summary>
        /// The Home phone number
        /// </summary>
        string ContactInformationHomePhone { get; set; }
        /// <summary>
        /// The Cellphone number
        /// </summary>
        string ContactInformationCellPhone { get; set; }
        /// <summary>
        /// The email address
        /// </summary>
        string ContactInformationEmail { get; set; }
    }
}