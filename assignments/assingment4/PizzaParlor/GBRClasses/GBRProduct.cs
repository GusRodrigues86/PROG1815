/* Assignment 4
 * GBRProduct.cs
 * 
 * Revision History
 *      Gustavo Bonifacio Rodrigues, 2020.03.30: Created
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.GBRClasses
{
    /// <summary>
    /// The Product that follows the specification
    /// </summary>
    class GBRProduct
    {
        #region static fields
        /// <summary>
        /// enforce invariant for system culture.
        /// </summary>
        private static CultureInfo CULTURE = new CultureInfo("en-CA", false);
        /// <summary>
        /// Path to the file
        /// </summary>
        private const string PATH_TO_FILE = "";
        #endregion
        #region Fields        
        /// <summary>
        /// The name of the product
        /// </summary>
        private string productName;
        /// <summary>
        /// The description of the product.
        /// </summary>
        private string description;
        /// <summary>
        /// The price of the product
        /// </summary>
        private double price;
        /// <summary>
        /// The cost factor of the product, based from a medium pizza
        /// </summary>
        private double costFactor;
        /// <summary>
        /// Is this product a topping?
        /// </summary>
        private bool isTopping;
        /// <summary>
        /// Stream writer to write file
        /// </summary>
        private StreamWriter writer;
        /// <summary>
        ///  StreamReader to read the file
        /// </summary>
        private StreamReader reader;

        private Dictionary<string, GBRProduct> memory;
        #endregion

        /// <summary>
        /// The name of the product
        /// </summary>
        public string ProductName => this.productName;

        /// <summary>
        /// The description of the product
        /// </summary>
        public string Description => this.description;

        /// <summary>
        /// The price of the product
        /// </summary>
        public double Price => this.price;

        /// <summary>
        /// The cost factor of the product
        /// </summary>
        public double CostFactorForToppings => this.costFactor;

        /// <summary>
        /// If the product is a toping
        /// </summary>
        public bool IsPizzaTopping => this.isTopping;


    }
}
