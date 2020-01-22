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
        /* ToString testing
         */

        [Test]
        public void testToString()
        {
            // Assemble
            string expected =
                "1A - test\r\n" +
                "1B - test\r\n" +
                "1C - test\r\n" +
                "1D - \r\n" +
                "2A - test\r\n" +
                "2B - \r\n" +
                "2C - \r\n" +
                "2D - \r\n" +
                "3A - \r\n" +
                "3B - \r\n" +
                "3C - \r\n" +
                "3D - \r\n" +
                "4A - \r\n" +
                "4B - \r\n" +
                "4C - \r\n" +
                "4D - \r\n" +
                "5A - \r\n" +
                "5B - \r\n" +
                "5C - \r\n" +
                "5D - ";

            ap.AssignSeatTo("1A", "test");
            ap.AssignSeatTo("1B", "test");
            ap.AssignSeatTo("1C", "test");
            ap.AssignSeatTo("2A", "test");
            // Act
            string actual = ap.ToString();
            // Assert
            Assert.AreEqual(expected, actual);
        }


        /* IsFull Tests cases
         */
        [Test]
        public void AssignSeatInFullPlane_WillReturnTrue()
        {
            string[] customers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12",
            "13","14","15","16","17","18","19","20"};
            string[] seats = { "1A", "1B", "1C", "1D", "2A", "2B", "2C", "2D", "3A", "3B", "3C", "3D",
            "4A","4B","4C","4D","5A","5B","5C","5D"};
            for (int i = 0; i < customers.Length; i++)
            {
                ap.AssignSeatTo(seats[i], customers[i]);
            }

            // act
            // Assert
            Assert.IsFalse(ap.AssignSeatTo("1A", "Wilie E Coyote"));
        }
        [Test]
        public void AssignSeatInANotFull_WillReturnTrue()
        {
            string[] customers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12",
            "13","14","15","16","17","18","19",};
            string[] seats = { "1A", "1B", "1C", "1D", "2A", "2B", "2C", "2D", "3A", "3B", "3C", "3D",
            "4A","4B","4C","4D","5A","5B","5C","5D"};
            for (int i = 0; i < customers.Length; i++)
            {
                Assert.IsTrue(ap.AssignSeatTo(seats[i], customers[i]));
            }
        }
        /* Empty seat test cases
         */
        [Test]
        public void IsSeatEmptyInAnEmptyPlane_WillReturnTrue()
        {
            string[] seats = { "1A", "1B", "1C", "1D", "2A", "2B", "2C", "2D", "3A", "3B", "3C", "3D",
            "4A","4B","4C","4D","5A","5B","5C","5D"};
            foreach (var seat in seats)
            {
                Assert.IsTrue(ap.IsSeatEmpty(seat));
            }
        }
        [Test]
        public void IsSeatEmptyOnAnFullPlane_WillReturnFalse()
        {
            string[] customers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12",
            "13","14","15","16","17","18","19","20"};
            string[] seats = { "1A", "1B", "1C", "1D", "2A", "2B", "2C", "2D", "3A", "3B", "3C", "3D",
            "4A","4B","4C","4D","5A","5B","5C","5D"};
            for (int i = 0; i < customers.Length; i++)
            {
                ap.AssignSeatTo(seats[i], customers[i]);
            }

            foreach (string seat in seats)
            {
                Assert.IsFalse(ap.IsSeatEmpty(seat));
            }
        }
    }
}
