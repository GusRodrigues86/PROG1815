using PurchaseOrder.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using PurchaseOrder.Util;
using PurchaseOrder.Domain;
using System.Globalization;

namespace IOAssignment
{
    /// <summary>
    /// POTracker represents a form that show all purchase order (PO).
    /// </summary>
    public partial class POTrackerForm : Form
    {
        #region Fields
        // the persistence object
        private InMemoryRepository Repository;
        #region Static fields/Constants
        // culture invariant due system
        private static readonly CultureInfo CULTURE = new CultureInfo("en-CA", false);
        // the program path
        private static readonly string CURRENT_PATH = Directory.GetCurrentDirectory();
        // the default location and filne name
        private const string DEFAULT_FILE = @"\Order\Orders.txt";
        #endregion
        #endregion

        ///<inheritdoc/>
        public POTrackerForm()
        {
            InitializeComponent();
            txtFilenameAndPath.Focus();
        }

        #region Events
        // Load state of the form -> Fields are disable until file is read or created.
        private void POTrackerForm_Load(object sender, EventArgs e)
        {
            datePickerPurchase.Value = DateTime.Today;
            LoadMode(true);
            rtextErrors.Clear();
            txtFilenameAndPath.AppendText(CURRENT_PATH + DEFAULT_FILE);
        }

        // Create/Open Btn is pressed
        private void CreateOpen_Click(object sender, EventArgs e)
        {
            // clean errors
            rtextErrors.Clear();

            bool overwriteFile = false;
            txtFilenameAndPath.Text += "";
            var caller = (Button) sender;
            // warns of override in new file
            if (radioCreateNew.Checked || caller.Tag != null)
            {
                if (WarnOfOverride() == DialogResult.No)
                { return; }
            }

            // checks the type of file creation
            if (String.IsNullOrWhiteSpace(txtFilenameAndPath.Text))
            {
                string defaultPathFile = CURRENT_PATH + DEFAULT_FILE;
                txtFilenameAndPath.Text = defaultPathFile;
                // dir doesn't exists...
                CreateFolder(CURRENT_PATH + @"\Order");

                if (radioCreateNew.Checked)
                {
                    CreateFile(defaultPathFile, overwriteFile);
                }
                ReadAndLoadRepository(defaultPathFile);

            }
            // otherwise, try to read file
            else
            {
                string path = txtFilenameAndPath.Text.Trim();
                // after file is read, create repository
                if (File.Exists(path))
                {
                    // read and create repo
                    ReadRepositoryFromFile(txtFilenameAndPath.Text);
                    LoadMode(false);
                    return;
                }
                else
                {
                    if (path.Contains(".txt"))
                    {
                        path = txtFilenameAndPath.Text.Substring(0, txtFilenameAndPath.Text.LastIndexOf('\\'));
                    }
                    else
                    {
                        txtFilenameAndPath.Text += @"\Orders.txt";
                    }

                    CreateFolder(path);
                    // creates an Order.txt file in the location.
                    CreateFile(txtFilenameAndPath.Text, false);
                    ReadRepositoryFromFile(txtFilenameAndPath.Text);
                    LoadMode(false);
                    return;
                }
            }
        }

        // selects item from the list
        private void listPurchaseData_SelectedIndexChanged(object sender, EventArgs e)
        {
            var numberCulture = CULTURE.NumberFormat;

            // safecast to purchase
            try
            {
                var selectedItem = (Purchase) listPurchaseData.SelectedItems[0].Tag;
                txtIdNumber.Text = selectedItem.GetId().ToString();
                datePickerPurchase.Value = selectedItem.GetDate();
                txtFrom.Text = selectedItem.GetSeller();
                txtTo.Text = selectedItem.GetShippedTo();
                txtDescription.Text = selectedItem.GetDescription();
                txtOrdered.Text = selectedItem.GetOrdered().ToString("F2", numberCulture);
                comboUnit.SelectedIndex = 0;
                txtPrice.Text = selectedItem.GetUnitPrice().ToString("F2", numberCulture);
            }
            catch (Exception)
            {
                // do nothing. just clicked on a empty row.
            }
        }

        // Closes the form
        private void btnClose_Click(object sender, EventArgs e) =>
            Application.Exit();

        // updates the form
        private void btnDisplayOrders_Click(object sender, EventArgs e) =>
            UpdateListView();



        // Removes and save repository to file
        private void btnDelete_Click(object sender, EventArgs e)
        {
            rtextErrors.Clear();
            string input = txtDeleteNumber.Text + "".Trim();

            if (!Validation.ValidId(input))
            {
                rtextErrors.AppendText("Invalid ID.\n");
                txtDeleteNumber.Focus();
                return;
            }
            int purchaseId = int.Parse(input);
            // number must exists in the repository
            if (Repository.FindById(purchaseId))
            {
                // remove
                if (RemoveFromRepository(purchaseId))
                {
                    txtDeleteNumber.Clear();
                    // save repository and update listview
                    SaveAndRefresh();
                }
                MessageBox.Show("Purchase Order successfully removed.", "Purchase order deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Purchase Order not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // Validate form, and if valid, insert and save file
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            { return; }

            var inputId = txtIdNumber.Text;
            Purchase toUpdate = CreatePurchaseOrder();

            if (Repository.FindById(int.Parse(inputId)))
            {
                // update
                Repository.Update(toUpdate);
                SaveAndRefresh();
            }
            else
            {
                // update
                Repository.Create(toUpdate);
                SaveAndRefresh();
            }
        }


        #endregion
        #region Repository work
        // Read file from location and load repository
        private void ReadAndLoadRepository(string path)
        {
            if (File.Exists(path))
            {
                // read and create repo
                ReadRepositoryFromFile(path);
                LoadMode(false);
                return;
            }
            else
            {
                CreateFile(path);
                CreateEmptyRepository();
                LoadMode(false);
                return;
            }
        }

        // remove Item from the repository
        private bool RemoveFromRepository(int toRemove) =>
            Repository.Delete(toRemove);

        // creates a new, empty repository
        private void CreateEmptyRepository()
        {
            Repository = new InMemoryRepository(new List<Purchase>());
        }

        #endregion
        #region File IO
        // saves the current repository to file
        private void SaveRepositoryToFile()
        {
            string path = txtFilenameAndPath.Text + "";
            if (string.IsNullOrWhiteSpace(path))
            {
                path = CURRENT_PATH + DEFAULT_FILE;
                txtFilenameAndPath.Text = path;
            }
            try
            {
                FileUtils.SaveAllRecords<Purchase>(path, Repository.GetAll());
            }
            catch (IOException ex)
            {
                if (ex is PathTooLongException)
                {
                    rtextErrors.AppendText("Path is too long!\n");
                    rtextErrors.AppendText($"{path}\n");
                }
                else if (ex is DirectoryNotFoundException)
                {
                    rtextErrors.AppendText("Couldn't find the directory.\n");
                    rtextErrors.AppendText($"{path}.\n");
                }
                else
                {
                    rtextErrors.AppendText("Something bad happened.\n");
                    rtextErrors.AppendText(ex.Message + "\n");
                }
            }
            catch (Exception ex)
            {
                if (ex is UnauthorizedAccessException)
                {
                    rtextErrors.AppendText("I'm not authorized to read that file.\n");
                    rtextErrors.AppendText($"{path}.\n");
                }
                else if (ex is ArgumentException)
                {
                    rtextErrors.AppendText("Invalid file.\n");
                    rtextErrors.AppendText($"{path}\n");
                }
                else if (ex is ArgumentNullException)
                {
                    rtextErrors.AppendText("Invalid path and filename.\n");
                    rtextErrors.AppendText($"{path}\n");
                }
                else if (ex is NotSupportedException)
                {
                    rtextErrors.AppendText("Not supported.\n");
                }
                else
                {
                    rtextErrors.AppendText("Something bad happened.");
                    rtextErrors.AppendText(ex.Message + "\n");
                }
            }
        }

        // Creates a repository from file
        private void ReadRepositoryFromFile(string pathToFiles)
        {
            List<Purchase> orders = new List<Purchase>();
            try
            {
                // open the stream and creat the list of orders
                using (var stream = FileUtils.FileReader(pathToFiles))
                {
                    string text = stream.ReadLine();
                    while (!String.IsNullOrWhiteSpace(text))
                    {
                        orders.Add(new Purchase(text));
                        text = stream.ReadLine();
                    }

                }

            }
            catch (IOException ex)
            {
                if (ex is PathTooLongException)
                {
                    rtextErrors.AppendText("Path is too long!\n");
                }
                else if (ex is DirectoryNotFoundException)
                {
                    rtextErrors.AppendText("Couldn't find the directory.\n");
                }
                else
                {
                    rtextErrors.AppendText("Something bad happened.\n");
                    rtextErrors.AppendText(ex.Message + "\n");
                }
            }
            catch (Exception ex)
            {
                if (ex is UnauthorizedAccessException)
                {
                    rtextErrors.AppendText("I'm not authorized to read that file.\n");
                }
                else if (ex is ArgumentException)
                {
                    rtextErrors.AppendText("Invalid file.\n");
                }
                else if (ex is ArgumentNullException)
                {
                    rtextErrors.AppendText("Invalid path and filename.\n");
                }
                else if (ex is NotSupportedException)
                {
                    rtextErrors.AppendText("Not supported.\n");
                }
                else
                {
                    rtextErrors.AppendText("Something bad happened.\n");
                    rtextErrors.AppendText(ex.Message + "\n");
                }
            }

            Repository = new InMemoryRepository(orders);
            UpdateListView();
        }

        // Creates a file and catch errors
        private void CreateFile(string pathAndFilename, bool ToOverwrite = false)
        {
            try
            {
                FileUtils.CreateFile(pathAndFilename, ToOverwrite);
            }
            catch (IOException ex)
            {
                if (ex is PathTooLongException)
                {
                    rtextErrors.AppendText("Path is too long!\n");
                }
                else if (ex is DirectoryNotFoundException)
                {
                    rtextErrors.AppendText("Couldn't find the directory\n");
                }
                else
                {
                    rtextErrors.AppendText("Something bad happened.\n");
                    rtextErrors.AppendText(ex.Message + "\n");
                }
            }
            catch (Exception ex)
            {
                if (ex is UnauthorizedAccessException)
                {
                    rtextErrors.AppendText("I'm not authorized to read that file.\n");
                }
                else if (ex is ArgumentException)
                {
                    rtextErrors.AppendText("Invalid file.\n");
                }
                else if (ex is ArgumentNullException)
                {
                    rtextErrors.AppendText("Invalid path and filename.\n");
                }
                else if (ex is NotSupportedException)
                {
                    rtextErrors.AppendText("Not supported.\n");
                }
                else
                {
                    rtextErrors.AppendText("Something bad happened.\n");
                    rtextErrors.AppendText(ex.Message + "\n");
                }
            }

        }

        // Creates a Folder and catch any errors
        private void CreateFolder(string pathToFolder)
        {
            try
            {
                FileUtils.CreateFolder(pathToFolder);
            }
            catch (IOException ex)
            {
                if (ex is PathTooLongException)
                {
                    rtextErrors.AppendText("Path is too long!.\n");
                }
                else if (ex is DirectoryNotFoundException)
                {
                    rtextErrors.AppendText("Couldn't find the directory.\n");
                }
                else
                {
                    rtextErrors.AppendText("Something bad happened.\n");
                    rtextErrors.AppendText(ex.Message + "\n");
                }
            }
            catch (Exception ex)
            {
                if (ex is UnauthorizedAccessException)
                {
                    rtextErrors.AppendText("I'm not authorized to read that file.\n");
                }
                else if (ex is ArgumentException)
                {
                    rtextErrors.AppendText("Invalid file.\n");
                }
                else if (ex is ArgumentNullException)
                {
                    rtextErrors.AppendText("Invalid path and filename.\n");
                }
                else if (ex is NotSupportedException)
                {
                    rtextErrors.AppendText("Not supported.\n");
                }
                else
                {
                    rtextErrors.AppendText("Something bad happened.\n");
                    rtextErrors.AppendText(ex.Message + "\n");
                }
            }

        }

        #endregion
        #region Utility
        // warns user in case of forcing a new file
        private DialogResult WarnOfOverride() =>
            MessageBox.Show("It will overwrite if the file already exists.", "Overwrite Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

        // Creates an Purchase order from a valid form
        private Purchase CreatePurchaseOrder()
        {
            int purchaseId = int.Parse(txtIdNumber.Text.Trim());
            DateTime purchaseDate = datePickerPurchase.Value;
            string purchaseFrom = txtFrom.Text.Trim();
            string purchaseTo = txtTo.Text.Trim();
            string description = txtDescription.Text.Trim();
            double purchaseOrdered = double.Parse(txtOrdered.Text.Trim(), CULTURE.NumberFormat);
            double purchasePrice = double.Parse(txtPrice.Text.Trim(), CULTURE.NumberFormat);
            string unit = comboUnit.SelectedItem.ToString();
            return new Purchase(purchaseId, purchaseDate, purchaseFrom, purchaseTo, purchaseOrdered, comboUnit.SelectedItem.ToString(), purchasePrice, description);
        }
        #endregion
        #region Form tools
        // save repository to file and refresh listview
        private void SaveAndRefresh()
        {
            SaveRepositoryToFile();
            UpdateListView();
        }

        // updates the list view
        private void UpdateListView()
        {
            listPurchaseData.Items.Clear();

            var numberCulture = CULTURE.NumberFormat;

            Repository.GetAll().ForEach((order) =>
            {
                var row = new string[] {
                order.GetId().ToString(),
                order.GetDate().ToString("yyyy-MM-dd"),
                order.GetSeller(),
                order.GetShippedTo(),
                order.GetOrdered().ToString("F2", numberCulture),
                order.GetUnit(),
                order.GetUnitPrice().ToString("C2",numberCulture),
                order.GetBeforeTaxes().ToString("C2",numberCulture),
                order.GetTotal().ToString("C2",numberCulture)
                };
                var rowItem = new ListViewItem(row);
                rowItem.Tag = order;
                listPurchaseData.Items.Add(rowItem);

            });
        }

        // Validates the input form and append 
        private bool ValidateForm()
        {
            rtextErrors.Clear();
            bool hasErrors = false;
            #region Form info
            var inputId = txtIdNumber.Text + "";
            var inputPurchaseDate = datePickerPurchase.Value;
            var inputPurchaseFrom = txtFrom.Text + "";
            var inputPurchaseTo = txtTo.Text + "";
            var inputOrdered = txtOrdered.Text + "";
            var inputPrice = txtPrice.Text + "";
            #endregion

            #region Validation
            if (!Validation.ValidId(inputId))
            {
                hasErrors = true;
                rtextErrors.AppendText("Invalid Id.\n");
            }
            if (!Validation.ValidDate(inputPurchaseDate))
            {
                hasErrors = true;
                rtextErrors.AppendText("Date cannot be in the future.\n");
            }
            if (!Validation.ValidNonEmptyInput(inputPurchaseFrom))
            {
                hasErrors = true;
                rtextErrors.AppendText("Purchase from cannot be empty.\n");
            }
            if (!Validation.ValidNonEmptyInput(inputPurchaseTo))
            {
                hasErrors = true;
                rtextErrors.AppendText("Ship to cannot be empty.\n");
            }
            if (!Validation.InputIsDecimal(inputOrdered))
            {
                hasErrors = true;
                rtextErrors.AppendText("Ammount ordered to cannot be empty.\n");
            }
            else
            {
                if (!Validation.IsBiggerThanZero(double.Parse(inputOrdered)))
                {
                    hasErrors = true;
                    rtextErrors.AppendText("Ammount ordered must be bigger than 0.\n");
                }
            }
            if (!Validation.InputIsDecimal(inputPrice))
            {
                hasErrors = true;
                rtextErrors.AppendText("Unit price cannot be empty.\n");
            }
            else
            {
                if (!Validation.IsBiggerThanZero(double.Parse(inputPrice)))
                {
                    hasErrors = true;
                    rtextErrors.AppendText("Unit price must be bigger than 0.\n");
                }
            }
            #endregion
            return !hasErrors;
        }

        // Set the state of the form for loading.
        private void LoadMode(bool state)
        {
            // insertion fields
            txtIdNumber.Enabled = !state;
            datePickerPurchase.Enabled = !state;
            txtFrom.Enabled = !state;
            txtTo.Enabled = !state;
            txtDescription.Enabled = !state;
            txtOrdered.Enabled = !state;
            comboUnit.SelectedIndex = 0;
            comboUnit.Enabled = !state;
            txtPrice.Enabled = !state;
            // deletion fields
            txtDeleteNumber.Enabled = !state;
            // buttons
            btnInsert.Enabled = !state;
            btnDeletePO.Enabled = !state;
            btnDisplayOrders.Enabled = !state;
            btnEmptyFile.Enabled = !state;
        }
        #endregion

    }
}