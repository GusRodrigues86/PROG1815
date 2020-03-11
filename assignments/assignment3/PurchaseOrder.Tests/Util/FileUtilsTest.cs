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
        #region Before and After
        [SetUp]
        public void Init()
        {
            pathToProject = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            pathToProject = Directory.GetParent(pathToProject).FullName;
            pathToProject = Directory.GetParent(pathToProject).FullName;
            pathToProject = Directory.GetParent(pathToProject).FullName;
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

        [Test]
        public void CantFindFileThrowsException()
        {
            Assert.Throws<FileNotFoundException>(
                () =>
                {
                    FileUtils.CSVReader("file");
                });
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    FileUtils.CSVReader(null);
                });
            Assert.Throws<DirectoryNotFoundException>(
                () =>
                {
                    FileUtils.CSVReader(@"Z:\doesnt\exist.file");
                });
        }
        [Test]
        public void CanReadAnExistingCSVFile()
        {
            try
            {
                using (StreamReader file = FileUtils.CSVReader(pathToProject + @"./Util/hello.csv"))
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
        [Test]
        public void CanCreatFileIfDoesntExist()
        {
            string fileName = pathToProject + @"/Util/TestText.txt";
            Assert.IsTrue(FileUtils.CreateFile(fileName));
        }
        [Test]
        public void IfFileAlreadyExistisReturnsFalse()
        {
            string fileName = pathToProject + @"/Util/hello.csv";
            Assert.IsFalse(FileUtils.CreateFile(fileName));
        }
    }
}
