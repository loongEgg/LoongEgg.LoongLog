using System;

namespace LoongEgg.LoongLog
{
    internal class ConsoleLogger : LoggerBase
    {
        [Obsolete("不允许在外部通过构造器生成实例", true)]
        public ConsoleLogger(LoggerLevel level) : base(level) { }

        /// <summary>
        /// <see cref="LoggerBase.WriteLine(string)"/>
        /// </summary> 
        public override void WriteLine(string msg) {
            Console.WriteLine(msg);
        }

        /// <summary>
        /// <see cref="LoggerBase.WriteLine(string, MessageType)"/>
        /// </summary> 
        public override void WriteLine(
            string message, 
            MessageType type) {

            if ((int)type < (int)Level)
                return;

            ConsoleColor old = Console.ForegroundColor;
            switch (type) {
                case MessageType.Dbug:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;

                case MessageType.Info:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                case MessageType.Warn:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;

                case MessageType.Erro:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    break;
            }

            Console.WriteLine(message);
            Console.ForegroundColor = old;
        }
    }

}
