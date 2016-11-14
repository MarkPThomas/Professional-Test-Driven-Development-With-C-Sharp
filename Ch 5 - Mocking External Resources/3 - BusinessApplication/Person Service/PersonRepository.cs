using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessApplication
{
    /// <summary>
    /// This class is acting as the Database/Data Store layer.
    /// </summary>
    public class PersonRepository : IPersonRepository
    {
        private readonly IList<Person> _personList;
        public Person GetPerson(int personID)
        {
            return _personList.Where(person => person.Id == personID).FirstOrDefault();
        }

        public PersonRepository()
        {
            _personList = new List<Person>
                            {
                                new Person {Id = 1, FirstName = "John", LastName = "Doe" },
                                new Person {Id = 2, FirstName = "Richard", LastName = "Roe" },
                                new Person {Id = 3, FirstName = "Amy", LastName = "Adams" },
                            };
        }
    }
}
