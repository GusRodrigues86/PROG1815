/* Assignment 1
 *   AirplaneService.cs
 *   Service that provide UseCases for accessing the airplane ADT
 *   
 * Revision History
 *      Gustavo Bonifacio Rodrigues, 2020.01.20: Created
 */
using System;

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
        /// <param name="seat">Desired seat assignment</param>
        /// <param name="customer">Customer to be assigned</param>
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
        /// <param name="seat">Seat to have customer unassigned to it.</param>
        /// <returns>True if and only if there is a customer assigned to that seat.</returns>
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
        /// <returns>A string representing all the seats, including those with customers to it.</returns>
        public string SeatedCustomers() => ap.ToString();

        /// <summary>
        /// True IFF there is no more seats available to assign
        /// </summary>
        /// <returns>True if and only if the airplane has no more seats available to assign.</returns>
        public bool IsFull() => ap.IsFull();

        /// <summary>
        /// Checks if the supplied seat is empty.
        /// 
        /// True IFF is empty.
        /// </summary>
        /// <param name="seat">The seat to check</param>
        /// <returns>True if and only if the desired seat is empty.</returns>
        public bool SeatStatus(string seat) => ap.IsSeatEmpty(seat);

        /// <summary>
        /// True IFF the seat is INVALID.
        /// 
        /// Validation is based in the following:
        /// 1st char is VALID IFF is a number and has a numerica value 1 <= n <= 5
        /// 
        /// 2nd char IS VALID IFF is not a number and must have the char value 65 (A) <= n <= 68 (D)
        /// </summary>
        /// <param name="seat">the seat to be checked</param>
        /// <returns>True if th supplied seat is an INVALID one. i.e. out of range</returns>
        private bool IsInvalidSeat(string seat)
        {
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

        public String GetCustomerInSeat(string seat) => ap.GetCustomerInSeat(seat);

    }
}
