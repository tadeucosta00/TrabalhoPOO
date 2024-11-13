using System;
using System.IO;

namespace Logs
{
    public class Logger
    {
        private readonly string logFilePath = @"C:\Users\tadeu\Documents\GitHub\TrabalhoPOO\logs.txt";

        public Logger()
        {
            var logDir = Path.GetDirectoryName(logFilePath);

            if (!Directory.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
            }
        }

        public void LogInfo(string message)
        {
            Log(message, "INFO");
        }


        public void LogError(string message)
        {
            Log(message, "ERROR");
        }

        private void Log(string message, string level)
        {
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";

            try
            {
                File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao escrever no log: {ex.Message}");
            }
        }
    }
}
