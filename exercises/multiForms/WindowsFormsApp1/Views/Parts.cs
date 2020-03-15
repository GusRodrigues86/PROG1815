using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTClassLibrary;

namespace WindowsFormsApp1
{
    public partial class Parts : Form
    {
        public Parts()
        {
            InitializeComponent();
        }


        private string Edit()
        {
            string errors = "";
            if (!Validation.IsInteger(txtPartID.Text))
            {
                errors += "Part ID needs to be an integer\r\n";
                if (errors.Length == 0)
                {
                    txtPartID.Focus();
                }
            }
            return errors;
        }
    }
}
