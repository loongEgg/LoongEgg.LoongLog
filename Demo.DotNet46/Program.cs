using LoongEgg.LoongLog;
using System.Diagnostics;

namespace Demo.DotNet46
{
    class Program
    {
        static void Main(string[] args) {
            Logger.EnableAll();
            // DebugLoggerOnly();
            // ConsoleLoggerOnly();
            //FileLoggerOnly();

            Logger.WriteDebug("a debug message");
            Logger.WriteInformation("an information message");
            Logger.WriteWarning("a warning message");
            Logger.WriteError("a error message");

            Logger.Disable();

            Debugger.Break();
        }

        static void DebugLoggerOnly() => Logger.Enable(Loggers.DebugLogger); 

        static void ConsoleLoggerOnly() => Logger.Enable(Loggers.ConsoleLogger); 

        static void FileLoggerOnly() => Logger.Enable(Loggers.FileLogger); 
    }
}
