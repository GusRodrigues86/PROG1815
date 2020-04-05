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
using System.Text;

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
        private const string FILE_NAME = "Products.txt";
        /// <summary>
        /// Stream writer to write file
        /// </summary>
        private static StreamWriter writer;
        /// <summary>
        ///  StreamReader to read the file
        /// </summary>
        private static StreamReader reader;
        /// <summary>
        /// if we are inserting into file.
        /// </summary>
        private bool isInsert = false;

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

        #endregion
        #region Constructor
        /// <summary>
        /// Instantiates a Product Object
        /// </summary>
        /// <param name="productName">The name of the product</param>
        /// <param name="productPrice">The price of the product</param>
        /// <param name="factor">The topping factor related to a small pizza</param>
        /// <param name="isTopping">Is a topping item or not</param>
        /// <param name="description">The description of the product</param>
        public GBRProduct(string productName, double productPrice, double factor, bool isTopping, string description)
        {
            this.productName = productName;
            this.price = productPrice;
            this.costFactor = factor;
            this.isTopping = isTopping;
            this.description = description;
        }
        #endregion
        #region Properties Getters
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
        #endregion

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        public static List<GBRProduct> GBRGetProducts()
        {
            var products = new List<GBRProduct>();

            using (reader = new StreamReader(FILE_NAME))
            {
                while (!reader.EndOfStream)
                {
                    string record = reader.ReadLine();
                    products.Add(Parse(record));
                }
            }
            return products;
        }

        /// <summary>
        /// Retrieves the first object with that name
        /// </summary>
        /// <param name="name">The name of the product</param>
        /// <returns></returns>
        public static GBRProduct GBRGetByProductName(string name)
        {
            // open the stream
            using (reader = new StreamReader(FILE_NAME))
            {
                // search
                while (!reader.EndOfStream)
                {
                    string record = reader.ReadLine();
                    if (record.StartsWith(name))
                    {
                        return Parse(record);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Retrieves the first product using the description supplied.
        /// Null if none.
        /// </summary>
        /// <param name="description">The description</param>
        /// <returns>The first product that matches the description, null if none.</returns>
        public static GBRProduct GBRGetByDescription(string description)
        {
            using (reader = new StreamReader(FILE_NAME))
            {
                while (!reader.EndOfStream)
                {
                    // split to get the description
                    var record = reader.ReadLine();
                    string fileDescription = record.Split('\t')[4];
                    if (fileDescription.Contains(description))
                    {
                        return Parse(record);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Attempts to write on file
        /// </summary>
        /// <exception cref="Exception">With all errors in the message.</exception>
        public void GBRAdd(GBRProduct product)
        {
            product.isInsert = true;

            try
            {
                SaveToFile(product);
            }
            catch (Exception ex)
            {
                throw new Exception("Errors during insertion:\n" + ex.Message);
            }
        }

        /// <summary>
        /// Updates file 
        /// </summary>
        /// <param name="product">The product to be updated</param>
        public void GBRUpdate(GBRProduct product)
        {
            try
            {
                SaveToFile(product, true);
            }
            catch (Exception ex)
            {
                throw new Exception("Errors during update:\n" + ex.Message);
            }
        }

        /// <summary>
        /// Remove the product from file
        /// </summary>
        /// <param name="product">Remove from file</param>
        public void GBRDelete(GBRProduct product)
        {
            try
            {
                DeleteAndSaveFile(product);
            }
            catch (Exception ex)
            {
                throw new Exception("Errors during delete:\n" + ex.Message);
            }
        }

        /// <summary>
        /// Parse a string to a Product
        /// </summary>
        /// <param name="input">the string format saved on file</param>
        /// <returns>An instance of GBRProduct.</returns>
        /// <exception cref="Exception">Invalid field is supplied</exception>
        public static GBRProduct Parse(string input)
        {
            // fields order:
            // productName, price, costFactor, isTopping and description.
            // double format is F2, i.e. 1024.32 -> no comma for thousands.
            // split is based on \t index.
            string[] fields = input.Split('\t');
            // create instance
            if (fields.Length == 5)
            {
                // convertion of string to doubles
                double parsedPrice = Convert.ToDouble(fields[1], CULTURE.NumberFormat);
                double parsedCostFactor = Convert.ToDouble(fields[2], CULTURE.NumberFormat);
                bool parsedIsTopping = Convert.ToBoolean(fields[3]); // convert to boolean
                return new GBRProduct(fields[0], parsedPrice, parsedCostFactor, parsedIsTopping, fields[4]);
            }
            else
            {
                throw new Exception("Invalid fields on file");
            }
        }

        /// <summary>
        /// Validates the object
        /// </summary>
        /// <exception cref="Exception">If it has errors with all errors in the message</exception>
        private void Edit()
        {
            // trim
            productName += "";
            productName = productName.Trim();
            description += "";
            description = description.Trim();

            string errors = "";
            if (string.IsNullOrEmpty(productName))
            {
                errors += "The product name is empty.\n";
            }
            if (isInsert && GBRGetByProductName(productName) != null)
            {
                errors += "Product already on file.\n";
            }
            if (string.IsNullOrEmpty(description))
            {
                errors += "The product description is empty.\n";
            }
            if (price <= 0)
            {
                errors += "The price needs to be bigger than 0.\n";
            }
            if (costFactor <= 0)
            {
                errors += "The cost factor needs to be bigger than 0.\n";
            }
            if (!string.IsNullOrWhiteSpace(errors))
            {
                throw new Exception(errors);
            }
        }

        /// <summary>
        /// Save this instance to file
        /// </summary>
        private void SaveToFile(GBRProduct product, bool isUpdate = false)
        {
            Edit(); // try to validate the product
            // get all
            List<GBRProduct> list = GBRGetProducts();
            if (isUpdate)
            {
                // prevent duplicate
                list.RemoveAll(p => p.ProductName.ToLower().Equals(product.ProductName.ToLower()));
            }
            list.Add(product);
            using (writer = new StreamWriter(FILE_NAME, false))
            {
                list.ForEach(p => writer.WriteLine(p.ToString()));
            }
        }

        /// <summary>
        /// Delete the supplied product and save file.
        /// </summary>
        /// <param name="product">The product to be delete.</param>
        private void DeleteAndSaveFile(GBRProduct product)
        {
            // get all
            List<GBRProduct> list = GBRGetProducts();
            // prevent duplicate
            list.RemoveAll(p => p.ProductName.ToLower().Equals(product.ProductName.ToLower()));
            using (writer = new StreamWriter(FILE_NAME, false))
            {
                list.ForEach(p => writer.WriteLine(p.ToString()));
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            // fields order:
            // productName, price, costFactor, isTopping and description.
            // double format is F2, i.e. 1024.32 -> no comma for thousands.
            // space is based on \t.

            StringBuilder builder = new StringBuilder();
            builder.Append(productName);
            builder.Append("\t");
            builder.Append(price.ToString("F2", CULTURE.NumberFormat));
            builder.Append("\t");
            builder.Append(costFactor.ToString("F2", CULTURE.NumberFormat));
            builder.Append("\t");
            builder.Append(isTopping);
            builder.Append("\t");
            builder.Append(description);

            return builder.ToString();
        }
    }
}
