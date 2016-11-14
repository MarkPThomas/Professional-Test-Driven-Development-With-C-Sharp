using System.Configuration;

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
