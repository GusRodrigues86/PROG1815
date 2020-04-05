/** inClass task 4
 * IOUtils.cs
 *  Utility class to handle IO operation for the form
 *  
 *  Revision history
 *      Gustavo Bonifacio Rodrigues: 2020.04.01, Created
 */
using System;
using System.IO;

namespace IOTestinClass.Utilities
{
    /// <summary>
    /// IO Utility Class
    /// </summary>
    class IOUtils
    {
        /// <summary>
        /// Create the file in the supplied path
        /// </summary>
        /// <param name="pathWithFile">The path and the filename</param>
        /// <param name="deleteExistingFile">Delete the file, if exists.</param>
        /// <param name="createFile">Create the file. It will overwrite if existing</param>
        public static void File_CreatePath(string pathWithFile, bool deleteExistingFile = false, bool createFile = true)
        {
            string path = pathWithFile;
            string filename = "";
            // extract the path and filename
            if (path.StartsWith(@"\"))
            {
                path = path.Substring(1);
            }
            
            if (path.EndsWith(@"\"))
            {
                path = path.Substring(0, path.LastIndexOf(@"\") + 1);
                filename = "";
            }
            else
            {
                if (path.Contains(@"."))
                {
                    filename = path.Substring(path.LastIndexOf(@"\")+ 1);
                    path = path.Substring(0, path.LastIndexOf(@"\") + 1);
                }
                else
                {
                    path += @"\";
                }
            }

            
            Directory_CreatePath(path);
            if (createFile && filename.Length == 0)
            {
                throw new ArgumentException("No filename provided.");
            }

            if (File.Exists(path + filename))
            {
                // wants to override if the file exists
                if (!deleteExistingFile && createFile)
                {
                    CreateFile(pathWithFile, createFile);
                }
                // just delete the file
                else if (deleteExistingFile && !createFile)
                {
                    DeleteFile(pathWithFile);
                }
                // do nothing!
                else if (!deleteExistingFile && !createFile)
                {
                    return;
                }
            }
            else
            {
                if (!createFile)
                {
                    return;
                }
                else
                {
                    CreateFile(path + filename, true);
                }
            }
        }

        /// <summary>
        /// Creates a file in the directory following override rule
        /// </summary>
        /// <param name="pathWithFile">The path and filename</param>
        /// <param name="overwrite">Should overwrite if existing.</param>
        private static void CreateFile(string pathWithFile, bool overwrite)
        {
            if (overwrite)
            {
                CreateFile(pathWithFile);
            }
            else
            {
                if (!File.Exists(pathWithFile))
                {
                    CreateFile(pathWithFile);
                }
            }
        }

        /// <summary>
        /// Creates a file in the directory 
        /// </summary>
        /// <param name="pathWithFile">The path with the directory</param>
        private static void CreateFile(string pathWithFile)
        {
            try
            {
                File.Create(pathWithFile).Close();

            }
            catch (DirectoryNotFoundException)
            {
                throw new Exception("The specified path is invalid .");
            }
            catch (NotSupportedException)
            {
                throw new Exception("The path is invalid.");
            }
            catch (PathTooLongException)
            {
                throw new Exception("The specified path is too long.");
            }
            catch (UnauthorizedAccessException)
            {
                throw new Exception("Not enough required permission to do that.");
            }
            catch (ArgumentException)
            {
                throw new Exception("Invalid character provid for the path and/or filename.");
            }
            catch (IOException)
            {
                throw new Exception("The operation failed or was interrupted.");
            }
        }

        /// <summary>
        /// Delete file, if exists.
        /// </summary>
        /// <param name="pathWithFile"></param>
        private static void DeleteFile(string pathWithFile)
        {
            if (File.Exists(pathWithFile))
            {
                try
                {
                    File.Delete(pathWithFile);
                }
                catch (DirectoryNotFoundException)
                {
                    throw new Exception("The specified path is invalid .");
                }
                catch (NotSupportedException)
                {
                    throw new Exception("The path is invalid.");
                }
                catch (PathTooLongException)
                {
                    throw new Exception("The specified path is too long.");
                }
                catch (UnauthorizedAccessException)
                {
                    throw new Exception("Not enough required permission to do that.");
                }
                catch (ArgumentException)
                {
                    throw new Exception("Invalid character provid for the path and/or filename.");
                }
                catch (IOException)
                {
                    throw new Exception("The operation failed or was interrupted.");
                }
            }
        }

        /// <summary>
        /// Creates a directory in the supplied path.
        /// </summary>
        /// <param name="path">The path to be created.</param>
        public static void Directory_CreatePath(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (DirectoryNotFoundException)
            {
                throw new Exception("The specified path is invalid .");
            }
            catch (NotSupportedException)
            {
                throw new Exception("The path is invalid.");
            }
            catch (PathTooLongException)
            {
                throw new Exception("The specified path is too long.");
            }
            catch (UnauthorizedAccessException)
            {
                throw new Exception("Not enough required permission to do that.");
            }
            catch (ArgumentException)
            {
                throw new Exception("Invalid character provid for the path and/or filename.");
            }
            catch (IOException)
            {
                throw new Exception("The operation failed or was interrupted.");
            }
        }
    }
}
