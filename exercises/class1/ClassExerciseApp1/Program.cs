/* Exercise 1
 * 
 * Revision History
 *      Gustavo Bonifacio Rodrigues, 2020.01.15: Created
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassExerciseApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // This guarantees a neutral culture interface.
            // This runs the system under a Culture netral enviroment.
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new InvestmentCalculator());
        }
    }
}
