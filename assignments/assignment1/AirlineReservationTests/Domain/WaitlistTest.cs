using AirlineReservation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineReservationTests.Domain
{
    class WaitlistTest
    {
        Waitlist waitlist;
        /*
         * Test should cover the enqueue and dequeue.
         * Test should confirm guarantee that the queue is encapsulated properly
         */

        [SetUp]
        public void Init() => waitlist = new Waitlist();

        [TearDown]
        public void Dispose() => waitlist = null;

        /* Enqueue tests
         */
        [Test]
        public void WhenWaitlistNotFull_EnqueueReturnTrue()
        {
            // Assemble
            string customer = "John Smith";
            // Act
            bool actual = waitlist.Enqueue(customer);
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void WhenWaitlistNotFull_EnqueueAlwaysReturnTrue()
        {
            // Assemble
            string[] customers = { "John Smith", "Ariadne", "Ulysses" };
            // Act
            // Assert
            foreach (var customer in customers)
            {
                Assert.IsTrue(waitlist.Enqueue(customer));
            }
        }

        [Test]
        public void WhenWaitlistFull_EnqueueReturnFalse()
        {
            // Assemble
            string[] customers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", };
            foreach (string customer in customers)
            {
                waitlist.Enqueue(customer);
            }
            // Act
            bool actual = waitlist.Enqueue("Fail here");
            // Assert
            Assert.IsFalse(actual);
        }

        /* Dequeue tests
         */

        [Test]
        public void WhenWaitlistIsEmpty_DequeueReturnEmptyString()
        {
            // Assemble
            // Act
            string actual = waitlist.Dequeue();
            // Assert
            Assert.IsTrue(String.IsNullOrWhiteSpace(actual));
        }
        [Test]
        public void WhenWaitlistIsNotEmpty_DequeueRemoveFirstElementInserted()
        {
            // Assemble
            string customer = "John Smith";
            waitlist.Enqueue(customer);
            customer = "Mike";
            waitlist.Enqueue(customer);
            // Act
            string actual = waitlist.Dequeue();
            // Assert
            Assert.AreEqual("John Smith", actual);
        }

        /*
         * WaitlistedCustomers test
         */
        [Test]
        public void WhenWaitlistIsEmpty_WaitlistedCustomersReturnAnArraySizeOneWithEmptyString()
        {
            // Assemble
            // Act
            string[] actual = waitlist.WaitlistedCustomers();
            // Assert
            Assert.AreEqual(1, actual.Length);
            Assert.IsTrue(String.IsNullOrWhiteSpace(actual[0]));
        }
        [Test]
        public void WhenWaitlistHasOneItem_WaitlistedCustomersReturnAnArraySizeOneWithNonEmptyString()
        {
            // Assemble
            string[] customers = { "John Smith", "Ariadne", "Ulysses" };
            foreach (var customer in customers)
            {
                waitlist.Enqueue(customer);
            }
            // Act
            string[] actual = waitlist.WaitlistedCustomers();
            
            // Assert
            Assert.AreEqual("John Smith",actual[0]);
            Assert.AreEqual("Ariadne", actual[1]);
            Assert.AreEqual("Ulysses", actual[2]);
            Assert.AreEqual(3, actual.Length); 
        }

        [Test]
        public void WhenWaitlistHasFourItesm_WaitlistedCustomersReturnAnArraySizeFoursWithFourElements()
        {
            // Assemble
            string[] customers = { "John Smith", "Ariadne", "Ulysses", "Kratos"};
            foreach (var customer in customers)
            {
                waitlist.Enqueue(customer);
            }
            // Act
            string[] actual = waitlist.WaitlistedCustomers();

            // Assert
            Assert.AreEqual("John Smith", actual[0]);
            Assert.AreEqual("Ariadne", actual[1]);
            Assert.AreEqual("Ulysses", actual[2]);
            Assert.AreEqual("Kratos", actual[3]);
            Assert.AreEqual(4, actual.Length);
        }

    }
}
