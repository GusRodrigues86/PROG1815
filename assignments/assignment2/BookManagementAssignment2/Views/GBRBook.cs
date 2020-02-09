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
using static GBRValidation.Service.GBRValidation; // validator service as static import

namespace BookManagementAssignment2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
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
            // Book parts
            txtBookTitle.Text = "Lord Of The Rings";
            txtISBN.Text = "9780544003415";
            txtAuthorFullName.Text = "J R R Tolkien";
            txtDatePublished.Text = "29 Jul 1954";

            // Contact Information
            txtMailingAddress.Text = "Residential";
            txtStreetRRoute.Text = "123 Test Street";
            txtTown.Text = "Toronto";
            txtCountry.Text = "Canada";
            txtProvinceCode.Text = "ON";
            txtPostalCode.Text = "M1A 3A3";
            txtHomePhone.Text = "416-123-4567";
            txtCellPhone.Text = "647-765-4321";
            txtEmail.Text = "email@test.com";
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
        /// Allows only digits
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
        /// Allow only letters to be tiped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnlyLettersInput(object sender, KeyPressEventArgs e)
        {
            // IsControl are "non printable" char (less than 32 in the ascii table)
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true; // signals that it was handled
            }
        }

        /// <summary>
        /// Appends an error message. The error field is the field that caused the error.
        /// </summary>
        /// <param name="errorField">The field error for comparisson</param>
        /// <param name="errorMessage">The error message to append</param>
        private void AppendErrorMessage(string errorField, string errorMessage)
        {
            if (!lblErrors.Text.Contains(errorField))
            {
                lblErrors.Text += $"{errorMessage}\r\n";

            }
        }


        /// <summary>
        /// Validate the form. If all data is valid, then submits the form.
        /// </summary>
        private void ValidateBeforeSubmit(object sender, EventArgs e)
        {
            lblErrors.Text = "";
            foreach (var control in Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox) control;
                    string textboxTag = textBox.Tag.ToString();

                    #region Non-Empty fields
                    #region Book Title Validation
                    if (textboxTag.Equals("Book Title") &&
                        String.IsNullOrWhiteSpace(textBox.Text.Trim()))
                    {
                        if (String.IsNullOrWhiteSpace(textBox.Text.Trim()))
                        {
                            AppendErrorMessage(textboxTag, $"{textboxTag} can't be empty.");
                            txtBookTitle.Focus(); // force focus to book title
                        }
                    }
                    #endregion
                    #region ISBN Validation
                    if (textboxTag.Equals("ISBN"))
                    {
                        // empty is invalid...
                        if (String.IsNullOrWhiteSpace(textBox.Text.Trim()))
                        {
                            AppendErrorMessage(textboxTag, $"{textboxTag} can't be empty.");
                            txtISBN.Focus();
                        }
                        // validating with validation tools
                        else
                        {
                            if (!GBRISBNValidation(textBox.Text.Trim()))
                            {
                                AppendErrorMessage(textboxTag, $"Invalid {textboxTag}. " +
                                    $"It must contains 13 digits");
                                txtISBN.Focus();
                            }
                        }
                    }
                    #endregion
                    #region Author Name Validation
                    if (textboxTag.Equals("Author Name"))
                    {
                        if (String.IsNullOrWhiteSpace(textBox.Text.Trim()))
                        {
                            AppendErrorMessage(textboxTag, $"{textboxTag} can't be empty.");
                            txtAuthorFullName.Focus();
                        }
                        #region Full Name Validation
                        else
                        {
                            // author full name validation
                            if (!GBRValidateAuthorName(textBox.Text.Trim())) // single name
                            {
                                AppendErrorMessage("Author full name",
                                    "Author full name required.");
                                txtAuthorFullName.Focus();
                            }
                        }
                        #endregion
                    }
                    #endregion
                    #region Date Published Validation
                    if (textboxTag.Equals("Date Published"))
                    {
                        if (String.IsNullOrWhiteSpace(textBox.Text.Trim()))
                        {
                            AppendErrorMessage(textboxTag, $"{textboxTag} can't be empty.");
                            txtDatePublished.Focus();
                        }
                        #region Date Formatting and Range
                        else
                        {
                            if (!GBRDateValidation(textBox.Text.Trim()))
                            {
                                AppendErrorMessage("Date", "Date invalid. Must be dd mmm yyyy and less than today.");
                                txtDatePublished.Focus();
                            }
                        }
                        #endregion
                    }
                    #endregion
                    #endregion

                    #region Empty Email Validation
                    // if email is not provided:
                    // ... Postal information (street/rural route, province code and postal code) is mandatory
                    if (textboxTag.Equals("Email") &&
                        String.IsNullOrWhiteSpace(textBox.Text.Trim()))
                    {
                        #region Street validation
                        // street
                        if (String.IsNullOrWhiteSpace(txtStreetRRoute.Text))
                        {
                            AppendErrorMessage("Routes",
                                "Street/Rural Routes is required if email is not provided.");
                            txtStreetRRoute.Focus();
                        }
                        #endregion
                        #region Province Code validation
                        // province code
                        if (String.IsNullOrWhiteSpace(txtProvinceCode.Text))
                        {
                            AppendErrorMessage("Province",
                                "Province Code is required if email is not provided.");
                            txtProvinceCode.Focus();
                        }
                        else
                        {
                            txtProvinceCode.Text = txtProvinceCode.Text.ToUpper();
                        }
                        #endregion
                        #region Postal Code validation
                        // postal code
                        if (String.IsNullOrWhiteSpace(txtPostalCode.Text))
                        {
                            AppendErrorMessage("Postal", "Postal Code is required if email is not provided.");
                            txtPostalCode.Focus();
                        }
                        else
                        {
                            PostalCodeValidator(sender, e);
                        }
                        #endregion
                    }
                    #endregion
                    #region Email Validation
                    if (textboxTag.Equals("Email"))
                    {
                        PostalCodeValidator(sender, e);
                        if (!GBRValidateEmail(textBox.Text.Trim()))
                        {
                            AppendErrorMessage(textboxTag, $"The provided Email address is invalid.");
                            txtEmail.Focus();
                        }
                        txtEmail.Text = txtEmail.Text.ToLower();
                    }
                    #endregion
                    #region Phone Validation
                    if (textboxTag.Equals("Phone"))
                    {
                        string homePhone = txtHomePhone.Text;
                        string cellPhone = txtCellPhone.Text;

                        if (String.IsNullOrWhiteSpace(homePhone) &&
                            String.IsNullOrWhiteSpace(cellPhone))
                        {
                            AppendErrorMessage("phone", "Either home or cell phone is required... both are OK also.");
                        }
                        #region Cell phone validation
                        else if (String.IsNullOrWhiteSpace(homePhone) &&
                            !String.IsNullOrWhiteSpace(cellPhone))
                        {
                            if (!GBRPhoneNumberValidation(cellPhone))
                            {
                                AppendErrorMessage("phone", "Cell phone format error.");
                                txtCellPhone.Focus();
                            }
                            else
                            {
                                if (txtCellPhone.Text.Length == 10)
                                {
                                    txtCellPhone.Text = 
                                    cellPhone.Substring(0, 3) + "-"+
                                    cellPhone.Substring(3, 3) + "-" +
                                    cellPhone.Substring(6, 4);
                                }
                                else
                                {
                                    txtCellPhone.Text = txtCellPhone.Text.Replace(" ", "-");
                                    txtCellPhone.Text = txtCellPhone.Text.Replace(".", "-");
                                }
                            }
                        }
                        #endregion
                        #region Home phone validation
                        else if (!String.IsNullOrWhiteSpace(homePhone) &&
                            String.IsNullOrWhiteSpace(cellPhone))
                        {
                            if (!GBRPhoneNumberValidation(homePhone))
                            {
                                AppendErrorMessage("phone", "Home phone format error.");
                                txtHomePhone.Focus();
                            }
                            else
                            {
                                if (txtHomePhone.Text.Length == 10)
                                {
                                    txtHomePhone.Text =
                                    homePhone.Substring(0, 3) + "-" +
                                    homePhone.Substring(3, 3) + "-" +
                                    homePhone.Substring(6, 4);
                                }
                                else
                                {
                                    
                                    txtHomePhone.Text = txtHomePhone.Text.Replace(" ", "-");
                                    txtHomePhone.Text = txtHomePhone.Text.Replace(".", "-");
                                }
                            }
                        }
                        #endregion
                    }
                    #endregion
                }
            }
        }

        /// <summary>
        /// Validates and, if valid, mutates the postal code to upper case.
        /// Otherwise, show error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PostalCodeValidator(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtPostalCode.Text))
            {
                return;
            }
            else
            {
                string postalCode = txtPostalCode.Text;
                if (GBRPostalCodeValidation(ref postalCode))
                {
                    txtPostalCode.Text = postalCode;
                }
                else 
                {
                    AppendErrorMessage("Postal", "Postal Code provided is invalid.");
                    txtPostalCode.Focus();
                }

            }
        }
    }
}

