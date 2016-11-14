using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessApplication
{
    public interface IPersonRepository
    {
        Person GetPerson(int personID);
    }
}
