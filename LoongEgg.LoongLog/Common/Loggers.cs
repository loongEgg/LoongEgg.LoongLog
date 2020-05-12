using System;

namespace LoongEgg.LoongLog
{
    /// <summary>
    /// 要开启的logger类型
    /// </summary>
    [Flags]
    public enum Loggers
    {
        /// <summary>
        /// 仅开启调试输出日志, Debug logger only
        /// </summary>
        DebugLogger = 0x1,

        /// <summary>
        /// 仅开启控制台日志， Console logger only
        /// </summary>
        ConsoleLogger = 0x2,

        /// <summary>
        /// 仅开启文件文件日志, File logger only
        /// </summary>
        FileLogger = 0x4,

        /// <summary>
        /// 开启所有logger
        /// </summary>
        All =  DebugLogger | ConsoleLogger | FileLogger,
    }
}
