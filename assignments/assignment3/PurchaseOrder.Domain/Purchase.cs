/* Purchase.cs
 *  Representation of a purchase
 *  
 *  Revision History
 *      Gustavo Bonifacio Rodrigues, 2020.03.10: Created
 */

using System;
using System.Collections.Generic;
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

        #region Constructors
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

        public Purchase(string file)
        {
            var numberFormat = new CultureInfo("en-CA", false).NumberFormat;
            var fileStructure = file.Split('\t');
            this.Id = int.Parse(fileStructure[0]);
            this.Date = DateTime.Parse(fileStructure[1]);
            this.Seller = fileStructure[2];
            this.ShippedTo = fileStructure[3];
            this.Ordered = double.Parse(fileStructure[4], numberFormat);
            this.Unit = fileStructure[5];
            this.UnitCost = double.Parse(fileStructure[6],numberFormat);
            // description may contain \t. to prevent, append all items from 9 and going on.
            StringBuilder builder = new StringBuilder();
            for (int i = 9; i < fileStructure.Length; i++)
            {
                builder.Append(fileStructure[i]);
            }
            this.Description = builder.ToString().Substring(6);
            CheckRep();
            // if valid, calculate
            this.Subtotal = this.UnitCost * this.Ordered;
        }

        /// <summary>
        /// Creates a deep copy of the supplied purchase.
        /// </summary>
        /// <param name="purchase">The original object to be copied</param>
        private Purchase(Purchase purchase)
        {
            this.Id = purchase.GetId();
            this.Date = purchase.GetDate();
            this.Seller = purchase.GetSeller();
            this.ShippedTo = purchase.GetShippedTo();
            this.Ordered = purchase.GetOrdered();
            this.Unit = purchase.GetUnit();
            this.UnitCost = purchase.GetUnitPrice();
            this.Description = purchase.GetDescription();
            CheckRep();
            // if valid, calculate
            this.Subtotal = this.UnitCost * this.Ordered;
        }


        #endregion

        #region Getters or observers
        /// <summary>
        /// Return the Purchase Id
        /// </summary>
        /// <returns>The Purchase Id</returns>
        public int GetId() => this.Id;

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
        
        #region Producer
        /// <summary>
        /// Creates a deep copy of the purchase.
        /// </summary>
        /// <returns>A copy of this object</returns>
        public Purchase Copy()
        {
            return new Purchase(this);
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            // formatting
            CultureInfo canCulture = CultureInfo.CreateSpecificCulture("en-CA");
            string price = this.UnitCost.ToString("N2", canCulture);
            string beforeTax = this.Subtotal.ToString("N2", canCulture);
            string total = GetTotal().ToString("N2", canCulture);

            StringBuilder builder = new StringBuilder();
            builder.Append($"{Id}\t");
            builder.Append($"{Date.ToString("yyyy-MM-dd")}\t");
            builder.Append($"{Seller}\t");
            builder.Append($"{ShippedTo}\t");
            builder.Append($"{Ordered}\t");
            builder.Append($"{Unit}\t");
            builder.Append($"{price}\t");
            builder.Append($"{beforeTax}\t");
            builder.Append($"{total}\t");
            builder.Append($"desc: {Description}");

            return builder.ToString();
        }

        public override bool Equals(object obj)
        {
            // Equality disregard only the Description, Unit and the Subtotal
            // Autogenerated by Visual Studio
            return obj is Purchase purchase &&
                   Id == purchase.Id &&
                   Date == purchase.Date &&
                   Seller == purchase.Seller &&
                   ShippedTo == purchase.ShippedTo &&
                   Ordered == purchase.Ordered &&
                   UnitCost == purchase.UnitCost;
        }

        public override int GetHashCode()
        {
            // autogenerated by Visual Studio
            var hashCode = -1819453216;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Seller);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ShippedTo);
            hashCode = hashCode * -1521134295 + Ordered.GetHashCode();
            hashCode = hashCode * -1521134295 + UnitCost.GetHashCode();
            return hashCode;
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
