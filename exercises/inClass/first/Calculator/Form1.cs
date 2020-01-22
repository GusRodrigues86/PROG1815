/* InClass 1
 *      A calculator that perform operations of sum, subtraction,
 *      multiply and divide two term.
 * 
 * Created by:
 *      Gustavo Bonifacio Rodrigues, 2020.01.22.
 */
using System;
using System.Windows.Forms;
using static Calculator.Service.CalculationService; // static import of the calculation

namespace Calculator
{
    public partial class Calculator : Form
    {

        private int X;
        private string pendingAction;
        private bool IsNewExpression;
        private bool AfterOperation;
        public Calculator()
        {
            this.X = 0;
            this.pendingAction = "";
            this.IsNewExpression = true;
            this.AfterOperation = false;
            InitializeComponent();
        }

        // load and set the state of the calculator as required
        private void Calculator_Load(object sender, EventArgs e)
        {
            txtInput.Clear(); // clear input
            lblExpression.Text = "";
        }


        // when click one of the numeric buttons, load the value on the input textbox
        private void btnAddInputValue(object sender, EventArgs e)
        {
            if (this.AfterOperation)
            {
                this.AfterOperation = false;
                txtInput.Clear();
                lblExpression.Text = "";
            }
            Button btn = (Button) sender;
            // int value = int.Parse(btn.Text);
            if (txtInput.TextLength < 10)
            {
                txtInput.AppendText(btn.Text);
            }
        }

        // Press CE -> Clear current expression in the txtInput
        private void btnClearExpression(object sender, EventArgs e)
        {
            txtInput.Clear();
        }

        // Press C -> Clear all the expressions, and reset to start state.
        private void btnClearAll(object sender, EventArgs e)
        {
            txtInput.Clear(); // clears input textBox
            lblExpression.Text = ""; // clears expression labels
            ResetState();
        }


        // defines calculation state to the desired operation (+,-,*,/)
        private void btnDefineOperation(object sender, EventArgs e)
        {
            Button pressed = (Button) sender;
            
            string operation = pressed.Text;

            if (!String.IsNullOrWhiteSpace(txtInput.Text))
            {
                this.X = int.Parse(txtInput.Text);
                lblExpression.Text = txtInput.Text + " " + operation + " ";
            }
            else
            {
                lblExpression.Text = "0 " + operation + " ";
            }
            this.pendingAction = operation;
            this.IsNewExpression = false;
            txtInput.Clear();

        }

        // find the right operation and display the answer
        private void Result(object sender, EventArgs e)
        {
            int y = 0;
            // if user inputed something. parse, otherwise, y = 0.
            if (!String.IsNullOrWhiteSpace(txtInput.Text))
            {
                y = int.Parse(txtInput.Text);
            }

            // process operation
            try
            {
                lblExpression.Text += y;
                int result = FindOperationAndCompute(y);
                lblExpression.Text += " =\t";
                txtInput.Text = result.ToString();
                ResetState();
                this.AfterOperation = true;
            }
            catch (DivideByZeroException)
            {
                // when divided by zero.
                txtInput.Text = "Can't divide by 0.";
                ResetState();
                this.AfterOperation = true;
            }
        }

        // Computes result based on the selected operation and returns it
        private int FindOperationAndCompute(int y)
        {
            switch (this.pendingAction)
            {
                case "+":
                    return SumValues(x: this.X, y: y);
                case "-":
                    return SubtractValues(x: this.X, y: y);
                case "*":
                    return MultiplyFactors(x: this.X, y: y);
                case "/":
                    return DivideFactors(x: this.X, y: y);
                default:
                    return SumValues(x: this.X, y: y);
            }
        }

        // reset the state of the calculator
        private void ResetState()
        {
            this.X = 0; // Resets X
            this.pendingAction = ""; // Resets Y
            this.IsNewExpression = true; // Resets state of the calculation
            this.AfterOperation = false;
        }

    }
}
