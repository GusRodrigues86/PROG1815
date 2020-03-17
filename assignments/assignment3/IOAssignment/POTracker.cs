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

namespace IOAssignment
{
    public partial class POTrackerForm : Form
    {
        private InMemoryRepository repository;
        // culture invariant due system
        private static CultureInfo culture = new CultureInfo("en-CA", false);

        public POTrackerForm()
        {
            InitializeComponent();
        }

        // Load state of the form -> Fields are disable until file is read or created.
        private void POTrackerForm_Load(object sender, EventArgs e)
        {
            datePickerPurchase.Value = DateTime.Today;
            LoadMode(true);
            rtextErrors.Clear();
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

        // Create/Open Btn is pressed
        private void CreateOpenClick(object sender, EventArgs e)
        {
            bool overwriteFile = false;
            txtFilenameAndPath.Text += "";
            string defaultFile = @"\Order\Orders.txt";
            // checks the file name/dir, if none, check for files and try to create a new folder with file
            var currentPath = Directory.GetCurrentDirectory();
            // warns of override in new file
            if (radioCreateNew.Checked)
            {
                var result = WarnOfOverride();
                if (result == DialogResult.Yes)
                {
                    overwriteFile = true;
                }
                else
                {
                    return;
                }
            }
            
            // checks the type of file creation
            if (String.IsNullOrWhiteSpace(txtFilenameAndPath.Text))
            {
                txtFilenameAndPath.Text = currentPath + defaultFile;
                // dir doesn't exists...
                if (!Directory.Exists(currentPath + @"\Order"))
                {
                    CreateFolder(currentPath);
                }

                if (File.Exists(currentPath + defaultFile))
                {
                    // if existing file will be overwriten
                    if (radioCreateNew.Checked)
                    {
                        CreateFile(txtFilenameAndPath.Text, overwriteFile);
                    }
                    // read and create repo
                    ReadExistingRepository(currentPath + defaultFile);
                    LoadMode(false);
                    return;
                }
                else
                {
                    CreateFile(txtFilenameAndPath.Text, overwriteFile);
                    CreateEmptyRepository();
                    LoadMode(false);
                    return;
                }

            }
            // otherwise, try to read file
            else
            {
                // after file is read, create repository
                if (File.Exists(txtFilenameAndPath.Text))
                {
                    // read and create repo
                    ReadExistingRepository(txtFilenameAndPath.Text);
                    LoadMode(false);
                    return;
                }
                else
                {
                    rtextErrors.AppendText("Couldn't find the file.");
                    return;
                }
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
                if (ex.InnerException is PathTooLongException)
                {
                    rtextErrors.AppendText("Path is too long!");
                }
                else if (ex.InnerException is DirectoryNotFoundException)
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
                if (ex.InnerException is UnauthorizedAccessException)
                {
                    rtextErrors.AppendText("I'm not authorized to read that file");
                }
                else if (ex.InnerException is ArgumentException)
                {
                    rtextErrors.AppendText("Invalid file");
                }
                else if (ex.InnerException is ArgumentNullException)
                {
                    rtextErrors.AppendText("Invalid path and filename");
                }
                else if (ex.InnerException is NotSupportedException)
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
                FileUtils.CreateDefaultFolder(pathToFolder);
            }
            catch (IOException ex)
            {
                if (ex.InnerException is PathTooLongException)
                {
                    rtextErrors.AppendText("Path is too long!");
                }
                else if (ex.InnerException is DirectoryNotFoundException)
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
                if (ex.InnerException is UnauthorizedAccessException)
                {
                    rtextErrors.AppendText("I'm not authorized to read that file");
                }
                else if (ex.InnerException is ArgumentException)
                {
                    rtextErrors.AppendText("Invalid file");
                }
                else if (ex.InnerException is ArgumentNullException)
                {
                    rtextErrors.AppendText("Invalid path and filename");
                }
                else if (ex.InnerException is NotSupportedException)
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
                if (ex.InnerException is PathTooLongException)
                {
                    rtextErrors.AppendText("Path is too long!");
                }
                else if (ex.InnerException is DirectoryNotFoundException)
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
                if (ex.InnerException is UnauthorizedAccessException)
                {
                    rtextErrors.AppendText("I'm not authorized to read that file");
                }
                else if (ex.InnerException is ArgumentException)
                {
                    rtextErrors.AppendText("Invalid file");
                }
                else if (ex.InnerException is ArgumentNullException)
                {
                    rtextErrors.AppendText("Invalid path and filename");
                }
                else if (ex.InnerException is NotSupportedException)
                {
                    rtextErrors.AppendText("Not supported");
                }
                else
                {
                    rtextErrors.AppendText("Something bad happened.");
                    rtextErrors.AppendText(ex.Message);
                }
            }

            repository = new InMemoryRepository(orders);
            UpdateListView();
        }
        // creates a new, empty repository
        private void CreateEmptyRepository()
        {
            repository = new InMemoryRepository(new List<Purchase>());
        }

        // updates the list view
        public void UpdateListView()
        {

            var numberCulture = culture.NumberFormat;

            repository.GetAll().ForEach((order) =>
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

        // selects item from the list
        private void listPurchaseData_SelectedIndexChanged(object sender, EventArgs e)
        {
            var numberCulture = culture.NumberFormat;

            // safecast to purchase
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


    }
}
