using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessApplication
{

    /// <summary>
    /// Original Static Implementation.
    /// </summary>
    public class BusinessService
    {
        private readonly string _databaseConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        private readonly string _webServiceAddress = ConfigurationManager.AppSettings["MyWebServiceAddress"];
        private readonly LoggingDataSink _loggingDataSink;

        private DataAccessComponent _dataAccessComponent;
        private WebServiceProxy _webServiceProxy;
        private LoggingComponent _loggingComponent;

        public BusinessService()
        {
            _loggingDataSink = new LoggingDataSink();
            _loggingComponent = new LoggingComponent(_loggingDataSink);
            _webServiceProxy = new WebServiceProxy(_webServiceAddress);
            _dataAccessComponent = new DataAccessComponent(_databaseConnectionString);
        }
    }
}
