using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SimpleLogger.Logging
{
    /// <summary>
    /// Logs string messages and <see cref="LogLevel"/> to a List of <see cref="ILoggerHandler"/> via an <see cref="ILoggerHandlerManager"/>.
    /// </summary>
    public interface ILogger
    {
        #region Properties

        /// <summary>
        /// Gets and sets the Default <see cref="LogLevel"/>, which is used when no <see cref="LogLevel"/> is given when logging.
        /// </summary>
        LogLevel DefaultLogLevel { get; set; }

        /// <summary>
        /// Handles a list of <see cref="ILoggerHandler"/>, add <see cref="ILoggerHandler"/> here.
        /// </summary>
        ILoggerHandlerManager LoggerHandlerManager { get; }

        /// <summary>
        /// <see cref="IEnumerable{LogMessage}"/> of stored Messages.
        /// </summary>
        IEnumerable<LogMessage> StoredMessages { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="ILoggerHandlerManager"/> stores log messages.
        /// </summary>
        /// <value><c>true</c> if store log messages; otherwise, <c>false</c>. By default is <c>false</c></value>
        bool StoreLogMessages { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Default initialization my just be called once.
        /// </summary>
        void DefaultInitialization();

        /// <summary>
        /// Turns the <see cref="LogLevel.Debug"/> ON.
        /// </summary>
        void DebugOn();

        /// <summary>
        /// Turns the <see cref="LogLevel.Debug"/> OFF.
        /// </summary>
        void DebugOff();
        
        /// <summary>
        /// Turns the ILogger ON
        /// </summary>
        void On();

        /// <summary>
        /// Turns the ILogger ON
        /// </summary>
        void Off();

        /// <summary>
        /// Logs the <see cref="message"/> on <see cref="LogLevel.Trace"/>
        /// </summary>
        /// <param name="message">log message</param>
        /// <param name="callingClass">name of the calling class</param>
        /// <param name="callingMethod">name of the calling method</param>
        /// <param name="lineNumber">line number in the calling file</param>
        void Trace(string message, [CallerFilePath] string callingClass = "",
            [CallerMemberName] string callingMethod = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs the <see cref="message"/> on <see cref="LogLevel.Debug"/>
        /// </summary>
        /// <param name="message">log message</param>
        /// <param name="callingClass">name of the calling class</param>
        /// <param name="callingMethod">name of the calling method</param>
        /// <param name="lineNumber">line number in the calling file</param>
        void Debug(string message, [CallerFilePath] string callingClass = "",
            [CallerMemberName] string callingMethod = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs the <see cref="message"/> on <see cref="LogLevel.Info"/>
        /// </summary>
        /// <param name="message">log message</param>
        /// <param name="callingClass">name of the calling class</param>
        /// <param name="callingMethod">name of the calling method</param>
        /// <param name="lineNumber">line number in the calling file</param>
        void Info(string message, [CallerFilePath] string callingClass = "",
            [CallerMemberName] string callingMethod = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs the <see cref="message"/> on <see cref="LogLevel.Warning"/>
        /// </summary>
        /// <param name="message">log message</param>
        /// <param name="callingClass">name of the calling class</param>
        /// <param name="callingMethod">name of the calling method</param>
        /// <param name="lineNumber">line number in the calling file</param>
        void Warning(string message, [CallerFilePath] string callingClass = "",
            [CallerMemberName] string callingMethod = "", [CallerLineNumber] int lineNumber = 0);
        
        /// <summary>
        /// Logs the <see cref="message"/> on <see cref="LogLevel.Error"/>
        /// </summary>
        /// <param name="message">log message</param>
        /// <param name="callingClass">name of the calling class</param>
        /// <param name="callingMethod">name of the calling method</param>
        /// <param name="lineNumber">line number in the calling file</param>
        void Error(string message, [CallerFilePath] string callingClass = "",
            [CallerMemberName] string callingMethod = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs the <see cref="message"/> on <see cref="LogLevel.Fatal"/>
        /// </summary>
        /// <param name="message">log message</param>
        /// <param name="callingClass">name of the calling class</param>
        /// <param name="callingMethod">name of the calling method</param>
        /// <param name="lineNumber">line number in the calling file</param>
        void Fatal(string message, [CallerFilePath] string callingClass = "",
            [CallerMemberName] string callingMethod = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs the <see cref="message"/> on <see cref="DefaultLogLevel"/>
        /// </summary>
        /// <param name="message">log message</param>
        /// <param name="callingClass">name of the calling class</param>
        /// <param name="callingMethod">name of the calling method</param>
        /// <param name="lineNumber">line number in the calling file</param>
        void Log(string message, [CallerFilePath] string callingClass = "",
            [CallerMemberName] string callingMethod = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs the <see cref="exception.Message"/> on <see cref="LogLevel.Error"/>
        /// </summary>
        /// <param name="exception">exception to be logged</param>
        /// <param name="callingClass">name of the calling class</param>
        /// <param name="callingMethod">name of the calling method</param>
        /// <param name="lineNumber">line number in the calling file</param>
        void Log(Exception exception, [CallerFilePath] string callingClass = "",
            [CallerMemberName] string callingMethod = "", [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs the <see cref="message"/> on <see cref="level"/>
        /// </summary>
        /// <param name="message">log message</param>
        /// <param name="level"><see cref="LogLevel"/> of the log message</param>
        /// <param name="callingClass">name of the calling class</param>
        /// <param name="callingMethod">name of the calling method</param>
        /// <param name="lineNumber">line number in the calling file</param>
        void Log(string message, LogLevel level, [CallerFilePath] string callingClass = "",
            [CallerMemberName] string callingMethod = "", [CallerLineNumber] int lineNumber = 0);

        #endregion
        
    }
}