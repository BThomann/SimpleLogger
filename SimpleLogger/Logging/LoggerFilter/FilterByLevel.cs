using System;

namespace SimpleLogger.Logging
{
    public class FilterByLevel
    {
        public LogLevel FilteredLevel { get; set; }
        public bool ExactlyLevel { get; set; }
        public bool OnlyHigherLevel { get; set; }

        public FilterByLevel(LogLevel level)
        {
            FilteredLevel = level;
            ExactlyLevel = true;
            OnlyHigherLevel = true;
        }

        public FilterByLevel()
        {
            ExactlyLevel = false;
            OnlyHigherLevel = true;
        }

        public Predicate<LogMessage> Filter
        {
            get
            {
                return delegate (LogMessage logMessage)
                {
                    return FilterPredicates.ByLevel(logMessage, FilteredLevel, (logMessageLevel, filterLevel) =>
                             ExactlyLevel ? FilterPredicates.ByLevelExactly(logMessageLevel, filterLevel)
                                          : OnlyHigherLevel ? FilterPredicates.ByLevelHigher(logMessageLevel, filterLevel)
                                                            : FilterPredicates.ByLevelLower(logMessageLevel, filterLevel));
                };
            }
        }
    }
}
