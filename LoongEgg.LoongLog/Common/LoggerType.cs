using System;

namespace LoongEgg.LoongLogger
{
    /// <summary>
    /// 要开启的logger类型
    /// </summary>
    [Flags]
    public enum LoggerType
    {
        /// <summary>
        /// 仅开启调试输出logger
        /// </summary>
        DebugLogger = 0x1,

        /// <summary>
        /// 仅开启控制台logger
        /// </summary>
        ConsoleLogger = 0x2,

        /// <summary>
        /// 仅开启文件logger
        /// </summary>
        FileLogger = 0x4,

        /// <summary>
        /// 开启所有logger
        /// </summary>
        All =  DebugLogger | ConsoleLogger | FileLogger,
    }
}
