using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProjectLibrary;
using System.Configuration;
using System.IO;

namespace UnitTest
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:BadFileName.bad";
        private string _GoodFileName;

        public TestContext TestContext { get; set; }

        private void SetGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];

            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        [TestMethod]
        public void FileNameDoesExist()
        {
            FileProcess fp = new FileProcess();

            bool fromCall;

            SetGoodFileName();
            TestContext.WriteLine("Creating the file: " + _GoodFileName);
            File.AppendAllText(_GoodFileName, "Some Text");
            TestContext.WriteLine("Testing the file: " + _GoodFileName);

            fromCall = fp.FileExist(_GoodFileName);
            File.Delete(_GoodFileName);
            TestContext.WriteLine("Deleting the file: " + _GoodFileName);
            Assert.IsTrue(fromCall);


        }
        [TestMethod]
        public void FileNameDoesNotExist()
        {
            FileProcess fp = new FileProcess();

            bool fromCall;

            fromCall = fp.FileExist(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullorEmpty_ThrowsArgumentNullException()
        {
            FileProcess fp = new FileProcess();

            fp.FileExist("");
        }

        [TestMethod]
       
        public void FileNameNullorEmpty_ThrowsArgumentNullException_UsingTryCatch()
        {
            FileProcess fp = new FileProcess();

            try
            {
                fp.FileExist("");
            }
            catch (ArgumentNullException)
            {
                return;
            }
            Assert.Fail("Call to FileExistts did not throw an ArgumentNullException");
        }
    }
}
