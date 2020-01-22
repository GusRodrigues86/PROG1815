using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public class Airplane
    {
        private string[,] SeatMap;

        public Airplane()
        {
            this.SeatMap = new string[5, 4];
            CheckRep();
        }

        private void CheckRep()
        {
            _ = (SeatMap is null) ? throw new NullReferenceException("Invalid seat arrangement") : "";
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
            return true;
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
            return true;
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
                int row = i % 5;
                int letter = i % 4;

                if (SeatMap[row, letter] != null)
                {
                    // creates structure
                    String seating = (row + 1) + "" + ((char) ((i % 4)+65)) + " - ";
                    sb.AppendLine(seating + SeatMap[row,letter]);
                }
            }
            return sb.ToString();
        }
    }
}
