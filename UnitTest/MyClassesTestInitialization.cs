using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
     

    [TestClass]
    public class MyClassesTestInitialization
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext tc)
        {
            tc.WriteLine("In the Assembly Initialize Method.");
            //TODO: Create resources needed for your tests.
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            //TODO: CleanUp any resources used by your tests.
        }
    }
}
