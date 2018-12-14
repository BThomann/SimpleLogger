using System;

namespace SimpleLogger.Logging
{
    internal static class FilterPredicates
    {
        public static bool ByLevelHigher(LogLevel logMessageLevel, LogLevel filterLevel)
        {
            return ((int)logMessageLevel >= (int)filterLevel);
        }

        public static bool ByLevelLower(LogLevel logMessageLevel, LogLevel filterLevel)
        {
            return ((int)logMessageLevel <= (int)filterLevel);
        }

        public static bool ByLevelExactly(LogLevel logMessageLevel, LogLevel filterLevel)
        {
            return ((int)logMessageLevel == (int)filterLevel);
        }

        public static bool ByLevel(LogMessage logMessage, LogLevel filterLevel, Func<LogLevel, LogLevel, bool> filterPred)
        {
            return filterPred(logMessage.Level, filterLevel);
        }
    }
}
