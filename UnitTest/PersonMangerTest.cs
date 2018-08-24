using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProjectLibrary.PersonsClass;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class PersonMangerTest
    {
        [TestMethod]
        public void CreatePerson_OfTypeEmployeeTest()
        {
            PersonManager mgr = new PersonManager();

            Person per;

            per = mgr.CreatePerson("Oni", "Sheriff", false);

            Assert.IsInstanceOfType(per, typeof(Employee));
        }

        [TestMethod]
        public void GetEmployeeTest()
        {
            PersonManager mgr = new PersonManager();

            List<Person> employees;

            employees = mgr.GetEmployees();

            CollectionAssert.AllItemsAreInstancesOfType(employees, typeof(Employee));
        }

        [TestMethod]
        public void IsCollectionOfTypeSupervisorsAndEmployeeTest()
        {
            PersonManager mgr = new PersonManager();

            List<Person> peopleActual = new List<Person>();


            peopleActual = mgr.GetSupervisorAndEmployees();

            CollectionAssert.AllItemsAreNotNull(peopleActual);
        }

        [TestMethod]
        public void DoEmployeeExistTest()
        {
            Supervisor super = new Supervisor();

            super.Employees = new List<Employee>();

            super.Employees.Add(new Employee()
            {
                FirstName= "Oyewole",
                LastName="Oni"
            });

            Assert.IsTrue(super.Employees.Count>0);
        }

    }
}
