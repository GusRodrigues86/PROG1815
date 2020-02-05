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

        }

        /// <summary>
        /// Validate the form. If all data is valid, then submits the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmitForm(object sender, EventArgs e)
        {
            ValidateForm(sender, e); 

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
        private void ValidateForm(object sender, EventArgs e)
        {
            lblErrors.Text = "";
        }

        /// <summary>
        /// Validates the user input for the Author name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAuthorFullNameValidating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            TextBox authorName = (TextBox) sender;
            authorName.Text = GBRTitleGrammer(authorName.Text);
            if (!GBRValidateAuthorName(authorName.Text, out errorMsg))
            {
                e.Cancel = true;
                authorName.Select(0, authorName.Text.Length);

                errorProvider.SetError(txtAuthorFullName, errorMsg);
                appendErrorMessage(errorMsg);
            }
        }

        /// <summary>
        /// Clear any errors in the Author name that has been fixed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAuthorFullNameValidated(object sender, EventArgs e) =>
            errorProvider.SetError(txtAuthorFullName, "");

        private void appendErrorMessage(string errorMessage)
        {
            errorMessage = errorMessage + "\n\r";
            if (!lblErrors.Text.Contains(errorMessage))
            {
                lblErrors.Text += errorMessage;
            }
        }
    }
}
