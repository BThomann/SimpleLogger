using System;
using System.IO;
using SimpleLogger.Logging;

namespace SimpleLogger.Logging
{
    /// <summary>
    /// Logs the <see cref="LogMessage"/> to a file.
    /// </summary>
    public class FileLoggerHandler : ILoggerHandler
    {
        private static readonly string _logFilePrefix = "Log";

        private readonly string _fileName;
        private readonly string _directory;
        private readonly ILoggerFormatter _loggerFormatter;

        /// <summary>
        /// Default <see cref="FileLoggerHandler"/>
        /// </summary>
        public FileLoggerHandler() : this(CreateFileName()) { }

        /// <summary>
        /// Logs to the file <see cref="fileName"/>
        /// </summary>
        /// <param name="fileName">name of the file to be logged to</param>
        public FileLoggerHandler(string fileName) : this(fileName, string.Empty) { }

        /// <summary>
        /// Logs to the file <see cref="fileName"/> in the <see cref="directory"/>
        /// </summary>
        /// <param name="fileName">name of the file to be logged to</param>
        /// <param name="directory">directory in which the file is</param>
        public FileLoggerHandler(string fileName, string directory) : this(fileName, directory, new DefaultLoggerFormatter()) { }

        /// <summary>
        /// Logs to the default file with the <see cref="ILoggerFormatter"/>
        /// </summary>
        /// <param name="loggerFormatter"><see cref="ILoggerFormatter"/> to be used for logging</param>
        public FileLoggerHandler(ILoggerFormatter loggerFormatter) : this(CreateFileName(), loggerFormatter) { }

        /// <summary>
        /// Logs to the file file <see cref="fileName"/> with the <see cref="ILoggerFormatter"/>
        /// </summary>
        /// <param name="fileName">name of the file to be logged to</param>
        /// <param name="loggerFormatter"><see cref="ILoggerFormatter"/> to be used for logging</param>
        public FileLoggerHandler(string fileName, ILoggerFormatter loggerFormatter) : this(fileName, string.Empty, loggerFormatter) { }

        /// <summary>
        /// Logs to the file <see cref="fileName"/> in the <see cref="directory"/> with the <see cref="ILoggerFormatter"/>
        /// </summary>
        /// <param name="fileName">name of the file to be logged to</param>
        /// <param name="directory">directory in which the file is</param>
        /// /// <param name="loggerFormatter"><see cref="ILoggerFormatter"/> to be used for logging</param>
        public FileLoggerHandler(string fileName, string directory, ILoggerFormatter loggerFormatter)
        {
            _loggerFormatter = loggerFormatter;
            _fileName = fileName;
            _directory = directory;
        }

        /// <inheritdoc />
        public void Publish(LogMessage logMessage)
        {
            if (!string.IsNullOrEmpty(_directory))
            {
                var directoryInfo = new DirectoryInfo(Path.Combine(_directory));
                if (!directoryInfo.Exists)
                    directoryInfo.Create();
            }

            using (var writer = new StreamWriter(File.Open(Path.Combine(_directory, _fileName), FileMode.Append)))
                writer.WriteLine(_loggerFormatter.ApplyFormat(logMessage));
        }

        /// <summary>
        /// creates a new file name for the log file
        /// </summary>
        /// <returns>file name for the new logfile</returns>
        public static string CreateFileName()
        {
            var currentDate = DateTime.Now;
            var guid = Guid.NewGuid();
            return string.Format(_logFilePrefix + "_{0:00}{1:00}{2:00}-{3:00}{4:00}_{5}.log",
                currentDate.Day, currentDate.Month, currentDate.Year, currentDate.Hour, currentDate.Minute, guid);
        }
    }
}
