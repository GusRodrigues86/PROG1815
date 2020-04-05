/** inClass task 4
 * IOinClass.cs
 *  Form to user input
 *  
 *  Revision history
 *      Gustavo Bonifacio Rodrigues: 2020.04.01, Created
 */
using IOTestinClass.Utilities;
using System;
using System.Windows.Forms;

namespace IOTestinClass
{
    public partial class IOinClass : Form
    {
        public IOinClass()
        {
            InitializeComponent();
            txtDirectoryInput.Text = "";
            ClearErrors();
        }

        // Create button is pressed
        private void btnCreate_Click(object sender, EventArgs e)
        {
            ClearErrors();
            string input = txtDirectoryInput.Text + "";
            input = input.Trim();
            // validate input
            if (string.IsNullOrWhiteSpace(txtDirectoryInput.Text))
            {
                lblErrors.Text = "Need a path and/or a filename.\n";
                return;
            }
            // try
            CreateFile(input, checkDelete.Checked, checkCreateFile.Checked);

        }

        // create a file
        private void CreateFile(string pathWithFile, bool delete, bool create)
        {
            pathWithFile = pathWithFile.Trim();
            try
            {
                IOUtils.File_CreatePath(pathWithFile, delete, create);
            }
            catch (Exception ex)
            {
                lblErrors.Text += ex.Message;
                txtDirectoryInput.Focus();
            }
        }

        // clear the lblErrors.
        private void ClearErrors() =>
            lblErrors.Text = "";
    }
}
