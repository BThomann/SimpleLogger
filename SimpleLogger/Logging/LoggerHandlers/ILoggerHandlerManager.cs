using System;
using System.Collections.Generic;

namespace SimpleLogger.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILoggerHandlerManager
    {
        #region Properties

        /// <summary>
        /// <see cref="IEnumerable{LogMessage}"/> of stored Messages.
        /// </summary>
        IEnumerable<LogMessage> StoredMessages { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ILoggerHandlerManager"/> store log messages.
        /// </summary>
        /// <value><c>true</c> if store log messages; otherwise, <c>false</c>. By default is <c>false</c></value>
        bool StoreLogMessages { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Registers an new <see cref="ILoggerHandler"/>
        /// </summary>
        /// <param name="loggerHandler">new <see cref="ILoggerHandler"/></param>
        /// <returns></returns>
        ILoggerHandlerManager RegisterHandler(ILoggerHandler loggerHandler);

        /// <summary>
        /// Registers an new <see cref="ILoggerHandler"/> with a given filter
        /// </summary>
        /// <param name="loggerHandler">new <see cref="ILoggerHandler"/></param>
        /// <param name="filter">filter for the <see cref="LogMessage"/></param>
        /// <returns></returns>
        ILoggerHandlerManager RegisterHandler(ILoggerHandler loggerHandler, Predicate<LogMessage> filter);

        /// <summary>
        /// Unregisters an new <see cref="ILoggerHandler"/>
        /// </summary>
        /// <param name="loggerHandler">new <see cref="ILoggerHandler"/></param>
        /// <returns>succsess</returns>
        bool UnRegisterHandler(ILoggerHandler loggerHandler);

        /// <summary>
        /// Publishes the <see cref="logMessage"/> to all registered <see cref="ILoggerHandler"/>.
        /// </summary>
        /// <param name="logMessage"><see cref="LogMessage"/> to be logged</param>
        void Publish(LogMessage logMessage);

        #endregion
    }
}
