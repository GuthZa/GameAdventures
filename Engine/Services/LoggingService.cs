using System;
using System.IO;
namespace Engine.Services
{
    public static class LoggingService
    {
        public const string LOG_FILE_DIRECTORY = "Logs";
        static LoggingService()
        {
            string logDirectiory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LOG_FILE_DIRECTORY);
            if(!Directory.Exists(logDirectiory))
            {
                Directory.CreateDirectory(logDirectiory);
            }
        }
        public static void Log(Exception exception, bool isInnerException = false)
        {
            using(StreamWriter sw = new StreamWriter(LogFileName(), true))
            {
                sw.WriteLine(new string(isInnerException ? '-' : '=', 40));
                sw.WriteLine($"{exception.Message}");
                sw.WriteLine($"{exception.StackTrace}");
                sw.WriteLine(); //Blank Line
            }
            if(exception.InnerException != null)
            {
                Log(exception.InnerException, true);
            }
        }
        private static string LogFileName()
        {
            //This will create a separate log file for eachday.
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LOG_FILE_DIRECTORY, $"RPG_{DateTime.Now:yyyyMMdd}.log");
        }
    }
}
