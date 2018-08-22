using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProjectLibrary;

namespace UnitTest
{
   
    [TestClass]
    public class AssertClassTest
    {
        #region AreEqual/AreNotEqual Tests
        [TestMethod]
        public void AreEqualTest()
        {
            string str1 = "Paul";
            string str2 = "Paul";

            Assert.AreEqual(str1, str2);
        }

        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void AreEqualCaseSensitiveTest()
        {
            string str1 = "Paul";
            string str2 = "paul";

            Assert.AreEqual(str1, str2,false);
        }

        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void AreNotEqualTest()
        {
            string str1 = "Oyewole";
            string str2 = "Oni";

            Assert.AreNotEqual(str1, str2);
        }
        #endregion
        #region AreSame/AreNotSame Test

        [TestMethod]
        public void AreSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = x;

            Assert.AreSame(x, y);
        }

        [TestMethod]  
        public void AreNotSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();

            Assert.AreNotSame(x, y);
        }
        #endregion

        #region InstanceOfTypeTest

        #endregion
    }
}
