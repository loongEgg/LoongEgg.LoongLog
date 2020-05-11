using System;

namespace LoongEgg.LoongLog
{
    /// <summary>
    /// 控制台版的logger
    /// </summary>
    internal class DebugLogger : LoggerBase
    {
        [Obsolete("不允许在外部通过构造器生成实例", true)]
        public DebugLogger(LoggerLevel level) : base(level) { } 

        /// <summary>
        /// <see cref="LoggerBase.WriteLine(string)"/>
        /// </summary> 
        public override void WriteLine(string msg) {
            System.Diagnostics.Debug.WriteLine(msg);
        }

        /// <summary>
        /// <see cref="LoggerBase.WriteLine(string, MessageType)"/>
        /// </summary> 
        public override void WriteLine(
            string message, 
            MessageType type)
            => System.Diagnostics.Debug.WriteLine(message);
    }

}
