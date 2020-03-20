using PurchaseOrder.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PurchaseOrder.Util;
using PurchaseOrder.Domain;
using System.Globalization;
using System.Text.RegularExpressions;

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
                {
                    return;
                }
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
                    ReadExistingRepository(txtFilenameAndPath.Text);
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
                    ReadExistingRepository(txtFilenameAndPath.Text);
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


        // Read file from location and load repository
        private void ReadAndLoadRepository(string path)
        {
            if (File.Exists(path))
            {
                // read and create repo
                ReadExistingRepository(path);
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

        // warns user in case of forcing a new file
        private DialogResult WarnOfOverride() =>
            MessageBox.Show("It will overwrite if the file already exists.", "Overwrite Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

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
                    rtextErrors.AppendText("Path is too long!");
                }
                else if (ex is DirectoryNotFoundException)
                {
                    rtextErrors.AppendText("Couldn't find the directory");
                }
                else
                {
                    rtextErrors.AppendText("Something bad happened.");
                    rtextErrors.AppendText(ex.Message);
                }
            }
            catch (Exception ex)
            {
                if (ex is UnauthorizedAccessException)
                {
                    rtextErrors.AppendText("I'm not authorized to read that file");
                }
                else if (ex is ArgumentException)
                {
                    rtextErrors.AppendText("Invalid file");
                }
                else if (ex is ArgumentNullException)
                {
                    rtextErrors.AppendText("Invalid path and filename");
                }
                else if (ex is NotSupportedException)
                {
                    rtextErrors.AppendText("Not supported");
                }
                else
                {
                    rtextErrors.AppendText("Something bad happened.");
                    rtextErrors.AppendText(ex.Message);
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
                    rtextErrors.AppendText("Path is too long!");
                }
                else if (ex is DirectoryNotFoundException)
                {
                    rtextErrors.AppendText("Couldn't find the directory");
                }
                else
                {
                    rtextErrors.AppendText("Something bad happened.");
                    rtextErrors.AppendText(ex.Message);
                }
            }
            catch (Exception ex)
            {
                if (ex is UnauthorizedAccessException)
                {
                    rtextErrors.AppendText("I'm not authorized to read that file");
                }
                else if (ex is ArgumentException)
                {
                    rtextErrors.AppendText("Invalid file");
                }
                else if (ex is ArgumentNullException)
                {
                    rtextErrors.AppendText("Invalid path and filename");
                }
                else if (ex is NotSupportedException)
                {
                    rtextErrors.AppendText("Not supported");
                }
                else
                {
                    rtextErrors.AppendText("Something bad happened.");
                    rtextErrors.AppendText(ex.Message);
                }
            }

        }

        // Creates a repository from file
        private void ReadExistingRepository(string pathToFiles)
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
                    rtextErrors.AppendText("Path is too long!");
                }
                else if (ex is DirectoryNotFoundException)
                {
                    rtextErrors.AppendText("Couldn't find the directory");
                }
                else
                {
                    rtextErrors.AppendText("Something bad happened.");
                    rtextErrors.AppendText(ex.Message);
                }
            }
            catch (Exception ex)
            {
                if (ex is UnauthorizedAccessException)
                {
                    rtextErrors.AppendText("I'm not authorized to read that file");
                }
                else if (ex is ArgumentException)
                {
                    rtextErrors.AppendText("Invalid file");
                }
                else if (ex is ArgumentNullException)
                {
                    rtextErrors.AppendText("Invalid path and filename");
                }
                else if (ex is NotSupportedException)
                {
                    rtextErrors.AppendText("Not supported");
                }
                else
                {
                    rtextErrors.AppendText("Something bad happened.");
                    rtextErrors.AppendText(ex.Message);
                }
            }

            Repository = new InMemoryRepository(orders);
            UpdateListView();
        }
        // creates a new, empty repository
        private void CreateEmptyRepository()
        {
            Repository = new InMemoryRepository(new List<Purchase>());
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

        // Removes and save repository to file
        private void btnDelete_Click(object sender, EventArgs e)
        {
            rtextErrors.Clear();
            string input = txtDeleteNumber.Text + "".Trim();

            if (!ValidateId(input))
            {
                rtextErrors.AppendText("Invalid ID.");
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
                    // save repository
                    SaveRepositoryToFile();
                    // update
                    UpdateListView();
                }
                MessageBox.Show("Purchase Order successfully removed.", "Purchase order deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Purchase Order not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // remove Item from the repository
        private bool RemoveFromRepository(int toRemove) =>
            Repository.Delete(toRemove);

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
                    rtextErrors.AppendText("Path is too long!");
                    rtextErrors.AppendText($"{path}");
                }
                else if (ex is DirectoryNotFoundException)
                {
                    rtextErrors.AppendText("Couldn't find the directory");
                    rtextErrors.AppendText($"{path}");
                }
                else
                {
                    rtextErrors.AppendText("Something bad happened.");
                    rtextErrors.AppendText(ex.Message);
                }
            }
            catch (Exception ex)
            {
                if (ex is UnauthorizedAccessException)
                {
                    rtextErrors.AppendText("I'm not authorized to read that file");
                    rtextErrors.AppendText($"{path}");
                }
                else if (ex is ArgumentException)
                {
                    rtextErrors.AppendText("Invalid file");
                    rtextErrors.AppendText($"{path}");
                }
                else if (ex is ArgumentNullException)
                {
                    rtextErrors.AppendText("Invalid path and filename");
                    rtextErrors.AppendText($"{path}");
                }
                else if (ex is NotSupportedException)
                {
                    rtextErrors.AppendText("Not supported");
                }
                else
                {
                    rtextErrors.AppendText("Something bad happened.");
                    rtextErrors.AppendText(ex.Message);
                }
            }
        }

        // Validates if the input is a string of digits only.
        private bool ValidateId(string input) =>
            new Regex(@"\d+").IsMatch(input);

    }
}