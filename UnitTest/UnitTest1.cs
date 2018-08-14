using System;
using System.Collections.Generic;
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

        [TestMethod]
        public void CollectionssMethod()
        {
            List<string> first = new List<string>();
            first.Add("a");

            List<string> second = new List<string>();
            second.Add("a");

            CollectionAssert.AreEqual(first, second);
        }

        [TestMethod]
        public void AllItemsAreUniqueMethod()
        {
            List<string> first = new List<string>();
            first.Add("a");
            first.Add("b");
            first.Add("c");
            CollectionAssert.AllItemsAreUnique(first);
        }

        [TestMethod]
        public void CollectionContainsMethod()
        {
            List<string> first = new List<string>();
            first.Add("a");
            first.Add("b");
            first.Add("c");
            CollectionAssert.Contains(first, "a");
        }

        [TestMethod]
        public void ReferenceEquals()
        {
            List<string> str1 = new List<string>();
            List<string> str2 = new List<string>();
            CollectionAssert.ReferenceEquals(str1, str2);
        }

        [TestMethod]
        public void AllItemsAreNotNull()
        {
            List<string> str1 = new List<string>();
            str1.Add("");
            str1.Add("a");
            str1.Add("b");
            CollectionAssert.AllItemsAreNotNull(str1);
        }

        [TestMethod]
        public void AllItemsAreInstanceOfType()
        {
            List<string> str1 = new List<string>();
            CollectionAssert.AllItemsAreInstancesOfType(str1, typeof(string));
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void CheckingDivideByZero()
        {
            MathClass objMath = new MathClass();

            var result = objMath.Divide(10, 0);

            Assert.AreEqual(10, result);
        }
    }
}
