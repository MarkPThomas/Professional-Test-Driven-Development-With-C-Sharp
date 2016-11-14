namespace BusinessApplication
{
    internal class LoggingComponent
    {
        private LoggingDataSink _loggingDataSink;

        public LoggingComponent(LoggingDataSink _loggingDataSink)
        {
            this._loggingDataSink = _loggingDataSink;
        }
    }
}