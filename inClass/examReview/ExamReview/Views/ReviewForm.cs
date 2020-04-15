/* ReviewForm.cs
 *  Winform file representing the project specs
 *  
 *  Revision History
 *      Gustavo Bonifacio Rodrigues, 15.04.2020: Created
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp1.Domain;

namespace WindowsFormsApp1
{
    public partial class ReviewForm : Form
    {
        private GBRClass PartOne;
        private List<string> PartTwo;

        public ReviewForm()
        {
            InitializeComponent();
            PartOne = new GBRClass();
            PartTwo = new List<string>();
        }

        // on form load actions
        private void ReviewForm_Load(object sender, EventArgs e)
        {
            // initialize
            txtId.Text = "";
            txtCode.Text = "";
            txtName.Text = "";
            txtInputOne.Text = "";
            txtInputTwo.Text = "";
            txtInputThree.Text = "";
            // focus
            txtId.Focus();
        }

        #region Part One Operation
        // save the part one
        private void btnSavePt1_Click(object sender, EventArgs e) =>
            ValidatePartOne();

        // validate the first part of the form
        private void ValidatePartOne()
        {
            rtxtErrorsPt1.Clear();
            string errors = "";
            // checks for nulls/empty inputs
            string standardNullMessage = " cannot be null.\n";
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                errors += "ID" + standardNullMessage;
            }
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                errors += "Code" + standardNullMessage;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errors += "Name" + standardNullMessage;
            }

            if (string.IsNullOrWhiteSpace(errors))
            {
                // inject values
                PartOne.Id = int.Parse(txtId.Text.Trim());
                PartOne.Code = txtCode.Text.Trim();
                PartOne.Name = txtName.Text.Trim();

                try
                {
                    PartOne.Edit();
                    SavePartOne();
                }
                catch (Exception ex)
                {
                    rtxtErrorsPt1.AppendText(ex.Message);
                }
                return;
            }
            rtxtErrorsPt1.AppendText(errors);
        }


        // Save the instance
        private void SavePartOne()
        {
            // save calls invariant check. save operation.
            try
            {
                PartOne.Add();
                MessageBox.Show("Data was saved.");
                PartOne = new GBRClass();
            }
            catch (Exception ex)
            {
                rtxtErrorsPt1.AppendText(ex.Message);
            }
        }

        // prevents the insertion of any value that is not a digit
        private void DigitsOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        #endregion

        #region Part Two Operation
        // validate the second part of the form
        private void ValidatePartTwo()
        {
            rtxtErrorsPt2.Clear();
            string errors = "";
            // checks for nulls/empty inputs
            string standardNullMessage = " cannot be null.\n";
            if (string.IsNullOrWhiteSpace(txtInputOne.Text))
            {
                errors += "Input 1" + standardNullMessage;
                txtInputOne.Focus();
            }
            if (string.IsNullOrWhiteSpace(txtInputTwo.Text))
            {
                errors += "Input 2" + standardNullMessage;
                txtInputTwo.Focus();
            }
            if (string.IsNullOrWhiteSpace(txtInputThree.Text))
            {
                errors += "Input 3" + standardNullMessage;
                txtInputThree.Focus();
            }

            if (string.IsNullOrWhiteSpace(errors))
            {
                AddToPartTwoList();
                // update the rtxtDisplay
                UpdateDisplay();
            }
            rtxtErrorsPt2.AppendText(errors);
        }

        // update the rtxtDisplay
        private void UpdateDisplay()
        {
            rtxtDisplay.Clear();
            PartTwo.ForEach((item) => rtxtDisplay.AppendText($"{PartTwo.IndexOf(item)} -> " + item));
        }

        // Add elements to the list.
        private void AddToPartTwoList()
        {
            PartTwo.Add(txtInputOne.Text + "\n");
            PartTwo.Add(txtInputTwo.Text + "\n");
            PartTwo.Add(txtInputThree.Text + "\n");
        }

        // revert the list
        private void RevertPartTwoList()
        {
            PartTwo.Reverse();
            var reversedArray = PartTwo.ToArray(); // not sure what to with this...
        }

        // Append inputs 1 to 3 to the display
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ValidatePartTwo();
            UpdateDisplay();
        }

        // Reverse the current List in display @ display box
        private void btnReverse_Click(object sender, EventArgs e)
        {
            RevertPartTwoList();
            UpdateDisplay();
        }
        #endregion
    }
}
