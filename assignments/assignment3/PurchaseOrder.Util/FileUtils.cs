using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PurchaseOrder.Util
{
    /// <summary>
    /// Holds readers for the project.
    /// </summary>
    public static class FileUtils
    {
        /// <summary>
        /// Opens a fileStream for the desired file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Thte StreamReader with the file</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="IOException"></exception>
        public static StreamReader CSVReader(string fileName) =>
            new StreamReader(fileName);

        /// <summary>
        /// Creates a file if It doesnt exist.
        /// </summary>
        /// <param name="path">The path to the file</param>
        /// <param name="fileName">The file name</param>
        /// <returns>True iff able to create file.</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></ exception >
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="PathTooLongException"></ exception >
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="IOException"></ exception >
        /// <exception cref="NotSupportedException"></exception>
        public static bool CreateFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
                return true;
            }
            return false;
        }


    }
}
