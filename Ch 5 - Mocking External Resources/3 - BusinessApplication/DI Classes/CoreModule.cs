using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject.Modules;

namespace BusinessApplication
{
    /// <summary>
    /// Ninject needs a class to store the rules it uses to create the concrete instances of your dependencies.
    /// </summary>
    public class CoreModule : NinjectModule
    {
        public override void Load()
        {
            // Optionally binding the concrete class to a class:
            Bind<BusinessService>().ToSelf();

            Bind<ILoggingDataSink>().To<LoggingDataSink>();

            // Note that LoggingComponent takes ILoggingDataSink as an initialization parameter.
            // Since this interface has been bound to Ninject, Ninject can automatically deal with this instantiation requirement.
            Bind<ILoggingComponent>().To<LoggingComponent>();

            // Use a Provider class to handle logic of parameters that cannot be tied to interfaces, such as strings.
            Bind<IDataAccessComponent>().ToProvider(new DataAccessComponentProvider());
            Bind<IWebServiceProxy>().ToProvider(new WebServiceProxyComponentProvider());

            // Adding the Person App Demo classes...
            Bind<IPersonRepository>().To<PersonRepository>();
            Bind<IPersonService>().To<PersonService>();
        }
    }
}
