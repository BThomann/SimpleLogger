using System;

namespace SimpleLogger.Logging
{
    /// <summary>
    /// Represents a LogMessage
    /// </summary>
    public class LogMessage
    {
        public DateTime DateTime { get; set; }
        public LogLevel Level { get; set; }
        public string Text { get; set; }
        public string CallingClass { get; set; }
        public string CallingMethod { get; set; }
        public int LineNumber { get; set; }

        public LogMessage() { }

        public LogMessage(string text, LogLevel level, DateTime dateTime, string callingClass, string callingMethod, int lineNumber)
        {
            Level = level;
            Text = text;
            DateTime = dateTime;
            CallingClass = callingClass;
            CallingMethod = callingMethod;
            LineNumber = lineNumber;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return new DefaultLoggerFormatter().ApplyFormat(this);
        }
    }
}
