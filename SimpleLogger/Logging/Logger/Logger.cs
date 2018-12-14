using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace SimpleLogger.Logging
{
    /// <inheritdoc />
    public class Logger : ILogger
    {

        #region Fields

        private readonly LogPublisher LogPublisher;

        private bool _isTurned = true;
        private bool _isTurnedDebug = true;

        #endregion

        #region Constructors

        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static Logger()
        { }

        /// <summary>
        /// Private default Constructor
        /// </summary>
        private Logger()
        {
            LogPublisher = new LogPublisher();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Singelton getter.
        /// </summary>
        public static Logger Instance { get; } = new Logger();

        /// <inheritdoc />
        public LogLevel DefaultLogLevel { get; set; } = LogLevel.Info;

        /// <inheritdoc />
        public ILoggerHandlerManager LoggerHandlerManager => LogPublisher;
        
        /// <inheritdoc />
        public IEnumerable<LogMessage> StoredMessages => LogPublisher.StoredMessages;
        
        /// <inheritdoc />
        public bool StoreLogMessages
        {
            get => LogPublisher.StoreLogMessages;
            set => LogPublisher.StoreLogMessages = value;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public void DefaultInitialization()
        {
            LoggerHandlerManager
                .RegisterHandler(new ConsoleLoggerHandler())
                .RegisterHandler(new FileLoggerHandler());

            Log("Logger - Default initialization", LogLevel.Info);
        }


        /// <inheritdoc />
        public void On() => _isTurned = true;

        /// <inheritdoc />
        public void Off() => _isTurned = false;

        /// <inheritdoc />
        public void DebugOn() => _isTurnedDebug = true;

        /// <inheritdoc />
        public void DebugOff() => _isTurnedDebug = false;

        /// <inheritdoc />
        public void Trace(string message, [CallerFilePath] string callingClass = "",
            [CallerMemberName] string callingMethod = "", [CallerLineNumber] int lineNumber = 0)
        {
            Log(message, LogLevel.Trace, callingClass, callingMethod, lineNumber);
        }

        /// <inheritdoc />
        public void Debug(string message, [CallerFilePath] string callingClass = "",
            [CallerMemberName] string callingMethod = "", [CallerLineNumber] int lineNumber = 0)
        {
            Log(message, LogLevel.Debug, callingClass, callingMethod, lineNumber);
        }

        /// <inheritdoc />
        public void Info(string message, [CallerFilePath] string callingClass = "",
            [CallerMemberName] string callingMethod = "", [CallerLineNumber] int lineNumber = 0)
        {
            Log(message, LogLevel.Info, callingClass, callingMethod, lineNumber);
        }

        /// <inheritdoc />
        public void Warning(string message, [CallerFilePath] string callingClass = "",
            [CallerMemberName] string callingMethod = "", [CallerLineNumber] int lineNumber = 0)
        {
            Log(message, LogLevel.Warning, callingClass, callingMethod, lineNumber);
        }

        /// <inheritdoc />
        public void Error(string message, [CallerFilePath] string callingClass = "",
            [CallerMemberName] string callingMethod = "", [CallerLineNumber] int lineNumber = 0)
        {
            Log(message, LogLevel.Error, callingClass, callingMethod, lineNumber);
        }

        /// <inheritdoc />
        public void Fatal(string message, [CallerFilePath] string callingClass = "",
            [CallerMemberName] string callingMethod = "", [CallerLineNumber] int lineNumber = 0)
        {
            Log(message, LogLevel.Fatal, callingClass, callingMethod, lineNumber);
        }

        /// <inheritdoc />
        public void Log(string message, [CallerFilePath] string callingClass = "",
            [CallerMemberName] string callingMethod = "", [CallerLineNumber] int lineNumber = 0)
        {
            Log(message, DefaultLogLevel, callingClass, callingMethod, lineNumber);
        }

        /// <inheritdoc />
        public void Log(Exception exception, [CallerFilePath] string callingClass = "",
            [CallerMemberName] string callingMethod = "", [CallerLineNumber] int lineNumber = 0)
        {
            Log(exception.Message, LogLevel.Error, callingClass, callingMethod, lineNumber);
        }

        /// <inheritdoc />
        public void Log(string message, LogLevel level, [CallerFilePath] string callingClass = "",
            [CallerMemberName] string callingMethod = "", [CallerLineNumber] int lineNumber = 0)
        {
            if (!_isTurned || (!_isTurnedDebug && level == LogLevel.Debug))
                return;

            var currentDateTime = DateTime.Now;
            callingClass = Path.GetFileNameWithoutExtension(callingClass);

            var logMessage = new LogMessage(message, level, currentDateTime, callingClass, callingMethod, lineNumber);
            LogPublisher.Publish(logMessage);
        }

        #endregion

    }
}
