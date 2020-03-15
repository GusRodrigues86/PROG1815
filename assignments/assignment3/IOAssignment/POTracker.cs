using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOAssignment
{
    public partial class POTrackerForm : Form
    {
        public POTrackerForm()
        {
            InitializeComponent();
        }

        // Load state of the form -> Fields are disable until file is read or created.
        private void POTrackerForm_Load(object sender, EventArgs e)
        {
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
    }
}
