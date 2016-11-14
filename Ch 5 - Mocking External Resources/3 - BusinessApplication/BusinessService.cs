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
        /////////////////// 
        /// Before Ninject...
        ///////////////////
        
        //private readonly string _databaseConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //private readonly string _webServiceAddress = ConfigurationManager.AppSettings["MyWebServiceAddress"];
        //private readonly ILoggingDataSink _loggingDataSink;

        //private IDataAccessComponent _dataAccessComponent;
        //private IWebServiceProxy _webServiceProxy;
        //private ILoggingComponent _loggingComponent;

        //public BusinessService()
        //{
        //    _loggingDataSink = new LoggingDataSink();
        //    _loggingComponent = new LoggingComponent(_loggingDataSink);
        //    _webServiceProxy = new WebServiceProxy(_webServiceAddress);
        //    _dataAccessComponent = new DataAccessComponent(_databaseConnectionString);
        //}

        ///////////////////
        // After Ninject...
        ///////////////////
        private IDataAccessComponent _dataAccessComponent;
        private IWebServiceProxy _webServiceProxy;
        private ILoggingComponent _loggingComponent;

        public BusinessService(ILoggingComponent loggingComponent,
                                IWebServiceProxy webServiceProxy,
                                IDataAccessComponent dataAccessComponent)
        {
            _loggingComponent = loggingComponent;
            _webServiceProxy = webServiceProxy;
            _dataAccessComponent = dataAccessComponent;
        }
    }
}
