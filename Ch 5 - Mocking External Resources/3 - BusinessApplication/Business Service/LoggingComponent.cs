namespace BusinessApplication
{
    internal class LoggingComponent : ILoggingComponent
    {
        private ILoggingDataSink _loggingDataSink;

        public LoggingComponent(ILoggingDataSink _loggingDataSink)
        {
            this._loggingDataSink = _loggingDataSink;
        }
    }
}