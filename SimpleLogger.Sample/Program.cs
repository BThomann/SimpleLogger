using System;
using SimpleLogger.Logging;

namespace SimpleLogger.Sample
{
    class Program
    {
        public static void Main()
        {
            // Adding handler - to show log messages (ILoggerHandler)
            ILogger logger = new Logger();
            logger.LoggerHandlerManager
                .RegisterHandler(new ConsoleLoggerHandler())
                .RegisterHandler(new FileLoggerHandler(FileLoggerHandler.CreateFileName(), @"C:\Logs"))
                .RegisterHandler(new DebugConsoleLoggerHandler());

            
            // We define a log message
            logger.Log("Hello world");

            // We can define the level (type) of message
            logger.Log("Explicit define level", LogLevel.Info);
            
            // Settings of default type of message
            logger.DefaultLogLevel = LogLevel.Info;

            try
            {
                // Simulation of exceptions
                throw new Exception();
            }
            catch (Exception exception)
            {
                // Logging exceptions
                // Automatical adjustment of specific log into the Error and adding of StackTrace
                logger.Log(exception);
            }

            // Special feature - debug logging

            logger.Debug("Debug log");

            logger.DebugOff();
            logger.Debug("Not-logged message");

            logger.DebugOn();
            logger.Debug("I'am back!");

            // test of all LogLevels
            logger.Trace("Trace log");
            logger.Debug("Debug Log");
            logger.Info("Info Log");
            logger.Warning("Warning Log");
            logger.Error("Error Log");
            logger.Fatal("Fatal Log");


            Console.ReadKey();
        }
    }
}
