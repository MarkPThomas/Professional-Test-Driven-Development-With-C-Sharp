using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject.Activation;

namespace BusinessApplication
{
    public class WebServiceProxyComponentProvider : Provider<IWebServiceProxy>
    {
        protected override IWebServiceProxy CreateInstance(IContext context)
        {
            var webServiceAddress = ConfigurationManager.AppSettings["MyWebServiceAddress"];
            return new WebServiceProxy(webServiceAddress);
        }
    }
}
