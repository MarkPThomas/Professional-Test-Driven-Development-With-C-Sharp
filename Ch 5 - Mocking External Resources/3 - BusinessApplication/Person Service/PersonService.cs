using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessApplication
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person GetPerson(int personID)
        {
            return _personRepository.GetPerson(personID);
        }
    }
}
