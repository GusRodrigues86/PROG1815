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

        /// <summary>
        /// Calculate the form accordingly to the selected type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // transforms text into string even if nulls.
            txtMonthlyDeposit.Text += "";
            txtAnnualInterest.Text += "";
            txtMonthlyDeposit.Text += "";
            txtYears.Text = "";

            if (radFutureValue.Checked)
            {
                // future value calculation
            }
            else
            {
                // monthly investment calculation
            }
        }
    }
}
