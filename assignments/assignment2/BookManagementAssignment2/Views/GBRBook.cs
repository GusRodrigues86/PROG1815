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
                        }
                        // validating with validation tools
                        else
                        {
                            if (!GBRISBNValidation(textBox.Text.Trim()))
                            {
                                AppendErrorMessage(textboxTag, $"Invalid {textboxTag}. " +
                                    $"It must contains 13 digits");
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
                        }
                        #region Full Name Validation
                        else
                        {
                            // author full name validation
                            if (!GBRValidateAuthorName(textBox.Text.Trim())) // single name
                            {
                                AppendErrorMessage("Author full name",
                                    "Author full name required.");
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
                        }
                        #region Date Formatting and Range
                        else
                        {
                            if (!GBRDateValidation(textBox.Text.Trim()))
                            {

                                AppendErrorMessage("Date", "Date invalid. Must be dd mmm yyyy and less than today.");
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
                        }
                        #endregion
                        #region Province Code validation
                        // province code
                        if (String.IsNullOrWhiteSpace(txtProvinceCode.Text))
                        {
                            AppendErrorMessage("Province",
                                "Province Code is required if email is not provided.");
                        }
                        #endregion
                        #region Postal Code validation
                        // postal code
                        if (String.IsNullOrWhiteSpace(txtPostalCode.Text))
                        {
                            AppendErrorMessage("Postal", "Postal Code is required if email is not provided.");
                        }
                        #endregion
                    }
                    #endregion
                    #region Email Validation
                    if (textboxTag.Equals("Email"))
                    {
                        if (!GBRValidateEmail(textBox.Text.Trim()))
                        {
                            AppendErrorMessage(textboxTag, $"The provided email address is invalid.");
                        }
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
    }
}

