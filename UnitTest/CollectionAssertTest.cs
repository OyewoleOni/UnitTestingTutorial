using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProjectLibrary.PersonsClass;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class CollectionAssertTest
    {
        [TestMethod]
        public void AreCollectionEqualsFailsBecauseNoComparerTest()
        {
            PersonManager mgr = new PersonManager();

            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person { FirstName = "Oyewole", LastName = "Oni" });
            peopleExpected.Add(new Person { FirstName = "Ayokunle", LastName = "Oni" });
            peopleExpected.Add(new Person { FirstName = "Darelo", LastName = "Oni" });

            peopleActual = mgr.GetPeople();

            CollectionAssert.AreEqual(peopleExpected, peopleActual);
        }

        [TestMethod]
        public void AreCollectionEqualsFailsWithComparerTest()
        {
            PersonManager mgr = new PersonManager();

            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person { FirstName = "Oyewole", LastName = "Oni" });
            peopleExpected.Add(new Person { FirstName = "Ayokunle", LastName = "Oni" });
            peopleExpected.Add(new Person { FirstName = "Darelo", LastName = "Oni" });

            peopleActual = mgr.GetPeople();

            CollectionAssert.AreEqual(peopleExpected, peopleActual,
                Comparer<Person>.Create((x,y)=>
                    x.FirstName==y.FirstName && x.LastName==y.LastName ? 0:1));
        }

        [TestMethod]
        public void AreCollectionEqualTest()
        {
            PersonManager mgr = new PersonManager();

            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

           
            peopleActual = mgr.GetPeople();
            peopleExpected = peopleActual;

            CollectionAssert.AreEqual(peopleExpected, peopleActual);
               
        }

        [TestMethod]
        public void AreCollectionAreEquivalentTest()
        {
            PersonManager mgr = new PersonManager();

            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();


            peopleActual = mgr.GetPeople();
            peopleExpected.Add(peopleActual[1]);
            peopleExpected.Add(peopleActual[2]);
            peopleExpected.Add(peopleActual[0]);

            //Check for same object but in any order
            CollectionAssert.AreEquivalent(peopleExpected, peopleActual);

        }

        //[TestMethod]
        //public void IsCollectionOfTypeTest()
        //{
        //    PersonManager mgr = new PersonManager();

            
        //    List<Person> peopleActual = new List<Person>();

        //    peopleActual = mgr.GetSupervisor();

        //    //Check for same object but in any order
        //    CollectionAssert.AllItemsAreInstancesOfType(peopleActual, typeof(Supervisor));

        //}
    }
}
