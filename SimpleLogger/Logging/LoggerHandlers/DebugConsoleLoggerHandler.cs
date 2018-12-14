using SimpleLogger.Logging;

namespace SimpleLogger.Logging
{
    /// <summary>
    /// Logs the <see cref="LogMessage"/> to the Debug-Console.
    /// </summary>
    public class DebugConsoleLoggerHandler : ILoggerHandler
    {
        private readonly ILoggerFormatter _loggerFormatter;

        public DebugConsoleLoggerHandler() : this(new DefaultLoggerFormatter()) { }

        public DebugConsoleLoggerHandler(ILoggerFormatter loggerFormatter)
        {
            _loggerFormatter = loggerFormatter;
        }

        /// <inheritdoc />
        public void Publish(LogMessage logMessage)
        {
            System.Diagnostics.Debug.WriteLine(_loggerFormatter.ApplyFormat(logMessage));
        }
    }
}
