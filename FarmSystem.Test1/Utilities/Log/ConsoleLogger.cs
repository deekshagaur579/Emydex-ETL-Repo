using System;

namespace FarmSystem.Test1.Utilities.Log
{
 

    public class ConsoleLogger : ILogger
    {
        public void LogInformation(string message)
        {
            Console.WriteLine($"[INFO]: {message}");
        }

        public void LogError(string message)
        {
            Console.WriteLine($"[ERROR]: {message}");
        }
    }
}
