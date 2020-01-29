using System;
using System.Windows.Forms;
using Calculator;

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
            Calculator.Calculator calculator = new Calculator.Calculator();
            calculator.MdiParent = this;
            calculator.Show();
        }
    }
}
