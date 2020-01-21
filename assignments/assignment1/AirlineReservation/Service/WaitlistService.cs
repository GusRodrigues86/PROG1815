using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private Waitlist waitlist;

        public WaitlistService()
        {
            this.waitlist = new Waitlist();
        }

        /// <summary>
        /// Copy of the array holding all customers waitlisted
        /// </summary>
        /// <returns></returns>
        public string[] Waitlist() => waitlist.WaitlistedCustomers();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool AddToWaitlist(string customer)
        {
            // String validation to prevent null/whitespaced
            if (String.IsNullOrWhiteSpace(customer))
            {
                throw new NullReferenceException("Customer must have a name");
            }
            return waitlist.Enqueue(customer);
        }

        /// <summary>
        /// Attempts to remove customer from the waitlist.
        /// 
        /// Returns the customer, if any. Otherwise, returns an
        /// empty string.
        /// </summary>
        /// <returns></returns>
        public string RemoveFromTheWaitlist() => waitlist.Dequeue();
    }
}
