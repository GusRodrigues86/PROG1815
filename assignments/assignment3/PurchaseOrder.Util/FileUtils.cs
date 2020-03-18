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
        /// <returns>The StreamReader with the file</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="IOException"></exception>
        public static StreamReader FileReader(string fileName) =>
            new StreamReader(fileName);

        /// <summary>
        /// Creates a file. If not specied, it won't overwrite if already exists.
        /// </summary>
        /// <param name="fileName">The file name</param>
        /// <param name="forceOverwrite">If overwrites existing file.</param>
        /// <returns>True iff able to create file.</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="PathTooLongException"></exception >
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        public static bool CreateFile(string fileName, bool forceOverwrite=false)
        {
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
                return true;
            }
            else if (File.Exists(fileName) && forceOverwrite)
            {
                File.Create(fileName).Close();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Appends item to the file.
        /// </summary>
        /// <typeparam name="T">The type of the item</typeparam>
        /// <param name="file">the path and filename to be appended.</param>
        /// <param name="item">The item to append.</param>
        /// <returns>True iff able to append.</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="PathTooLongException"></exception >
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        public static bool AppendToFile<T>(string file, T item)
        {
            // sanity checks
            if (!File.Exists(file) || item == null)
            {
                return false;
            }
            // append to the end of the file
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                writer.WriteLine(item.ToString());
                return true;
            }
        }

        /// <summary>
        /// Write all item in the list to the file.
        /// </summary>
        /// <typeparam name="T">The type of the list</typeparam>
        /// <param name="file">the file to be saved.</param>
        /// <param name="list">the list with objects to be saved</param>
        /// <returns>True iff able to append.</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception >
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="PathTooLongException"></exception >
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        public static bool SaveAllRecords<T>(string file, List<T> list)
        {
            if (!File.Exists(file) || list is null || list.Count == 0)
            {
                return false;
            }
            // rewrite file
            using (StreamWriter writer = new StreamWriter(file, false))
            {
                list.ForEach(e => writer.WriteLine(e.ToString()));
                return true;
            }
        }
        /// <summary>
        /// Creates the default Folder inside the project.
        /// </summary>
        /// <param name="currentPath">The path to be created.</param>
        public static void CreateFolder(string currentPath)
        {
            Directory.CreateDirectory(currentPath);
        }
    }
}
