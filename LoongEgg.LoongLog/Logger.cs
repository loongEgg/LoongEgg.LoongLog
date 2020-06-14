using System.Linq;
using System.Runtime.CompilerServices;

namespace LoongEgg.LoongLog
{
    /// <summary>
    /// logger调度器
    /// </summary> 
    /// <example>
    ///     Logger.EnableAll();
    ///     Logger.Debug("A Debug message");
    ///     Logger.Info("A Information message");
    ///     Logger.Warn("A Warning message");
    ///     Logger.Error("A debug message");
    /// </example>
    public static class Logger
    {
        private static bool IsDetailMode = false;
        private readonly static object _Lock = new object();

        /// <summary>
        /// 激活各种logger, 可以使用'|'位或运算
        /// </summary>
        ///     <param name="type">待激活的各种logger标志</param>
        ///     <param name="level">logger的级别, 默认为<see cref="LoggerLevel.Dbug"/></param>
        ///     <param name="fileName">[建议不要设置]fileLogger的文件名称</param>
        public static void Enable(Loggers type, LoggerLevel level = LoggerLevel.Dbug, string fileName = null)
            => Enable(type, false, level, fileName);

        /// <summary>
        /// 激活各种logger, 可以使用'|'位或运算
        /// </summary>
        ///     <param name="type">待激活的各种logger标志</param>
        ///     <param name="level">logger的级别, 默认为<see cref="LoggerLevel.Dbug"/></param>
        ///     <param name="fileName">[建议不要设置]fileLogger的文件名称</param>
        ///     <param name="isDetailMode">详细模式？</param>
        public static void Enable(Loggers type, bool isDetailMode, LoggerLevel level = LoggerLevel.Dbug, string fileName = null)
        {
            IsDetailMode = isDetailMode;
            if (type.HasFlag(Loggers.ConsoleLogger))
                LoggerBase.EnsureCreat<ConsoleLogger>(level);

            if (type.HasFlag(Loggers.DebugLogger))
                LoggerBase.EnsureCreat<DebugLogger>(level);

            if (type.HasFlag(Loggers.FileLogger))
            {
                LoggerBase.EnsureCreat<FileLogger>(level);
                if (fileName.IsNotNullOrEmptyOrSpace()) FileLogger.FileName = fileName;
                Info("Logger File [Created]... Check [ROOT_OF_YOUR_APP]/log/");
            }

        }

        /// <summary>
        /// 激活所有logger
        /// </summary>
        /// <param name="level"><see cref="LoggerLevel"/></param> 
        /// <param name="isDetailMode">详细模式？</param>
        public static void EnableAll(LoggerLevel level = LoggerLevel.Dbug, bool isDetailMode = false) 
            => Enable(Loggers.All, isDetailMode, level);

        /// <summary>
        /// 激活Debug时的Logger
        /// </summary>
        /// <param name="level">记录的最低级别</param>
        /// <param name="isDetailMode">详细模式？</param>
        public static void EnableDebugLogger(LoggerLevel level = LoggerLevel.Dbug, bool isDetailMode = false)
            => Enable(Loggers.DebugLogger, isDetailMode, level);

        /// <summary>
        /// 清除所有Logger
        /// </summary>
        public static void Disable()
        {
            if (LoggerBase.Instances.Any())
                foreach (LoggerBase log in LoggerBase.Instances.Values)
                    if (log is FileLogger)
                        Info("Logger File is [Closed]... Check [ROOT_OF_YOUR_APP]/log/");
            LoggerBase.ClearAll();
        }

        /// <summary>
        /// 打印一条<see cref="MessageType.Dbug"/>
        /// </summary>
        /// <param name="message">消息的具体内容</param> 
        /// <param name="callerPath">调用的方法所在文件</param>
        /// <param name="callerLine">调用代码所在行</param>
        /// <param name="callerMethod">调用方法的名字</param>
        public static void Debug(
            string message,
            [CallerFilePath] string callerPath = null,
            [CallerLineNumber] int callerLine = 0,
            [CallerMemberName] string callerMethod = null) => WriteLine(message, MessageType.Dbug, callerPath, callerLine, callerMethod);

        /// <summary>
        /// 打印一条<see cref="MessageType.Erro"/>
        /// </summary>
        /// <param name="message">消息的具体内容</param> 
        /// <param name="callerPath">调用的方法所在文件</param>
        /// <param name="callerLine">调用代码所在行</param>
        /// <param name="callerMethod">调用方法的名字</param>
        public static void Error(
             string message,
            [CallerFilePath] string callerPath = null,
            [CallerLineNumber] int callerLine = 0,
            [CallerMemberName] string callerMethod = null) => WriteLine(message, MessageType.Erro, callerPath, callerLine, callerMethod);

        /// <summary>
        /// 打印一条<see cref="MessageType.Info"/>
        /// </summary>
        /// <param name="message">消息的具体内容</param> 
        /// <param name="callerPath">调用的方法所在文件</param>
        /// <param name="callerLine">调用代码所在行</param>
        /// <param name="callerMethod">调用方法的名字</param> 
        public static void Info(
            string message,
            [CallerFilePath] string callerPath = null,
            [CallerLineNumber] int callerLine = 0,
            [CallerMemberName] string callerMethod = null) => WriteLine(message, MessageType.Info, callerPath, callerLine, callerMethod);

        /// <summary>
        /// 打印一条<see cref="MessageType.Warn"/>
        /// </summary>
        /// <param name="message">消息的具体内容</param> 
        /// <param name="callerPath">调用的方法所在文件</param>
        /// <param name="callerLine">调用代码所在行</param>
        /// <param name="callerMethod">调用方法的名字</param>
        public static void Warn(
            string message,
            [CallerFilePath] string callerPath = null,
            [CallerLineNumber] int callerLine = 0,
            [CallerMemberName] string callerMethod = null) => WriteLine(message, MessageType.Warn, callerPath, callerLine, callerMethod);

        /// <summary>
        /// 简单打印一条消息
        /// </summary>
        /// <param name="message"></param>
        public static void WriteLine(string message)
        {
            lock (_Lock)
            {
                if (LoggerBase.Instances.Any())
                    foreach (LoggerBase log in LoggerBase.Instances.Values)
                        log.WriteLine(message);
            }
        }

        /// <summary>
        /// 打印一条详细的消息
        /// </summary>
        /// <param name="message">消息的具体内容</param>
        /// <param name="type">消息类型</param>
        /// <param name="callerPath">调用的方法所在文件</param>
        /// <param name="callerLine">调用代码所在行</param>
        /// <param name="callerMethod">调用方法的名字</param>
        public static void WriteLine(
            string message,
            MessageType type,
            [CallerFilePath] string callerPath = null,
            [CallerLineNumber] int callerLine = 0,
            [CallerMemberName] string callerMethod = null)
        {

            lock (_Lock)
            {
                if (LoggerBase.Instances.Any())
                    foreach (LoggerBase log in LoggerBase.Instances.Values)
                    {
                        if (IsDetailMode)
                            log.WriteLine(LoggerBase.FormatMessage(message, type, callerPath, callerLine, callerMethod), type);
                        else
                            log.WriteLine(LoggerBase.FormatMessage(message, type), type);
                    }
            }
        }
    }
}
