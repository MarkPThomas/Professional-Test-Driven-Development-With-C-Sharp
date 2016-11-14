using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessApplication
{
    public interface IPersonService
    {
        Person GetPerson(int personID);
    }
}
