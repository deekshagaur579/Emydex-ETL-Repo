using System;
using System.Configuration;
using System.IO;

namespace FarmSystem.Test1.Utilities.Log
{
    public class FileLogger : ILogger
    {
        private readonly string _logFilePath;
        private static readonly FileLogger _instance = new FileLogger(); // singleton instance
        public static FileLogger Instance
        {
            get { return _instance; }
        }
        public FileLogger(string logFilePath = "farm_log.txt")
        {
            _logFilePath = ConfigurationManager.AppSettings["LogFilePath"] ?? "farm_log.txt";

            // check if the directory exists
            string directory = Path.GetDirectoryName(_logFilePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Create file if it does not exist
            if (!File.Exists(_logFilePath))
            {
                using (File.Create(_logFilePath)) { }
            }
        }

        public void LogInformation(string message)
        {
            string formattedMessage = $"[LOG] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            File.AppendAllText(_logFilePath, formattedMessage + Environment.NewLine);
        }

        public void LogError(string message)
        {
            string formattedMessage = $"[ERROR] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            File.AppendAllText(_logFilePath, formattedMessage + Environment.NewLine);
        }
    }
}
