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
        }

        // Add to the waitlist
        private void btnAddToWaitlist(object sender, MouseEventArgs e)
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
        private void btnShowWaitingList(object sender, MouseEventArgs e)
        {
            // ALWAYS guarantees an empty box.
            rtxtWaitlist.ResetText();

            // builds the waitlist
            foreach (string item in WaitlistService.Waitlist())
            {
                // TODO REMOVE AND LEAVE ONLY THE COMMENTED LINE BELLOW UNCOMMENTED
                // rtxtWaitlist.AppendText(item);
                // rtxtWaitlist.AppendText("\n");
                if (String.IsNullOrWhiteSpace(item))
                {
                    rtxtWaitlist.AppendText("cu");
                    rtxtWaitlist.AppendText("\n");
                }
                else
                {
                    rtxtWaitlist.AppendText(item);
                    rtxtWaitlist.AppendText("\n");
                }
            }
        }

        // Updates/Shows all the customers with seat assigned
        private void btnShowAllSeats(object sender, MouseEventArgs e)
        {
            // ALWAYS guarantees an empty box.
            rtxtboxSeated.ResetText();

            // builds the customers with seats assigneds
            rtxtboxSeated.AppendText(AirplaneService.SeatedCustomers());
        }

        // Attempt to assign the selected seat to the customer
        private void btnBookSeat(object sender, MouseEventArgs e)
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
                    throw new NullReferenceException();
                }
                // checks seat selection
                if (String.IsNullOrWhiteSpace(lstBoxRow.SelectedItem.ToString()))
                {
                    throw new InvalidOperationException("Select a row");
                }
                if (String.IsNullOrWhiteSpace(lstBoxSeat.SelectedItem.ToString()))
                {
                    throw new InvalidOperationException("Select a seat");
                }
                string seat = lstBoxRow.SelectedItem.ToString();
                seat += lstBoxSeat.SelectedItem.ToString();

                if (!AirplaneService.AssignCustomerToSeat(seat, customer))
                {
                    lblMessages.Text += "Unable to assign customer to the seat";
                }
                btnShowAllSeats(sender, e);
            }
            catch (ConstraintException)
            {
                // flight is full
                lblMessages.Text += "Flight is full, Customer needs to go to the Waitlist\r\n";
            }
            catch (NullReferenceException)
            {
                // no name was typed
                lblMessages.Text += "Name must not be empty or white spaced\r\n";
            }
            catch (InvalidOperationException ex)
            {
                // invalid seat selection
                lblMessages.Text += ex.Message + "\r\n";
            }
        }
    }
}
