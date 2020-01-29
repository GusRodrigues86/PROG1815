using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator.Service
{
    /// <summary>
    /// Perform the calculation as requested by the calculator
    /// </summary>
    class CalculationService
    {

        /// <summary>
        /// Returns the sum two integers, x and y as: x + y
        /// </summary>
        /// <param name="x">value of x, otherwise 0.</param>
        /// <param name="y">value of y, otherwise 0</param>
        /// <returns>The resulting sum of x and y</returns>
        internal static int SumValues(int x = 0, int y = 0) => x + y;

        /// <summary>
        /// Returns the subtraction of two integers, x and y as: x - y
        /// </summary>
        /// <param name="x">value of x, otherwise 0.</param>
        /// <param name="y">value of y, otherwise 0</param>
        /// <returns>The resulting sum of x and y</returns>
        internal static int SubtractValues(int x = 0, int y = 0) => x - y;

        /// <summary>
        /// Returns the multiplication of two integers, x and y, as: x * y
        /// </summary>
        /// <param name="x">value of x, otherwise 0.</param>
        /// <param name="y">value of y, otherwise 0</param>
        /// <returns></returns>
        internal static int MultiplyFactors(int x = 0, int y = 0) => x * y;

        /// <summary>
        /// Returns the division of two integers, x and y, as: x / y
        /// </summary>
        /// <param name="x">value of x, otherwise 0.</param>
        /// <param name="y">value of y, otherwise 0</param>
        /// <returns></returns>
        /// <exception cref="DivideByZeroException">if y is 0</exception>
        internal static int DivideFactors(int x = 0, int y = 0) => x / y;
    }
}
