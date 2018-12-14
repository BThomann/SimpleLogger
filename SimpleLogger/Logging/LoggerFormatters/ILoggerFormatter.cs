namespace SimpleLogger.Logging
{
    /// <summary>
    /// Applies a Format to an <see cref="LogMessage"/>.
    /// </summary>
    public interface ILoggerFormatter
    {
        /// <summary>
        /// Appliest the Format to the given <see cref="LogMessage"/> and returns the string result
        /// </summary>
        /// <param name="logMessage"><see cref="LogMessage"/> to be formated</param>
        /// <returns>Formated string of the <see cref="LogMessage"/></returns>
        string ApplyFormat(LogMessage logMessage);
    }
}