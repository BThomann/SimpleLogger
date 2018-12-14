namespace SimpleLogger.Logging
{
    public enum LogLevel
    {
        // the same LogLevels wich are used for NLog see: https://github.com/NLog/NLog/wiki/Configuration-file#log-levels

        /// <summary>Use to turn Logger of via </summary>
        None,
        /// <summary>For trace debugging; begin method X, end method X</summary>
        Trace,
        /// <summary>For debugging; executed query, user authenticated, session expired</summary>
        Debug,
        /// <summary>Normal behavior like mail sent, user updated profile etc.</summary>
        Info,
        /// <summary>Something unexpected; application will continue</summary>
        Warning,
        /// <summary>Something failed; application may or may not continue</summary>
        Error,
        /// <summary>Something bad happened; application is going down</summary>
        Fatal
    }
}
