namespace BusinessApplication
{
    internal class WebServiceProxy : IWebServiceProxy
    {
        private string _webServiceAddress;

        public WebServiceProxy(string _webServiceAddress)
        {
            this._webServiceAddress = _webServiceAddress;
        }
    }
}