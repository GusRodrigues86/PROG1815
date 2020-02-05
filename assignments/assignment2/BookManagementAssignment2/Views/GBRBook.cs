/* Assignment 2
 * 
 * Revision History
 *      Gustavo Bonifacio Rodrigues, 2020.01.31: Created
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BookManagementAssignment2.Service.GBRValidation; // validator service as static import

namespace BookManagementAssignment2
{
    public partial class MainForm : Form
    {
        private bool HasErrors;
        public MainForm()
        {
            this.HasErrors = false;
            InitializeComponent();
            lblErrors.Text = "";
        }

        /// <summary>
        /// Pre-fill the form with valid information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrefillForm(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Validate the form. If all data is valid, then submits the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmitForm(object sender, EventArgs e)
        {
            ValidateForm();
            if (this.HasErrors)
            {
                return;
            }

        }

        /// <summary>
        /// Closes the actual form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseForm(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Validates the user input.
        /// 
        /// Mutates the value of the TextBox to Pascal Case, without punctuation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGrammerValidation(object sender, EventArgs e)
        {
            TextBox input = (TextBox) sender;
            input.Text = GBRTitleGrammer(input.Text);
        }

        /// <summary>
        /// Only allows digits
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnlyDigitInput(object sender, KeyPressEventArgs e)
        {
            // IsControl are "non printable" char (less than 32 in the ascii table)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // signals that it was handled
            }
        }

        /// <summary>
        /// Validates the form
        /// </summary>
        private void ValidateForm()
        {
            lblErrors.Text = "";
            this.HasErrors = false; // reset state

            // Book title
            if (!ValidateBookTitle(txtBookTitle))
            {
                this.HasErrors = true;
                errorProvider.SetError(txtBookTitle, "Book title cannot be empty.");
                lblErrors.Text += "Book title cannot be empty.\r\n";
            }
            // ISBN
            if (!ValidateISBN(txtISBN))
            {
                this.HasErrors = true;
                errorProvider.SetError(txtISBN, "ISBN code invalid / required");
                lblErrors.Text += "ISBN code invalid / required.\r\n";
            }
            // Author Name
            if (!ValidateAuthor(txtAuthorFullName))
            {
                this.HasErrors = true;
                errorProvider.SetError(txtAuthorFullName, "Author full name required");
                lblErrors.Text += "Author full name required.\r\n";
            }
            // Validate email. if email is invalid, check required fields for validation
            if (!ValidateEmail(txtEmail))
            {
                bool validAddress = true;
                // check address
                if (!ValidateAddress(txtStreetRRoute))
                {
                    validAddress = false;
                    errorProvider.SetError(txtStreetRRoute, "Street/Rural Routes is required if email is not provided");
                    lblErrors.Text += "Street/Rural Routes is required if email is not provided.\r\n";
                }
                else
                {
                    // town validation
                    if (!ValidateTown(txtTown))
                    {
                        validAddress = false;
                        errorProvider.SetError(txtTown, "Town or county name is required if email is not provided");
                        lblErrors.Text += "Town or county is required if email is not provided.\r\n";
                    }
                }
                
                // postal code if no email
                if (!ValidatePostalCode(txtPostalCode))
                {
                    {
                        validAddress = false;
                        errorProvider.SetError(txtPostalCode, "Postal code is required if email is not provided");
                        lblErrors.Text += "Postal code is required if email is not provided.\r\n";
                    }
                }
                
                if (!validAddress)
                {
                    this.HasErrors = true;
                    errorProvider.SetError(txtEmail, "An email is required");
                    lblErrors.Text += "Email is required.\r\n";
                }
            }
            // validate at least one phone
            if (!ValidatePhone(txtHomePhone) && !ValidatePhone(txtCellPhone))
            {
                this.HasErrors = true;
                errorProvider.SetError(txtHomePhone, "Home phone or cell phone is required");
                errorProvider.SetError(txtCellPhone, "Home phone or cell phone is required");
                lblErrors.Text += "Home phone or cell phone is required.\r\n";
            }

        }


        /// <summary>
        /// Validates the BookTitle
        /// </summary>
        /// <param name="BookTitle"></param>
        /// <returns></returns>
        private static bool ValidateBookTitle(TextBox BookTitle) =>
            (String.IsNullOrWhiteSpace(BookTitle.Text))? false : true;

        /// <summary>
        /// Calls to validate ISBN
        /// </summary>
        /// <param name="ISBN">TextBox with the ISBN</param>
        /// <returns></returns>
        private static bool ValidateISBN(TextBox ISBN) => 
            GBRISBNValidation(ISBN.Text);

        /// <summary>
        /// Validates Author name
        /// </summary>
        /// <param name="AuthorName">TextBox with author name</param>
        /// <returns></returns>
        private bool ValidateAuthor(TextBox AuthorName) => 
            // Needs to Split and see if has two or more name
            (String.IsNullOrWhiteSpace(AuthorName.Text)) ? false : true;

        /// <summary>
        /// Validates the email entered, if any.
        /// </summary>
        /// <param name="EmailBox"></param>
        /// <returns></returns>
        private bool ValidateEmail(TextBox emailBox) =>
            (String.IsNullOrWhiteSpace(emailBox.Text)) ? false : true;

        /// <summary>
        /// Validates the Street or Rural Route
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        private bool ValidateAddress(TextBox address) =>
            (String.IsNullOrWhiteSpace(address.Text)) ? false : true;

        /// <summary>
        /// Validate the supplied town name
        /// </summary>
        /// <param name="town"></param>
        /// <returns></returns>
        private bool ValidateTown(TextBox town) =>
            (String.IsNullOrWhiteSpace(town.Text)) ? false : true;

        /// <summary>
        /// Validates the supplied Postal Code
        /// </summary>
        /// <param name="postalCode"></param>
        /// <returns></returns>
        private bool ValidatePostalCode(TextBox postalCode) =>
            (String.IsNullOrWhiteSpace(postalCode.Text)) ? false : true;

        /// <summary>
        /// Validate the supplied phone number
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        private bool ValidatePhone(TextBox phone) =>
            (String.IsNullOrWhiteSpace(phone.Text)) ? false : true;

    }
}
