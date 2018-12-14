using System;

namespace SimpleLogger.Logging
{
    /// <summary>
    /// Used to filter <see cref="LogMessage"/> before publishing.
    /// </summary>
    internal class FilteredHandler : ILoggerHandler
    {
        #region Methods

        /// <summary>
        /// The filter to be checked before publishing
        /// </summary>
        public Predicate<LogMessage> Filter { get; set; }

        /// <summary>
        /// The <see cref="ILoggerHandler"/> to be used when the <see cref="Filter"/> is <c>true</c>
        /// </summary>
        public ILoggerHandler Handler { get; set; }

        #endregion

        #region Methods

        /// <inheritdoc />
        public void Publish(LogMessage logMessage) 
        {
            if (Filter(logMessage))
                Handler.Publish (logMessage);
        }

        #endregion
    }
}