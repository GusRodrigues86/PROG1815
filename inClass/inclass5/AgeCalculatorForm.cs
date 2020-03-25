using inclass5.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inclass5
{
    public partial class AgeCalculator : Form
    {
        private Person Person;
        private static readonly DateTime TODAY = DateTime.Today;
        public AgeCalculator()
        {
            InitializeComponent();
        }

        // loads and initialize the Person object
        private void AgeCalculator_Load(object sender, EventArgs e)
        {
            Person = new Person();
            lblErrors.Text = "";
            lblAge.Text = "";
        }

        // validate the entire form
        private void ValidateForm()
        {
            lblErrors.Text = "";
            txtFirstName.Text += "";
            txtLastName.Text += "";
            var firstName = txtFirstName.Text;
            var lastName = txtLastName.Text;

            if (string.IsNullOrWhiteSpace(firstName))
            {
                lblErrors.Text += "First name cannot be empty.\n";
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                lblErrors.Text += "Last name cannot be empty.\n";
            }
            if (TODAY.CompareTo(datePicker.Value.Date) < 0)
            {
                lblErrors.Text += "Can't be born in the future.\n";
            }

        }

        // Calculates age.
        private void btnCalculator_Click(object sender, EventArgs e)
        {
            // validate the form
            ValidateForm();
            // calculate if valid
            if (string.IsNullOrWhiteSpace(lblErrors.Text))
            {
                InjectFieldsToPerson();
                lblAge.Text = string.Empty;
                lblAge.Text += $"{Person.Age(TODAY).ToString()}";
            }

        }

        // Inject fields values to person
        private void InjectFieldsToPerson()
        {
                Person.FirstName = txtFirstName.Text;
                Person.LastName = txtLastName.Text;
                Person.DateOfBirth = new DateTime(datePicker.Value.Year, datePicker.Value.Month, datePicker.Value.Day);
        }

        // validate on leave form
        private void LeaveValidation(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                var temp = (TextBox) sender;
                var input = temp.Text + "";
                var tag = temp.Tag.ToString();
                if (string.IsNullOrWhiteSpace(input))
                {
                    if (!lblErrors.Text.Contains(tag))
                    {
                        lblErrors.Text += $"{tag} cannot be empty.\n";
                    }
                }
            }
            if (sender is DateTimePicker)
            {
                var date = (DateTimePicker) sender;
                if (TODAY.CompareTo(date.Value.Date) < 0 )
                {
                    if (!lblErrors.Text.Contains("born"))
                    {
                        lblErrors.Text += "Can't be born in the future.\n";
                    }
                }
            }
        }
    }
}
