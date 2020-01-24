using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassExerciseApp1
{
    public partial class InvestmentCalculator : Form
    {
        public InvestmentCalculator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // load state of the app
        private void InvestmentCalculator_Load(object sender, EventArgs e)
        {
            lblMessages.Text = String.Empty;
        }

        /// <summary>
        /// Calculate the form accordingly to the selected type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // initializing variables
            int years = 0;
            double interest =0, futureValue = 0, deposit = 0;

            // transforms text into string even if nulls.
            txtMonthlyDeposit.Text += "";
            txtAnnualInterest.Text += "";
            txtYears.Text += "";
            

            // convert year string to int
            try
            {
                years = Convert.ToInt32(txtYears.Text);
            }
            catch (Exception)
            {
                lblMessages.Text += "Years needs to be an integer\n";
            }
            // convert interest string to int
            try
            {
                interest = Convert.ToDouble(txtAnnualInterest.Text);

                if (interest < 0 || interest > 10)
                {
                    lblMessages.Text += "Interest must be between 0 and 10\n";
                }
            }
            catch (Exception)
            {
                lblMessages.Text += "Interest needs to be an integer\n";
            }
            
            // monthly deposit
            try
            {
                deposit = Convert.ToDouble(txtMonthlyDeposit.Text);
                if (deposit <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception)
            {
                lblMessages.Text += "Monthly deposit needs to be bigger than 0\n";
            }

            if (radFutureValue.Checked)
            {
                double value = 10;
                // future value calculation
                txtFutureValue.Text = "$ " +value.ToString("N2");
            }
            else
            {
                // monthly investment calculation
                double value = 20;
                txtFutureValue.Text = "$ " + value.ToString("N2");
            }
        }

        
    }
}
