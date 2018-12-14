Simple Logger C#.NET
=============

This is a fork from another GitHub Repo(https://github.com/jirkapenzes/SimpleLogger) i just adapted the logger for my needs and got rid of sum stuff wich i dont needed for my projects. I also added some doc. All credits go to for his initial release of the Project https://github.com/jirkapenzes! Thanks.

Usage
-------
```csharp
    public static void Main()
        {
            // Adding handler - to show log messages (ILoggerHandler)
            ILogger logger = new Logger();
            logger.LoggerHandlerManager
                .RegisterHandler(new ConsoleLoggerHandler())
                .RegisterHandler(new FileLoggerHandler())
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

            // Test of all LogLevels
            logger.Trace("Trace log");
            logger.Debug("Debug Log");
            logger.Info("Info Log");
            logger.Warning("Warning Log");
            logger.Error("Error Log");
            logger.Fatal("Fatal Log");


            Console.ReadKey();
        }
```

#### Output
```
14.12.18 14:53:18: Info [line: 19 Program -> Main()]: Hello world
14.12.18 14:53:18: Info [line: 22 Program -> Main()]: Explicit define level
14.12.18 14:53:18: Error [line: 36 Program -> Main()]: Eine Ausnahme vom Typ "System.Exception" wurde ausgelöst.
14.12.18 14:53:18: Debug [line: 41 Program -> Main()]: Debug log
14.12.18 14:53:18: Debug [line: 47 Program -> Main()]: I'am back!
14.12.18 14:53:18: Trace [line: 50 Program -> Main()]: Trace log
14.12.18 14:53:18: Debug [line: 51 Program -> Main()]: Debug Log
14.12.18 14:53:18: Info [line: 52 Program -> Main()]: Info Log
14.12.18 14:53:18: Warning [line: 53 Program -> Main()]: Warning Log
14.12.18 14:53:18: Error [line: 54 Program -> Main()]: Error Log
14.12.18 14:53:18: Fatal [line: 55 Program -> Main()]: Fatal Log

```
