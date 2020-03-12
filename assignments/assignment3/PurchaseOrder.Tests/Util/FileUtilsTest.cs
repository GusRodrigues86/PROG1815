using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using PurchaseOrder.Util;

namespace PurchaseOrder.Tests.Util
{
    class FileUtilsTest
    {
        private string pathToProject;
        string fileName;
        #region Before and After
        [SetUp]
        public void Init()
        {
            pathToProject = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            pathToProject = Directory.GetParent(pathToProject).FullName;
            pathToProject = Directory.GetParent(pathToProject).FullName;
            pathToProject = Directory.GetParent(pathToProject).FullName;

            fileName = pathToProject;
            ;

            // checks if there is any test file saved.
            if (File.Exists(pathToProject + @"/Util/TestText.txt"))
            {
                File.Delete(pathToProject + @"/Util/TestText.txt");
            }
        }

        [TearDown]
        public void Dispose()
        {
            if (File.Exists(pathToProject + @"/Util/TestText.txt"))
            {
                File.Delete(pathToProject + @"/Util/TestText.txt");
            }
        }
        #endregion
        #region Open file
        [Test]
        public void CantFindFileThrowsException()
        {
            Assert.Throws<FileNotFoundException>(
                () =>
                {
                    FileUtils.FileReader("file");
                });
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    FileUtils.FileReader(null);
                });
            Assert.Throws<DirectoryNotFoundException>(
                () =>
                {
                    FileUtils.FileReader(@"Z:\doesnt\exist.file");
                });
        }
        [Test]
        public void CanReadAnExistingCSVFile()
        {
            try
            {
                using (StreamReader file = FileUtils.FileReader(pathToProject + @"./Util/hello.csv"))
                {
                    string splited = file.ReadLine();
                    Assert.AreEqual("Hello,World", splited);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion
        #region File Creation
        [Test]
        public void CanCreatFileIfDoesntExist()
        {
            fileName += @"/Util/TestText.txt";
            Assert.IsTrue(FileUtils.CreateFile(fileName));
        }
        [Test]
        public void IfFileAlreadyExistisReturnsFalse()
        {
            fileName += @"/Util/hello.csv";
            Assert.IsFalse(FileUtils.CreateFile(fileName));
        }
        #endregion
        #region File Writing
        [Test]
        public void WriteAStringToDummyFile()
        {
            fileName += @"/Util/TestText.txt";
            try
            {
                FileUtils.CreateFile(fileName);
                bool write = FileUtils.AppendToFile<string>(fileName, "Test");
                Assert.IsTrue(write);

                using (StreamReader reader = FileUtils.FileReader(fileName))
                {
                    var line = reader.ReadLine();
                    Assert.AreEqual("Test", line);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.StackTrace);
            }

        }
        #endregion
    }
}
