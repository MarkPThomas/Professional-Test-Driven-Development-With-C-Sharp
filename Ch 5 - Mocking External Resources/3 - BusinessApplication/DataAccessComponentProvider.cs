using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject.Activation;

namespace BusinessApplication
{
    /// <summary>
    /// To handle instantiation logic that is more complicated than simply mapping an interface to a class,
    /// Ninject lets you create providers for specific interfaces.
    /// A provider is simply a class that allows you to abstract complex creational logic from the code in your module.
    /// </summary>
    public class DataAccessComponentProvider : Provider<IDataAccessComponent>
    {
        protected override IDataAccessComponent CreateInstance(IContext context)
        {
            var databaseConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            return new DataAccessComponent(databaseConnectionString);
        }
    }
}
