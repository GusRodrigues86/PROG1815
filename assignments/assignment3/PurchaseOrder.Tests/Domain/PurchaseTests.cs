/* PurchaseTests.cs
 *  Test cases for Purchase class
 *  
 *  Revision History
 *      Gustavo Bonifacio Rodrigues, 2020.03.10: Created
 */
using NUnit.Framework;
using PurchaseOrder.Domain;
using System;
using System.Globalization;
using System.Text;

namespace PurchaseOrder.Tests
{
    /// <summary>
    /// Test cases for the Purchase.
    /// </summary>
    public class PurchaseTests
    {
        #region Field and Initialization
        private Purchase purchase;
        [SetUp]
        public void Init()
        {
            purchase = new Purchase(
                id: 1,
                date: DateTime.Today,
                seller: "Test Seller",
                shippedTo: "Test destination",
                description: "",
                ordered: 10,
                unit: "Hours",
                unitCost: 35.0);
        }
        #endregion
        #region Tests for the Purchase ID
        [Test]
        public void PurchaseContainsAnID()
        {
            Assert.AreEqual(1, purchase.GetId());
        }
        #endregion
        #region Tests for the Purchase Date
        [Test]
        public void PurchaseContainsADate()
        {
            Assert.AreEqual(DateTime.Today, purchase.GetDate());
        }
        [Test]
        public void TomorrowSalesCannotHappenToday()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () =>
                {
                    new Purchase(1,
                        date: DateTime.Today.AddDays(1), // broken
                        "Seller", "Shipped", 1.0, "Hours", 10);
                }
                ).ParamName.Equals("Date");
        }
        [Test]
        public void YestedayIsAValidDate()
        {
            var newOrder = new Purchase(2, date: new DateTime(2019, 1, 1),
                        "Seller", "Shipped", 1.0, "Hours", 10);
            var janFirst = new DateTime(2019, 1, 1);
            Assert.AreEqual(janFirst, newOrder.GetDate());
            Assert.AreNotEqual(purchase, newOrder);
        }
        [Test]
        public void CannotChangeDate()
        {
            var newDate = purchase.GetDate().AddDays(2);
            Assert.AreEqual(DateTime.Today, purchase.GetDate());
            Assert.AreNotEqual(newDate, purchase.GetDate());
        }

        #endregion
        #region Tests for the Seller
        [Test]
        public void PurchaseContainsASeller()
        {
            Assert.AreEqual("Test Seller", purchase.GetSeller());
        }
        #endregion
        #region Tests for the ShippedTo
        [Test]
        public void PurchaseContainsShippedTo()
        {
            Assert.AreEqual("Test destination", purchase.GetShippedTo());
        }
        #endregion
        #region Tests for the Ordered
        [Test]
        public void PurchaseContainsOrdered()
        {
            Assert.AreEqual(10, purchase.GetOrdered());
        }
        [Test]
        public void OrderCannotBeNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () =>
                {
                    new Purchase(1,
                        date: DateTime.Today,
                        seller: "Seller",
                        shippedTo: "Shipped",
                        ordered: -1.0,
                        unit: "Hours",
                        unitCost: 10);
                }
                ).ParamName.Equals("Ordered");
        }
        [Test]
        public void OrderCannotBeZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () =>
                {
                    new Purchase(1,
                        date: DateTime.Today,
                        seller: "Seller",
                        shippedTo: "Shipped",
                        ordered: 0,
                        unit: "Hours",
                        unitCost: 10);
                }
                ).ParamName.Equals("Ordered");
        }
        #endregion
        #region Tests for the Unit of purchase
        [Test]
        public void PurchaseContainsUnit()
        {
            Assert.AreEqual("Hours", purchase.GetUnit());
        }
        #endregion
        #region Tests for the Unit Price
        [Test]
        public void PurchaseContainsUnitPrice()
        {
            Assert.AreEqual(35, purchase.GetUnitPrice());
        }
        [Test]
        public void UnitPriceCannotBeNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () =>
                {
                    new Purchase(1,
                        date: DateTime.Today,
                        seller: "Seller",
                        shippedTo: "Shipped",
                        ordered: 1.0,
                        unit: "Hours",
                        unitCost: -10);
                }
                ).ParamName.Equals("UnitCost");
        }
        [Test]
        public void UnitPriceCannotBeZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () =>
                {
                    new Purchase(1,
                        date: DateTime.Today,
                        seller: "Seller",
                        shippedTo: "Shipped",
                        ordered: 1.0,
                        unit: "Hours",
                        unitCost: 0);
                }
                ).ParamName.Equals("UnitCost");
        }
        #endregion
        #region Tests for the Before tax
        [Test]
        public void PurchaseContainsAmountCost()
        {
            Assert.AreEqual(350, purchase.GetBeforeTaxes());
        }
        #endregion
        #region Tests for the Total
        [Test]
        public void PurchaseContainsTotalWithTax()
        {
            Assert.AreEqual(395.5, purchase.GetTotal(), 0.1d);
        }
        #endregion
        #region Tests for the ToString
        [Test]
        public void TestToString()
        {

            int id = 1, ordered = 10;
            string unitCost = 35.0.ToString("c2", CultureInfo.CreateSpecificCulture("en-CA"));
            string date = DateTime.Today.ToString("yyyy-MM-dd"), seller = "Test Seller", shippedTo = "Test destination", description = "",
            unit = "Hours";

            StringBuilder builder = new StringBuilder();
            builder.Append("[");
            builder.Append($"id: {id}\\,");
            builder.Append($"Date: {date}\\,");
            builder.Append($"Purchased From: {seller}\\,");
            builder.Append($"Ship to: {shippedTo}\\,");
            builder.Append($"Description: {description}\\,");
            builder.Append($"Ordered: {ordered}\\,");
            builder.Append($"Unit: {unit}\\,");
            builder.Append($"Unit Price: {unitCost}\\,");
            builder.Append(@"Ammount: $350.00\,");
            builder.Append(@"Total Ammount: $395.50");
            builder.Append("]");
            string expected = builder.ToString();

            Assert.AreEqual(expected, purchase.ToString());
        }
        #endregion
    }
}