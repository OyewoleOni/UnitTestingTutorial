using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProjectLibrary;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            StringHandling ObjString = new StringHandling();
            string rvalue = ObjString.concat("Oyewole", "Oni");

            Assert.AreEqual("OyewoleOni", rvalue);
        }

        [TestMethod]
        public void BooleanTestMethod()
        {
            //Arrange test
            TestClass objtest = new TestClass();
            Boolean result;

            //Act test
            result = objtest.testFunction();

            //Assert test
            Assert.AreEqual(true, result);
        }
    }
}
