﻿/* Assignment 1
 *   Waitlist.cs
 *   Waitlist is an ADT that represents an flight waitlist. It behaves as a standard Queue.
 *   The ADT ensure O(1) for all Queue and Dequeueing operations, and O(n) for the entire list.
 *   The ADT is capable of holding no more than 10 elements in the Queue.
 *   
 * Revision History
 *      Gustavo Bonifacio Rodrigues, 2020.01.20: Created
 */

using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("AirlineReservationTests")] // allows unit tests
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
        private int Size;

        /// <summary>
        /// Constructs a waitlist that can hold 10 names on it.
        /// </summary>
        public Waitlist()
        {
            this.Queue = new string[10];
            this.Head = 0;
            this.Tail = 0;
            this.Size = 0;
            CheckInvariant();
        }

        /// <summary>
        /// Checks the invariant of the waitlist.
        /// invariant is:
        /// Queue != null
        /// 0 <= head < 10
        /// 0 <= tail < 10
        /// </summary>
        private void CheckInvariant()
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
            if (Size != 0)
            {
                capacity = Size;
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
                NextTailIndex();
                Size++;
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
            NextHeadIndex();
            Size--;
            return toReturn;
        }

        /// <summary>
        /// Returns the first element of the Queue. If null, returns an empty string.
        /// This method does not modify the Queue
        /// </summary>
        /// <returns>Returns the first element of Queue, if none. Otherwise, returns an empty string</returns>
        public string Peek()
        {
            string nextItem = Queue[Head];
            if (String.IsNullOrWhiteSpace(nextItem))
            {
                return String.Empty;
            }
            return nextItem;
        }

        /// <summary>
        /// Move tail to the next index
        /// </summary>
        private void NextTailIndex() =>
            Tail = (Tail + 1) % 10;

        /// <summary>
        /// Move Head to the next index
        /// </summary>
        private void NextHeadIndex() =>
            Head = (Head + 1) % 10;

        /// <summary>
        /// Checks if the Queue is empty.
        /// </summary>
        /// <returns>True iff the queue is empty</returns>
        private bool IsEmpty() =>
            (Tail == Head && Queue[Tail] is null) ? true : false;
    }
}
