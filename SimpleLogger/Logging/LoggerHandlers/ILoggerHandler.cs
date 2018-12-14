namespace SimpleLogger.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILoggerHandler
    {
        /// <summary>
        /// Publishes the <see cref="logMessage"/> to all registered <see cref="ILoggerHandler"/>.
        /// </summary>
        /// <param name="logMessage"><see cref="LogMessage"/> to be logged</param>
        void Publish(LogMessage logMessage);
    }
}