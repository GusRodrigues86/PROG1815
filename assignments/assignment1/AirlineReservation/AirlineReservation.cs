using AirlineReservation.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineReservation
{
    public partial class AirlineReservation : Form
    {
        private WaitlistService WaitlistService;
        private AirplaneService AirplaneService;
        public AirlineReservation()
        {
            // Inject dependencies
            this.WaitlistService = new WaitlistService();
            this.AirplaneService = new AirplaneService();

            InitializeComponent();
        }

        // Force state of lblMessage after initialization
        private void AirlineReservation_Load(object sender, EventArgs e)
        {
            lblMessages.Text = "";
            btnShowAllSeats(sender, e);
        }

        // Add to the waitlist
        private void btnAddToWaitlist(object sender, EventArgs e)
        {
            //lblMessages. Text = "";


            // must check IF any seat is empty.
            try
            {
                // if flight is full, throw exception
                if (!AirplaneService.IsFull())
                {
                    throw new ConstraintException();
                }
                WaitlistService.AddToWaitlist(txtName.Text);
            }
            catch (ConstraintException) // full flight
            {
                lblMessages.Text += "Waitlist is only available after all seats are assigned.\r\n";
            }
            catch (NullReferenceException) // empty name
            {
                lblMessages.Text += "Name must not be empty or white spaced\r\n";
            }
        }
        // Update/Shows the waitlist
        private void btnShowWaitingList(object sender, EventArgs e)
        {
            // ALWAYS guarantees an empty box.
            rtxtWaitlist.ResetText();

            // builds the waitlist
            foreach (string item in WaitlistService.Waitlist())
            {
                rtxtWaitlist.AppendText(item + "\r\n");
            }
        }
        // Updates/Shows all the customers with seat assigned
        private void btnShowAllSeats(object sender, EventArgs e)
        {
            // ALWAYS guarantees an empty box.
            rtxtboxSeated.ResetText();

            // builds the customers with seats assigneds
            rtxtboxSeated.AppendText(AirplaneService.SeatedCustomers());
        }
        
        // Attempt to assign the selected seat to the customer
        private void btnBookSeat(object sender, EventArgs e)
        {
            lblMessages.Text = ""; // resets all messages before start

            string customer = txtName.Text;

            try
            {
                // cannot add customer on a full flight
                if (AirplaneService.IsFull())
                {
                    throw new ConstraintException();
                }
                // null or empty name
                if (String.IsNullOrWhiteSpace(customer))
                {
                    throw new NullReferenceException("Name must not be empty or white spaced\r\n");
                }
                // checks seat selection
                try
                {
                    if (String.IsNullOrWhiteSpace(lstBoxRow.SelectedItem.ToString()))
                    {
                        throw new InvalidOperationException("Select a row");
                    }

                }
                catch (NullReferenceException)
                {
                    throw new InvalidOperationException("Select a row");
                }
                try
                {
                    if (String.IsNullOrWhiteSpace(lstBoxSeat.SelectedItem.ToString()))
                    {
                        throw new InvalidOperationException("Select a seat");
                    }

                }
                catch (NullReferenceException)
                {
                    throw new InvalidOperationException("Select a seat");
                }

                string seat = lstBoxRow.SelectedItem.ToString();
                seat += lstBoxSeat.SelectedItem.ToString();

                if (!AirplaneService.AssignCustomerToSeat(seat, customer))
                {
                    lblMessages.Text += "Unable to assign customer to the seat\r\n";
                }
                btnShowAllSeats(sender, e);
            }
            catch (ConstraintException)
            {
                // flight is full
                lblMessages.Text += "Flight is full, Customer needs to go to the Waitlist\r\n";
            }
            catch (NullReferenceException ex)
            {
                // no name was typed
                lblMessages.Text = ex.Message;
            }
            catch (InvalidOperationException ex)
            {
                // invalid seat selection
                lblMessages.Text += ex.Message + "\r\n";
            }
        }
        // Check the status of a selected seat
        private void btnSeatStatus(object sender, EventArgs e)
        {
            // validation if user selected a seat
            // checks seat selection
            try
            {
                try
                {
                    if (String.IsNullOrWhiteSpace(lstBoxRow.SelectedItem.ToString()))
                    {
                        throw new InvalidOperationException("Select a row");
                    }

                }
                catch (NullReferenceException)
                {
                    throw new InvalidOperationException("Select a row");
                }
                try
                {
                    if (String.IsNullOrWhiteSpace(lstBoxSeat.SelectedItem.ToString()))
                    {
                        throw new InvalidOperationException("Select a seat");
                    }

                }
                catch (NullReferenceException)
                {
                    throw new InvalidOperationException("Select a seat");
                }

                lblMessages.Text = ""; // remove any warnings

                string seat = lstBoxRow.SelectedItem.ToString();
                seat += lstBoxSeat.SelectedItem.ToString();

                bool seatStatus = AirplaneService.SeatStatus(seat);
                if (seatStatus)
                {
                    txtStatus.Text = "Seat available";
                }
                else
                {
                    txtStatus.Text = "Seat not available";
                }
            }
            catch (InvalidOperationException ex)
            {
                lblMessages.Text = ex.Message;
            }

        }
        // Display seat status for the selected seat from seatmap
        private void btnSelectSeat(object sender, EventArgs e)
        {
            Button btn = (Button) sender; // safecast
            string seat = btn.Tag.ToString(); // get the tag ID of the seatmap.
            int row = (int) Char.GetNumericValue(seat[0]) - 1; // for 0 index
            int seatIndex = (int) seat[1] - 65; // char value - 65 : for 0 index
            lstBoxRow.SetSelected(row, true);
            lstBoxSeat.SetSelected(seatIndex, true);

            btnSeatStatus(sender, e); 
        }

    }
}
