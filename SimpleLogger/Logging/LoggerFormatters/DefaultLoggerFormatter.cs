namespace SimpleLogger.Logging
{
    /// <summary>
    /// Default Logger Formater
    /// </summary>
    internal class DefaultLoggerFormatter : ILoggerFormatter
    {
        /// <inheritdoc />
        public string ApplyFormat(LogMessage logMessage)
        {
            return
                $"{logMessage.DateTime:dd.MM.yy HH:mm:ss}: {logMessage.Level} " + 
                $"[line: {logMessage.LineNumber} {logMessage.CallingClass} -> {logMessage.CallingMethod}()]: {logMessage.Text}";
        }
    }
}