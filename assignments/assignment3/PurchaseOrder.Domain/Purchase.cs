﻿/* Purchase.cs
 *  Representation of a purchase
 *  
 *  Revision History
 *      Gustavo Bonifacio Rodrigues, 2020.03.10: Created
 */

using System;
using System.Globalization;
using System.Text;

namespace PurchaseOrder.Domain
{
    /// <summary>
    /// Represents a Purchase
    /// </summary>
    public class Purchase
    {
        #region Fields
        /// <summary>
        /// The ID of the purchase.
        /// </summary>
        private int Id;
        /// <summary>
        /// The Date of the purchase.
        /// </summary>
        private DateTime Date;
        /// <summary>
        /// Represents who selled the product.
        /// </summary>
        private string Seller;
        /// <summary>
        /// Represents who buyed.
        /// </summary>
        private string ShippedTo;
        /// <summary>
        /// The product description
        /// </summary>
        private string Description;
        /// <summary>
        /// The ammount ordered
        /// </summary>
        private double Ordered;
        /// <summary>
        /// The unit, such as Hours
        /// </summary>
        private string Unit;
        /// <summary>
        /// The cost per unit
        /// </summary>
        private double UnitCost;
        /// <summary>
        /// The subtotal
        /// </summary>
        private double Subtotal;
        /// <summary>
        /// The ammount after taxes.
        /// </summary>
        private const double taxes = 0.13;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates an Purchase object
        /// </summary>
        /// <param name="id">The order Id</param>
        /// <param name="date">The day of the purchase</param>
        /// <param name="seller">The seller</param>
        /// <param name="shippedTo">Shipped to/Buyer</param>
        /// <param name="ordered">Amound ordered</param>
        /// <param name="unit">Unit of the order</param>
        /// <param name="unitCost">Cost of the order</param>
        public Purchase(int id, DateTime date, string seller, string shippedTo, double ordered, string unit, double unitCost, string description = "")
        {
            this.Id = id;
            this.Date = date;
            this.Seller = seller;
            this.ShippedTo = shippedTo;
            this.Ordered = ordered;
            this.Unit = unit;
            this.UnitCost = unitCost;
            this.Description = description;
            CheckRep();
            // if valid, calculate
            this.Subtotal = this.UnitCost * this.Ordered;

        }
        #endregion

        #region Getters
        /// <summary>
        /// Return the Purchase Id
        /// </summary>
        /// <returns>The Purchase Id</returns>
        public double GetId() => this.Id;

        /// <summary>
        /// Returns the Date of the purchase
        /// </summary>
        /// <returns>The Date of the purchase</returns>
        public DateTime GetDate() => new DateTime(Date.Ticks);

        /// <summary>
        /// Returns who selled.
        /// </summary>
        /// <returns>Who selled</returns>
        public string GetSeller() => this.Seller;

        /// <summary>
        /// Return the ammount ordered
        /// </summary>
        /// <returns>The ammount ordered</returns>
        public double GetOrdered() => this.Ordered;

        /// <summary>
        /// Returns the unit used to price the sale
        /// </summary>
        /// <returns>The unit used to price the sale</returns>
        public string GetUnit() => this.Unit;

        /// <summary>
        /// Returns the information about the recipient.
        /// </summary>
        /// <returns>The information of the shipped to</returns>
        public string GetShippedTo() => this.ShippedTo;

        /// <summary>
        /// Returns the description of the purchase.
        /// </summary>
        /// <returns>The description of the purchase</returns>
        public string GetDescription() => this.Description;

        /// <summary>
        /// Returns the unit cost of the purchase.
        /// </summary>
        /// <returns>The unit cost of the purchase</returns>
        public double GetUnitPrice() => this.UnitCost;

        /// <summary>
        /// Calculate the total cost before taxes.
        /// </summary>
        /// <returns>The total before taxes</returns>
        public double GetBeforeTaxes() => this.Subtotal;

        /// <summary>
        /// Calculate the total after taxes of 13%.
        /// </summary>
        /// <returns>The total after taxes</returns>
        public double GetTotal() => this.Subtotal * (1+taxes);
        #endregion

        #region Overrides
        public override string ToString()
        {
            // formatting
            CultureInfo canCulture = CultureInfo.CreateSpecificCulture("en-CA");
            string price = this.UnitCost.ToString("c2", canCulture);
            string beforeTax = this.Subtotal.ToString("c2", canCulture);
            string total = GetTotal().ToString("c2", canCulture);

            StringBuilder builder = new StringBuilder();
            builder.Append("[");
            builder.Append($"id: {Id} ");
            builder.Append($"Date: {Date.ToString("yyyy-MM-dd")} ");
            builder.Append($"Purchased From: {Seller} ");
            builder.Append($"Ship to: {ShippedTo} ");
            builder.Append($"Description: {Description} ");
            builder.Append($"Ordered: {Ordered} ");
            builder.Append($"Unit: {Unit} ");
            builder.Append($"Unit Price: {price} ");
            builder.Append($"Ammount: {beforeTax} ");
            builder.Append($"Total Ammount: {total}");
            builder.Append("]");

            return builder.ToString();
        }

        public override int GetHashCode()
        {
            // autogenerated. 72859 is a prime number.
            return 72859 + Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            // Id is the field that defines equality.
            return obj is Purchase purchase &&
                   Id == purchase.Id;
        }

        #endregion

        #region Invariant Check
        /// <summary>
        /// Invariant of an order.
        /// if any of the parameters bellow are violated, the program will throw exception and prevent the formation of the corrupted purchase
        /// Id > 0
        /// Date <= DateTime.Today
        /// Seller != Whitespace
        /// ShippedTo != Whitespace
        /// Ordered > 0
        /// Unit = "Hours"
        /// UnitCost > 0
        /// </summary>
        private void CheckRep()
        {
            _ = (this.Id <= 0) ? throw new ArgumentOutOfRangeException("Id", this.Id, "Invalid ID") : "";
            _ = (this.Date.CompareTo(DateTime.Today) > 0) ? throw new ArgumentOutOfRangeException("Date", this.Date, "Date cannot be in the future.") : "";
            _ = (String.IsNullOrWhiteSpace(this.Seller)) ? throw new ArgumentOutOfRangeException("Seller", this.Seller, "Need a Seller.") : "";
            _ = (String.IsNullOrWhiteSpace(this.ShippedTo)) ? throw new ArgumentOutOfRangeException("ShippedTo", this.ShippedTo, "Need someone to ship to.") : "";
            _ = (this.Description is null) ? throw new ArgumentOutOfRangeException("Description", this.Description, "Description cannot be null") : "";
            _ = (this.Ordered <= 0) ? throw new ArgumentOutOfRangeException("Ordered", this.Ordered, "Invalid ammount.") : "";
            _ = (String.IsNullOrWhiteSpace(this.Unit)) ? throw new ArgumentOutOfRangeException("Unit", this.Unit, "Need A value unit.") : "";
            _ = (this.UnitCost <= 0) ? throw new ArgumentOutOfRangeException("UnitCost", this.UnitCost, "Invalid price.") : "";
        }
        #endregion

    }
}
