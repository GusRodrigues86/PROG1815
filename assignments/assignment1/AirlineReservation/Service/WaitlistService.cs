/* Assignment 1
 *   WaitlistServices.cs
 *   Service that provide UseCases for accessing the waitlist ADT
 *   
 * Revision History
 *      Gustavo Bonifacio Rodrigues, 2020.01.20: Created
 */
using System;

namespace AirlineReservation
{
    /// <summary>
    /// Provides operations of the useCases of Waitlist.
    /// </summary>
    public class WaitlistService
    {
        /// <summary>
        /// The waitlist to operate
        /// </summary>
        private Waitlist CustomerWaitlist;

        public WaitlistService()
        {
            this.CustomerWaitlist = new Waitlist();
        }

        /// <summary>
        /// Copy of the array holding all customers waitlisted.
        /// 
        /// If first element is an empty string, there is no one on the waitlist.
        /// </summary>
        /// <returns>A string array holding all the customers on the waitlist.</returns>
        public string[] Waitlist() => this.CustomerWaitlist.WaitlistedCustomers();

        /// <summary>
        /// Attempts to add customer to the Waitlist.
        /// True IFF customer is successfully add to it. otherwise, false.
        /// </summary>
        /// <param name="customer">Customer to be added to waitlist</param>
        /// <returns>True if and only if the customer was successfully added to the waitlist</returns>
        public bool AddToWaitlist(string customer)
        {
            // String validation to prevent null/whitespaced
            if (String.IsNullOrWhiteSpace(customer))
            {
                throw new NullReferenceException("Customer must have a name");
            }

            return this.CustomerWaitlist.Enqueue(customer);
        }

        /// <summary>
        /// Attempts to remove customer from the waitlist.
        /// 
        /// Returns the customer, if any. Otherwise, returns an empty string.
        /// </summary>
        /// <returns>The first customer on the waitlist. If there wasn't an user to be removed from the waitlist, it will return an empty string.</returns>
        public string RemoveFromTheWaitlist() => 
            this.CustomerWaitlist.Dequeue();

        /// <summary>
        /// Checks if there is an element to be removed from the waitlist and assign to seat.
        /// </summary>
        /// <returns></returns>
        public bool HasNext() => 
            (String.IsNullOrWhiteSpace(this.CustomerWaitlist.Peek())) ? false : true;
    }
}
