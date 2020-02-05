using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // closes the application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Display About the software
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string author = "Author:\t Gustavo Bonifacio Rodrigues\n\r" +
                "Email:\t grodrigues86@gmail.com\r\n" +
                "More:\t https://github.com/GusRodrigues86\r\n";
            MessageBox.Show(author, 
                "About DT Main Form",
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // thanks Microsoft and crazy namespace rules.
            SimpleCalculator.Calculator calculator = new SimpleCalculator.Calculator();
            calculator.MdiParent = this;
            calculator.Show();
        }

        /// <summary>
        /// Loads the parts maintenance form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void partsMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Parts parts = new Parts();
            parts.MdiParent = this;
            parts.Show();
        }
    }
}
