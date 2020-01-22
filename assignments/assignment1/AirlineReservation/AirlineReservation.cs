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
        private WaitlistService waitlistService;
        public AirlineReservation()
        {
            // Loads the Airline service.
            this.waitlistService = new WaitlistService();
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
                waitlistService.AddToWaitlist(txtName.Text);
            }
            catch (NullReferenceException)
            { 
                lblMessages.Text = "Name must not be empty or white spaced\n";
            }
        }

        // Update/Shows the waitlist
        private void btnShowWaitingList(object sender, MouseEventArgs e)
        {
            // guarantees an empty box ALWAYS.
            rtxtWaitlist.ResetText();
            
            // builds the waitlist
            foreach (string item in waitlistService.Waitlist())
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

    }
}
