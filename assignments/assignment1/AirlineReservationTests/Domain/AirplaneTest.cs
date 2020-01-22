using AirlineReservation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineReservationTests.Domain
{
    class AirplaneTest
    {
        private Airplane ap;
        [SetUp]
        public void Init() => ap = new Airplane();
        [TearDown]
        public void Dispose() => ap = null;

        /*
         * Assign Seat Tests
         */
        [Test]
        public void AssignEmptySeat_ReturnsTrue()
        {
            // Assemble
            string customer = "John Doe";
            string seat = "1A";
            // act
            Assert.IsTrue(ap.AssignSeatTo(seat, customer));
        }

        [Test]
        public void AssignAssignedSeat_ReturnsFalse()
        {
            // Assemble
            string customer1 = "Wile E. Coyote";
            string customer2 = "Road Runner";
            string seat = "1A";
            // act
            Assert.IsTrue(ap.AssignSeatTo(seat, customer2)); // sorry Wile
            Assert.IsFalse(ap.AssignSeatTo(seat, customer1));
        }

        /*
         * Unassign Seat Test
         */
        [Test]
        public void UnassignEmptySeat_ReturnsFalse()
        {
            // Assemble
            string seat = " ";
            // act
            Assert.IsFalse(ap.UnassignSeat(seat));
        }
        
        [Test]
        public void UnassignSeatWithCustomer_ReturnsTrue()
        {
            // Assemble
            string customer = "Wile E. Coyote";
            string seat = "1A";
            ap.AssignSeatTo(seat, customer);

            // Act
            // Assert
            Assert.IsTrue(ap.UnassignSeat(seat)); // Sorry again Wile.
        }
        /*
         * ToString testing
         */

        [Test]
        public void testToString()
        {
            // Assemble
            string expected = "1A - test\r\n" +
                "1B - test\r\n" +
                "1C - test\r\n" +
                "2A - test\r\n";
            ap.AssignSeatTo("1A", "test");
            ap.AssignSeatTo("1B", "test");
            ap.AssignSeatTo("1C", "test");
            ap.AssignSeatTo("2A", "test");
            // Act
            string actual = ap.ToString();
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
