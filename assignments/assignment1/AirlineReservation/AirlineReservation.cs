/* Assignment 1
 *   AirlineReservation.cs
 *   Windows form manipulation class
 *   
 * Revision History
 *      Gustavo Bonifacio Rodrigues, 2020.01.20: Created
 */
using AirlineReservation.Service;
using System;
using System.Data;
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
            btnShowAllSeats(sender,e);
        }

        // Add to the waitlist
        private void btnAddToWaitlist(object sender, EventArgs e)
        {
            lblMessages.Text = ""; // clear lables of error before checking.


            // must check IF any seat is empty.
            try
            {
                // if flight is full, throw exception
                if (!AirplaneService.IsFull())
                {
                    throw new ConstraintException();
                }
                var attempt = WaitlistService.AddToWaitlist(txtName.Text);

                if (!attempt)
                {
                    lblMessages.Text += "Waitlist is full!";
                }
                btnShowWaitingList(sender, e); // update dialog status
                ResetSelection();
            }
            catch (ConstraintException) // full flight
            {
                lblMessages.Text += "Waitlist is only available after all\n\r seats are assigned.\r\n";
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

            // book customer...
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
                btnShowAllSeats(sender, e); // update customer list
                // clear info after successfully insertion
                ResetSelection();
            }
            catch (ConstraintException)
            {
                // flight is full
                lblMessages.Text += "Flight is full.\r\nCustomer needs to go to the Waitlist\r\n";
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
            // Customer name shows in the Name textbox
            if (!AirplaneService.SeatStatus(seat))
            {
                txtName.Clear();
                txtName.Text += AirplaneService.GetCustomerInSeat(seat);
            }
        }

        // Cancel customer booking based on Seat selection
        private void btnCancelBooking(object sender, EventArgs e)
        {
            // clear messages
            lblMessages.Text = "";
            // it only needs the seat selection. if not empty, REMOVE IT!

            try
            {
                string row = lstBoxRow.SelectedItem.ToString();
                string seat = lstBoxSeat.SelectedItem.ToString();
                string seatSelection = row + seat;

                // if seat is not occupied, present message
                if (AirplaneService.SeatStatus(seatSelection))
                {
                    lblMessages.Text = "Selected seat is empty.";
                    ResetSelection(); // unselect and clears everything
                    return; // forces the end of the method.
                }
                // at this point, removal of seat is possible.
                string warningMessage = "The removal of a customer will enforce the first name, if any, " +
                    "on the waitlist to take it's place and cannot be undone.\r\n" +
                    "Do you want to proceed?";
                DialogResult result = MessageBox.Show(warningMessage, "Cancel Booking", MessageBoxButtons.YesNo);
                // user confirm he wants to proceed
                if (result == DialogResult.Yes)
                {
                    AirplaneService.UnassignSeat(seatSelection);
                    // get the first element of the waitlist.
                    if (WaitlistService.HasNext())
                    {
                        // Dequeue element and put on the txtName
                        txtName.Text = WaitlistService.RemoveFromTheWaitlist();
                        // Assign the customer to the seat.
                        btnBookSeat(sender, e);

                    }
                    btnShowWaitingList(sender, e);
                    btnShowAllSeats(sender, e);
                    ResetSelection();
                }
                else
                {
                    // clear form entirely
                    ResetSelection();
                }
            }
            // NRE is caused by the lstBoxRow and Seat. It means that seat was not properly selected.
            catch (NullReferenceException)
            {
                lblMessages.Text += "Select a seat first";
            }

        }

        // clear the customer name box, the row and seat selection and seat status information
        private void ResetSelection()
        {
            txtName.Clear(); // Clear customer name from the box.
            lstBoxRow.ClearSelected(); // unselect row
            lstBoxSeat.ClearSelected(); // unselect seat
            txtStatus.Clear(); // clear status
            txtName.Clear(); // clear status info
        }

        // Fill All (Debug) is pressed.
        // Will fill all the 20 seats, if available and there will be no names to the waitlist
        private void btnFillAll(object sender, EventArgs e)
        {
            // all seats of the plane 
            string[] seats = { "1A", "1B", "1C", "1D", "2A", "2B", "2C", "2D", "3A", "3B", "3C", "3D",
            "4A","4B","4C","4D","5A","5B","5C","5D"};
            // assign if available
            foreach (var seat in seats)
            {
                AirplaneService.AssignCustomerToSeat(seat, "Dolly");
            }
            // remove test before submission

            btnShowAllSeats(sender, e);
        }
    }
}
