/* Assignment 2
 * The Contact information Domain
 * 
 * Revision History
 *      Gustavo Bonifacio Rodrigues, 2020.02.05: Created
 */
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("BookManagementAssignment2Tests")]
namespace DomainLayer { 

    public class ContactInformation : IContactInformation
    {
        #region Class Fields
        private string MailingAddress;
        private string StreetOrRoute;
        private string Town;
        private string Country;
        private string Province;
        private string PostalCode;
        private string HomePhone;
        private string CellPhone;
        private string Email;
        #endregion

        #region Properties
        /// <inheritdoc></inheritdoc>
        public string ContactInformationMailingAddress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ContactInformationStreetOrRoute { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ContactInformationTown { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ContactInformationCountry { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ContactInformationProvince { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ContactInformationPostalCode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ContactInformationHomePhone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ContactInformationCellPhone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ContactInformationEmail { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion
    }
}
