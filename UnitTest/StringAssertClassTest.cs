using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
   public  class StringAssertClassTest
    {
        [TestMethod]
        public void ContainsTest()
        {
            string str1 = "Oyewole Oni";
            string str2 = "Oni";

            StringAssert.Contains(str1, str2);
        }

        [TestMethod]
        public void StartWithTest()
        {
            string str1 = "All Lower Case";
            string str2 = "All Lower";

            StringAssert.StartsWith(str1, str2);
        }

        [TestMethod]
        public void IsAllLowerCaseTest()
        {
            Regex reg = new Regex(@"^([^A-Z])+$");

            StringAssert.Matches("all lower case", reg);
        }

        [TestMethod]
        public void IsNotAllLowerCaseTest()
        {
            Regex reg = new Regex(@"^([^A-Z])+$");

            StringAssert.DoesNotMatch("All lower case", reg);
        }
    }
}
