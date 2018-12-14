using System;
using SimpleLogger.Logging;

namespace SimpleLogger.Logging
{
    /// <summary>
    /// Logs the <see cref="LogMessage"/> to the console.
    /// </summary>
    public class ConsoleLoggerHandler : ILoggerHandler
    {
        private readonly ILoggerFormatter _loggerFormatter;

        public ConsoleLoggerHandler() : this(new DefaultLoggerFormatter()) { }

        public ConsoleLoggerHandler(ILoggerFormatter loggerFormatter)
        {
            _loggerFormatter = loggerFormatter;
        }

        /// <inheritdoc />
        public void Publish(LogMessage logMessage)
        {
            Console.WriteLine(_loggerFormatter.ApplyFormat(logMessage));
        }
    }
}
