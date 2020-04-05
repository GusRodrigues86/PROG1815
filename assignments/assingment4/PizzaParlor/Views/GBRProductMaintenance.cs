/* Assignment 4
 * GBRProductMaintenance.cs
 * Form structure and events
 * 
 * Revision History
 *      Gustavo Bonifacio Rodrigues, 2020.03.30: Created
 */
using PizzaParlor.GBRClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace PizzaParlor
{
    public partial class GBRProductMaintenance : Form
    {
        /// <summary>
        /// Force culture invariant.
        /// </summary>
        private static CultureInfo CULTURE = new CultureInfo("en-CA", false);
        public GBRProductMaintenance()
        {
            InitializeComponent();
        }

        // actions when the form loads
        private void GBRProductMaintenance_Load(object sender, EventArgs e)
        {
            ReloadListBox();
            ClearErrors();
        }
        // Clears all form fields and selections in the list box, if any. Focus return name textbox
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearErrors();
            txtName.Clear();
            txtDescription.Clear();
            txtPrice.Clear();
            txtFactor.Clear();
            chkTopping.Checked = false;
            txtName.Focus();
        }

        // save a new product or update the current product
        private void btnSave_Click(object sender, EventArgs e)
        {
            ClearErrors();
            try
            {
                ValidateForm();
                // if valid... instantiate and save.
                string inputName = txtName.Text + "".Trim(), inputDescription = txtDescription.Text + "".Trim(), inputPrice = txtPrice.Text + "".Trim(), inputFactor = txtFactor.Text + "".Trim();
                var product = GBRProduct.Parse(inputName + "\t" + inputPrice + "\t" + inputFactor + "\t" + chkTopping.Checked.ToString() + "\t" + inputDescription);
                if (GBRProduct.GBRGetByProductName(inputName) is null)
                {
                    product.GBRAdd(product);
                    lblErrors.Text = $"Add {inputName} to file successfully.";
                    ReloadListBox(inputName);
                    //lstProducts.SelectedValue = inputName;
                }
                else
                {
                    DialogResult result = MessageBox.Show($"Do you want to update the product {inputName}?", "Update product", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        product.GBRUpdate(product);
                        lblErrors.Text = $"Updated {inputName} to file successfully.";
                        ReloadListBox(inputName);
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrors.Text += ex.Message;
            }

        }

        // calls to delete the product with that name
        private void btnDelete_Click(object sender, EventArgs e)
        {
            ClearErrors();
            // get the name of the product to be deleted
            string inputName = txtName.Text + "".Trim();
            if (string.IsNullOrWhiteSpace(inputName))
            {
                lblErrors.Text = "Need a name to remove.\n";
                return;
            }
            List<GBRProduct> products = (List<GBRProduct> )lstProducts.DataSource;
            GBRProduct inFile = products.FirstOrDefault(p => p.ProductName.ToLower().Equals(inputName.ToLower()));
            if (inFile is null )
            {
                lblErrors.Text = "Product doesn't exist.\n";
                return;
            }
            try
            {
                inFile.GBRDelete(inFile);
                ReloadListBox();
                lblErrors.Text = $"{inputName} was successfully deleted.\n";
            }
            catch (Exception ex)
            {
                lblErrors.Text = ex.Message;
            }
        }

        // Cancel any changes in the form and revert state
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearErrors();
            // just reload the form with the current list item selected
            ReloadListBox(lstProducts.SelectedValue.ToString());
            lblErrors.Text = "Operation canceled.\n";
        }

        // Closes the form
        private void btnClose_Click(object sender, EventArgs e) =>
            this.Close();

        // Use case of selecting some item in the list box
        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearErrors();
            var input = lstProducts.SelectedValue.ToString();
            var product = GBRProduct.GBRGetByProductName(input);
            if (product is null)
            {
                lblErrors.Text = "Can't find the product.\n";
            }
            else
            {
                FillTheForm(product);
            }
        }

        // Prevent the insertion of any char that is not a digit and only one .
        private void DigitsWithDecimals(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox) sender;// safecast
            char input = e.KeyChar;
            // checks for .
            if (input == 46 && textBox.Text.IndexOf('.') != -1) // already has digits.
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(input) && input != 8 && input != 46) // digits, dot or backspace
            {
                e.Handled = true;
            }
        }

        // Clears the error labels
        private void ClearErrors() =>
            lblErrors.Text = "";

        // Reloads the list box using a optional key
        private void ReloadListBox(string key = "")
        {
            List<GBRProduct> products = GBRProduct.GBRGetProducts();
            products = products.OrderBy(p => p.ProductName).ToList();

            lstProducts.DisplayMember = "ProductName";
            lstProducts.ValueMember = "ProductName";
            lstProducts.DataSource = products;

            if (key != "")
            {
                lstProducts.SelectedValue = key;
            }
        }

        // Fill the form with the Product information
        private void FillTheForm(GBRProduct product)
        {
            ClearErrors();
            txtName.Text = product.ProductName;
            txtPrice.Text = product.Price.ToString("F2", CULTURE.NumberFormat);
            txtFactor.Text = product.CostFactorForToppings.ToString("F2", CULTURE.NumberFormat);
            txtDescription.Text = product.Description;
            chkTopping.Checked = product.IsPizzaTopping;
        }


        // Attempt validation
        private void ValidateForm()
        {
            string errors = "";
            string inputName = txtName.Text + "".Trim(), inputDescription = txtDescription.Text + "".Trim(), inputPrice = txtPrice.Text + "".Trim(), inputFactor = txtFactor.Text + "".Trim();

            // name validation
            if (string.IsNullOrWhiteSpace(inputName))
            {
                errors += "Need a product name.\n";
            }

            // description validation
            if (string.IsNullOrWhiteSpace(inputDescription))
            {
                errors += "Need a product description.\n";
            }
            // price validation
            if (string.IsNullOrWhiteSpace(inputPrice))
            {
                errors += "Need a price for this product.\n";
            }

            // factor validation
            if (string.IsNullOrWhiteSpace(inputFactor))
            {
                errors += "Need a Topping factor for this product.\n";
            }

            if (!string.IsNullOrWhiteSpace(errors))
            {
                throw new Exception(errors);
            }
        }
    }
}
