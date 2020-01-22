using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservation.Service
{
    class AirplaneService
    {
        private Airplane ap;

        public AirplaneService()
        {
            this.ap = new Airplane();
        }

        /// <summary>
        /// True iff was able to assign customer to that seat.
        /// False otherwise
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="seat"></param>
        /// <returns>True iff was able to assign customer to that seat.
        /// False otherwise</returns>
        public bool AssignCustomerToSeat(string seat, string customer)
        {
            // validate customer is not empty
            if (String.IsNullOrWhiteSpace(customer))
            {
                return false;
            }

            // validate seat input

            if (IsInvalidSeat(seat))
            {
                return false;
            }

            return ap.AssignSeatTo(seat, customer);
        }

        /// <summary>
        /// True IFF was able to remove a customer of the seat.
        /// 
        /// an empty seat will return FALSE.
        /// </summary>
        /// <param name="seat"></param>
        /// <returns></returns>
        public bool UnassignSeat(string seat)
        {
            // validate seat input
            if (IsInvalidSeat(seat))
            {
                return false;
            }

            return ap.UnassignSeat(seat);
        }

        /// <summary>
        /// String representing all seated customers
        /// </summary>
        /// <returns></returns>
        public string SeatedCustomers() => ap.ToString();

        /// <summary>
        /// True IFF there is no more seats available to assign
        /// </summary>
        /// <returns></returns>
        public bool IsFull() => ap.IsFull();

        /// <summary>
        /// True IFF the seat is INVALID.
        /// 
        /// Validation is based in the following:
        /// 1st char is VALID IFF is a number and has a numerica value 1 <= n <= 5
        /// 
        /// 2nd char IS VALID IFF is not a number and must have the char value 65 (A) <= n <= 68 (D)
        /// </summary>
        /// <param name="seat">the seat to be checked</param>
        /// <returns>True IFF the seat is INVALID</returns>
        private bool IsInvalidSeat(string seat) {
            // first digit.
            // not digit
            if (!Char.IsDigit(seat[0]) ||
                // > 5
                (Char.GetNumericValue(seat[0]) > 5) ||
                // < 1
                (Char.GetNumericValue(seat[0]) < 1))
                {
                return true;
                }

            // a letter that is less than A (65) OR a letter that is bigger than D (68)
            if ((seat[1] < 65) || (seat[1] > 68))
            { 
                return true; 
            }
            return false;
        }


    }
}
