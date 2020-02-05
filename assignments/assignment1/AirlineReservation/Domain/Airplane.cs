/* Assignment 1
 *   Airplane.cs
 *   ADT representing the seat arrangement of an airplane in a reservation system
 *   The ADT provides methods to manage the seating.
 *   The Seat arrangement of the airplane is represented as a 2 Dimensional Array.
 *   
 *   ToString offers Linear time operation, while Assignment and Unassignment of seats offers O(1).
 *   
 * Revision History
 *      Gustavo Bonifacio Rodrigues, 2020.01.20: Created
 */

using System;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("AirlineReservationTests")] // allows unit tests
namespace AirlineReservation
{
    /// <summary>
    /// Seats is an Array of Arrays (2D Arrays) representing the
    /// seating configuration of the aircraft.
    /// 
    /// The seating is given as 5 rows with 4 seats per row.
    /// 1A 1B   1C 1D
    /// 2A 2B   2C 2D
    /// ...
    /// 
    /// An unassigned seat has a null value.
    /// A seat is assigned to it will have the Customer name on it.
    /// </summary>
    internal class Airplane
    {
        private string[,] SeatMap;

        private int Bookings;
        public Airplane()
        {
            this.SeatMap = new string[5, 4];
            this.Bookings = 0;
            CheckInvariant();
        }

        /// <summary>
        /// Invariant
        /// SeatMap != null &&
        /// 0 <= n <= 20 | n = Bookings
        /// </summary>
        private void CheckInvariant()
        {
            _ = (SeatMap is null) ? throw new NullReferenceException("Invalid seat arrangement") : "";
            _ = (Bookings < 0 && Bookings > 20) ? throw new IndexOutOfRangeException("Invalid passengers listed") : "";
        }

        /// <summary>
        /// Assign the desired seat to the customer.
        /// 
        /// Returns True IFF the seatmap is changed because of the operation.
        /// </summary>
        /// <param name="seat"></param>
        /// <param name="customer">The customer name in the seat</param>
        /// <returns>True IFF the seatmap is changed because of the operation.</returns>
        public bool AssignSeatTo(string seat, string customer)
        {
            // seat or customer cannot be empty.
            if (String.IsNullOrWhiteSpace(seat) || String.IsNullOrWhiteSpace(customer))
            {
                return false;
            }
            // get row number
            int[] indexes = SeatAsMapIndexes(seat);
            int row = indexes[0], letter = indexes[1];

            if (SeatMap[row, letter] != null)
            {
                return false;
            }

            SeatMap[row, letter] = customer;
            Bookings++;
            CheckInvariant();
            return true;
        }


        /// <summary>
        /// Returns true IFF the desired seat is empty.
        /// </summary>
        /// <param name="seat">The seat to check</param>
        /// <returns>True IFF the supplied seat is empty. Otherwise, false.</returns>
        public bool IsSeatEmpty(string seat)
        {
            int[] indexes = SeatAsMapIndexes(seat);
            if (SeatMap[indexes[0], indexes[1]] is null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Remove customer from the desired seat.
        /// 
        /// returns True IFF the seatmap is changed because of the operation
        /// </summary>
        /// <param name="seat"></param>
        /// <returns></returns>
        public bool UnassignSeat(string seat)
        {
            // seat cannot be empty.
            if (String.IsNullOrWhiteSpace(seat))
            {
                return false;
            }

            int[] indexes = SeatAsMapIndexes(seat);
            int row = indexes[0], letter = indexes[1];

            if (SeatMap[row, letter] is null)
            {
                return false;
            }
            SeatMap[row, letter] = null; // GC remove reference
            Bookings--;
            CheckInvariant();
            return true;
        }

        /// <summary>
        /// True IFF There are 20 passengers with seat assigned
        /// </summary>
        /// <returns></returns>
        public bool IsFull() => Bookings == 20;

        /// <summary>
        /// Returns the customer in the desired seat.
        /// 
        /// IFF empty, returns an empty string
        /// </summary>
        /// <param name="seat"></param>
        /// <returns>IFF the desired seat is empty, returns an empty string, otherwise, the customer on it.</returns>
        public string GetCustomerInSeat(string seat)
        {
            // check if empty
            if (IsSeatEmpty(seat))
            {
                return String.Empty;
            }
            // if there is a customer:
            int[] indexes = SeatAsMapIndexes(seat);
            return SeatMap[indexes[0], indexes[1]];
        }

        /// <summary>
        /// Convert the string representing the desired Seat as indexes to
        /// access the seatmap.
        /// </summary>
        /// <param name="seat">The seat to be indexed</param>
        /// <returns>An int array with the index of the seatmap</returns>
        private int[] SeatAsMapIndexes(string seat)
        {
            int row = seat[0] % 49; // 49 is 1 in ASCII
            // get seat letter
            int letter = (seat[1] % 65); // 65 is A (capital A) in ASCII

            return new int[] { row, letter };
        }

        public override string ToString()
        {
            // indexes for iteration
            StringBuilder sb = new StringBuilder(); // faster than string concatenation
            for (int i = 0; i < SeatMap.Length; i++)
            {
                // indexes. row is % 5, letter is % 4
                int row = (int) Math.Floor(i / 4.0);
                int letter = i % 4;

                // creates structure
                String seating = (row + 1) + "" + ((char) ((i % 4) + 65)) + " - ";
                sb.Append(seating);
                if (SeatMap[row, letter] != null)
                {
                    sb.Append(SeatMap[row, letter]);
                }
                if (i != (SeatMap.Length - 1))
                {
                    sb.Append("\r\n");
                }
            }
            return sb.ToString();
        }
    }
}
