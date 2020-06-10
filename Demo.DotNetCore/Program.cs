
using LoongEgg.LoongLog;
using System;
using System.Diagnostics;

namespace Demo.DotNetCore
{
    class Program
    {
        static void Main(string[] args) {
            Logger.EnableAll();
            //DebugLoggerOnly();
            //ConsoleLoggerOnly();
            //FileLoggerOnly();

            Logger.Debug("a debug message");
            Logger.Info("an information message");
            Logger.Warn("a warning message");
            Logger.Error("a error message");

            // Clear all logger
            Logger.Disable();

            // Check the logger level of [Info]
            Logger.EnableAll(LoggerLevel.Info);
            Logger.Warn(Environment.NewLine + "    [Debug]message is invisible now");
            Logger.Debug("a debug message");        /* invisibled will be right*/
            Logger.Info("an information message");
            Logger.Warn("a warning message");
            Logger.Error("a error message");
            Logger.Disable();

            // Check the logger level of [Warn]
            Logger.EnableAll(LoggerLevel.Warn); 
            Logger.Warn(Environment.NewLine + "    [Debug] & [Info]  message is invisible now");
            Logger.Debug("a debug message");        /* invisibled will be right*/
            Logger.Info("an information message");  /* invisibled will be right*/
            Logger.Warn("a warning message");
            Logger.Error("a error message");
            Logger.Disable();

            // Check the logger level of [Error]
            Logger.EnableAll(LoggerLevel.Erro);
            Logger.Error( Environment.NewLine + "    [Debug] & [Info] & [Warn] message is invisible now");
            Logger.Debug("a debug message");        /* invisibled will be right*/
            Logger.Info("an information message");  /* invisibled will be right*/
            Logger.Warn("a warning message");       /* invisibled will be right*/
            Logger.Error("a error message");
            Logger.Disable();

            Debugger.Break();
        }

        static void DebugLoggerOnly() => Logger.Enable(Loggers.DebugLogger); 

        static void ConsoleLoggerOnly() => Logger.Enable(Loggers.ConsoleLogger); 

        static void FileLoggerOnly() => Logger.Enable(Loggers.FileLogger); 
    }
}
