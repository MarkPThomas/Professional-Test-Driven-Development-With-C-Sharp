namespace BusinessApplication
{
    internal class DataAccessComponent
    {
        private string _databaseConnectionString;

        public DataAccessComponent(string _databaseConnectionString)
        {
            this._databaseConnectionString = _databaseConnectionString;
        }
    }
}