using System;
using System.Collections.Generic;

namespace SimpleLogger.Logging
{
    /// <summary>
    /// 
    /// </summary>
    internal class LogPublisher : ILoggerHandlerManager
    {
        #region Fields

        private readonly IList<ILoggerHandler> _loggerHandlers;
        private readonly IList<LogMessage> _storedMessages; 

        #endregion

        #region Constructors

        public LogPublisher()
        {
            _loggerHandlers = new List<ILoggerHandler>();
            _storedMessages = new List<LogMessage>();
            StoreLogMessages = false;
        }

        public LogPublisher(bool storeLogMessages)
        {
            _loggerHandlers = new List<ILoggerHandler>();
            _storedMessages = new List<LogMessage>();
            StoreLogMessages = storeLogMessages;
        }

        #endregion


        /// <inheritdoc />

        #region Properties

        public IEnumerable<LogMessage> StoredMessages => _storedMessages;

        /// <inheritdoc />
        public bool StoreLogMessages { get; set; }

        #endregion
        
        #region Methods

        /// <inheritdoc />
        public void Publish(LogMessage logMessage)
        {
            if (StoreLogMessages)
                _storedMessages.Add(logMessage);
            foreach (var loggerHandler in _loggerHandlers)
                loggerHandler.Publish(logMessage);
        }

        /// <inheritdoc />
        public ILoggerHandlerManager RegisterHandler(ILoggerHandler loggerHandler)
        {
            if (loggerHandler != null)
                _loggerHandlers.Add(loggerHandler);
            return this;
        }

        /// <inheritdoc />
        public ILoggerHandlerManager RegisterHandler(ILoggerHandler loggerHandler, Predicate<LogMessage> filter)
        {
            if ((filter == null) || loggerHandler == null)
                return this;

            return RegisterHandler(new FilteredHandler() {
                Filter = filter,
                Handler = loggerHandler
            });
        }

        /// <inheritdoc />
        public bool UnRegisterHandler(ILoggerHandler loggerHandler) => _loggerHandlers.Remove(loggerHandler);

        #endregion
    }
}
