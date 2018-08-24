using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectLibrary.PersonsClass
{
   public  class PersonManager
    {
        public Person CreatePerson(string first, string last, bool isSupervisor)
        {
            Person ret = null;

            if (!string.IsNullOrEmpty(first))
            {
                if (isSupervisor)
                {
                    ret = new Supervisor();
                }
                else
                {
                    ret = new Employee();

                }

                ret.FirstName = first;
                ret.LastName = last;
            }
            return ret;
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person { FirstName = "Oyewole", LastName = "Oni" });
            people.Add(new Person { FirstName = "Ayokunle", LastName = "Oni" });
            people.Add(new Person { FirstName = "Darelo", LastName = "Oni" });

            return people;
        }

        public List<Person> GetSupervisorAndEmployees()
        {
            throw new NotImplementedException();
        }

        public List<Person> GetSupervisors()
        {
            List<Person> people = new List<Person>();

            people.Add(CreatePerson("Oni","Oyewole", true));
            people.Add(CreatePerson("Oni", "Ayokunle", true));
           

            return people;
        }

        public List<Person> GetEmployees()
        {
            List<Person> people = new List<Person>();

            people.Add(CreatePerson("Oni", "Oyewole", false));
            people.Add(CreatePerson("Oni", "Ayokunle", false));


            return people;
        }


    }
}
