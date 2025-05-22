
using System;



namespace FarmSystem.Test1.Utilities.Log
{
    public static class LoggerFactory
    {
        private static ILogger _logger = new ConsoleLogger(); // Can switch to FileLogger etc.

        public static ILogger GetLogger()
        {
            return _logger;
        }
    }
}
