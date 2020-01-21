using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservation
{
    /// <summary>
    /// The Waitlist is a classic Queue with a capacity of 10 names on it.
    /// 
    /// The first name in the waitlist will have the seat assigned first.
    /// The waitlist is a mutable type.
    /// </summary>
    public class Waitlist
    {

        /*
         * The array that holds the queue will have two sentinels: 
         * one to the point of removal: the head.
         * one to point of insertion: the tail.
         * 
         * To optimize the array and keep O(1) operations, the array will
         * operate on a circular manner.
         * 
         * To dequeue an element:
         * we copy the actual element
         * we change the array element to null
         * we move the head to + 1.
         * Due to the fixed constraing, we operate in a circular manner.
         * The next index is given as:
         * f(n): i + 1 % N | i = head index, N = 10 (max waitlist size - 1).
         * 
         * When queueing 
         * we insert iff queue[tail] is null
         * move the tail index
         * f(n): (i + 1) % N | i = tail index, N = 10 (max waitlist size - 1).
         * 
         * This guarantee a FIFO behaviour with O(1) operation, except for
         * WaitlistedCustomers(), which is O(n).
         * 
         * This class does not overrides ToString. A plausible implementation
         * would run in O(n), if using a String builder. O(N^2) with String 
         * concatenation.
         */

        /// <summary>
        /// The waitlist. a Circular Array
        /// </summary>
        private string[] Queue;
        /// <summary>
        /// Index of First item inserted.
        /// </summary>
        private int Head;
        /// <summary>
        /// Index of last item removed.
        /// </summary>
        private int Tail;
        /// <summary>
        /// How many names in the queue
        /// </summary>
        private int size;

        /// <summary>
        /// Constructs a waitlist that can hold 10 names on it.
        /// </summary>
        public Waitlist()
        {
            this.Queue = new string[10];
            this.Head = 0;
            this.Tail = 0;
            this.size = 0;
            _CheckInvariant();
        }

        /// <summary>
        /// Checks the invariant of the waitlist.
        /// invariant is:
        /// Queue != null
        /// 0 <= head < 10
        /// 0 <= tail < 10
        /// </summary>
        private void _CheckInvariant()
        {
            _ = (Queue is null) ? throw new NullReferenceException("Invalid waitlist") : "";
            _ = (Head < 0 || Head >= 10) ? throw new IndexOutOfRangeException("Invalid waitlist") : "";
            _ = (Tail < 0 || Tail >= 10) ? throw new IndexOutOfRangeException("Invalid waitlist") : "";
        }

        /// <summary>
        /// Generate a copy, 0 indexed, of the current waitlist.
        /// </summary>
        /// <returns>A copy, 0 indexed, of the current waitlist.</returns>
        public string[] WaitlistedCustomers()
        {
            // empty queue copy.
            if (IsEmpty())
            {
                return new string[] { String.Empty };
            }
            
            int capacity = 1; // will be 1 or size.
            if (size != 0)
            {
                capacity = size;
            }
            string[] copy = new string[capacity];
            int k = 0; // index for copy array
            // O(n) operation
            for (int i = Head; i < Queue.Length; i = NextIndex(i))
            {
                // the copy starts where is the first item that was inserted.
                // the copy uses the same formula to guarantee access to the right item.
                copy[k] = Queue[i];
                k++; // increments the copy array index
                
                // if next index will be bigger than the total itens, break the loop
                if (k >= capacity)
                {
                    break;
                }
            }

            return copy;
        }

        /// <summary>
        /// Generates the next index to iterate over a circular array
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private int NextIndex(int i) => (i + 1) % 10;

        /// <summary>
        /// Attempts to add customer to the waitlist.
        /// True iff waitlist is not full.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool Enqueue(string customer)
        {
            // we insert iff queue[tail] is null
            if (Queue[Tail] is null)
            {
                Queue[Tail] = customer;
                // move the tail to next index
                _NextTailIndex();
                size++;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Attempts to remove the element at the Head of the waitlist
        /// If there is no more names on the list, it will returns an 
        /// empty string.
        /// </summary>
        /// <returns>The element at the head of the waitlist.
        /// Otherwise returns an empty string.</returns>
        public string Dequeue()
        {
            if (IsEmpty())
            {
                return String.Empty;
            }
            string toReturn = Queue[Head];
            Queue[Head] = null; // remove from the waitlist.
            _NextHeadIndex();
            size--;
            return toReturn;
        }

        /// <summary>
        /// Move tail to the next index
        /// </summary>
        private void _NextTailIndex() =>
            Tail = (Tail + 1) % 10;

        /// <summary>
        /// Move Head to the next index
        /// </summary>
        
        private void _NextHeadIndex() =>
            Head = (Head + 1) % 10;

        /// <summary>
        /// Checks if the Queue is empty.
        /// </summary>
        /// <returns>True iff the queue is empty</returns>
        private bool IsEmpty() =>
            (Tail == Head && Queue[Tail] is null) ? true : false;
    }
}
