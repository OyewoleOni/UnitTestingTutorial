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

        #region Class Initialize and Cleanup
        [ClassInitialize]
        public static void ClassInitialize(TestContext tc)
        {
            tc.WriteLine("In the class Initialize");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
           
        }
        #endregion

        #region Test Initialization and Cleanup
        [TestInitialize]
        public void TestInitalize()
        {
            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                SetGoodFileName();

                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine("Creating File: " + _GoodFileName);
                    File.AppendAllText(_GoodFileName, "Some Text");
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine("Deleting File: " + _GoodFileName);
                    File.Delete(_GoodFileName);
                }
            }
        }

        #endregion

        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("System.Data.SqlClient",
            "Server=Localhost;Database=Sandbox;Integrated Security=Yes",
            "tests.FileProcessTest",
            DataAccessMethod.Sequential)]
        public void FileExistTestFromDB()
        {
            FileProcess fp = new FileProcess();

            string fileName;
            bool expectedValue;
            bool causesException;
            bool fromCall;

            //Get values from data row

            fileName = TestContext.DataRow["FileName"].ToString();
            expectedValue = Convert.ToBoolean(TestContext.DataRow["ExpectedValue"]);
            causesException = Convert.ToBoolean(TestContext.DataRow["CausesException"]);

            try
            {
                fromCall = fp.FileExist(fileName);
                Assert.AreEqual(expectedValue, fromCall, "File Name: " + fileName + " has failed it's existence test in test: FileExistsTestFromDB()");
            }
            catch (AssertFailedException ex)
            {

                throw ex;
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.IsTrue(causesException);
            }
        }

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
        [Timeout(3000)]
        public void SimulateTime()
        {
            System.Threading.Thread.Sleep(4000);
        }

        [TestMethod]
        public void FileNameDoesExistSimpleMessage()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExist(_GoodFileName);

            Assert.IsFalse(fromCall, "File Does not Exist.");
        }

        [TestMethod]
        [Description("Check to see if a file do exist.")]
        [Owner("OyewoleOni")]
        [Priority(0)]
        //[Ignore()]
        public void FileNameDoesExist()
        {
            FileProcess fp = new FileProcess();

            bool fromCall;

           

            //TestContext.WriteLine("Creating the file: " + _GoodFileName);
            TestContext.WriteLine("Testing the file: " + _GoodFileName);

            fromCall = fp.FileExist(_GoodFileName);

            //File.Delete(_GoodFileName);
            //TestContext.WriteLine("Deleting the file: " + _GoodFileName);

            Assert.IsTrue(fromCall);


        }
        [TestMethod]
        [Description("Check to see if a file does not exist.")]
        [Owner("OyewoleOni")]
        [Priority(0)]
        public void FileNameDoesNotExist()
        {
            FileProcess fp = new FileProcess();

            bool fromCall;

            fromCall = fp.FileExist(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Priority(1)]
        public void FileNameNullorEmpty_ThrowsArgumentNullException()
        {
            FileProcess fp = new FileProcess();

            fp.FileExist("");
        }

        [TestMethod]
        [Priority(1)]
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
