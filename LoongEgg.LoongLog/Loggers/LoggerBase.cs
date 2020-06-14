using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LoongEgg.LoongLog
{
    /// <summary>
    /// logger的基类
    /// </summary>
    public abstract class LoggerBase
    {
        /// <summary>
        /// 所有的<see cref="LoggerBase"/>的派生类实例
        /// </summary>
        public static Dictionary<string, LoggerBase> Instances { get; private set; } = new Dictionary<string, LoggerBase>();

        /*-------------------------------------- Properties -------------------------------------*/
        /// <summary>
        /// logger记录器的最低记录级别
        /// </summary>
        public LoggerLevel Level { get; protected set; }

        /*------------------------------------- Constructors ------------------------------------*/
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="level"></param>
        protected LoggerBase(LoggerLevel level)
        {
            this.Level = level;
        }

        /*------------------------------------ Public Methods -----------------------------------*/
        /// <summary>
        /// 创建指定的Logger类型的单例
        /// </summary>
        /// <typeparam name="T">logger的类型</typeparam>
        /// <param name="level">logger的级别</param>
        /// <returns></returns>
        public static LoggerBase EnsureCreat<T>(LoggerLevel level) where T : LoggerBase
        {

            string typeName = typeof(T).Name;

            if (Instances == null)
                Instances = new Dictionary<string, LoggerBase>();

            if (!Instances.Keys.Contains(typeName))
                Instances.Add(typeName, (T)Activator.CreateInstance(typeof(T), level));

            Instances[typeName].Level = level;
            return Instances[typeName];
        }

        /// <summary>
        /// 清除所有Logger工具
        /// </summary>
        public static void ClearAll() => Instances.Clear();

        /// <summary>
        /// 销毁指定类型的Logger
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void ClearLogger<T>() where T : LoggerBase
        {
            if (Instances == null) return;

            string typeName = typeof(T).Name;
            if (Instances.Keys.Contains(typeName))
                Instances.Remove(typeName);
        }

        /// <summary>
        /// 将logger消息合并为一个字符串
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <param name="callerPath"></param>
        /// <param name="callerLine"></param>
        /// <param name="callerMethod"></param> 
        /// <returns></returns>
        public static string FormatMessage(
            string message,
            MessageType type,
            string callerPath,
            int callerLine,
            string callerMethod)
        {

            StringBuilder msg = new StringBuilder();
            msg.Append(DateTime.Now.ToString() + " ");
            msg.Append($"[ {type.ToString()} ] -> ");
            msg.Append($"{Path.GetFileName(callerPath)} > {callerMethod}() > in line[{callerLine.ToString().PadLeft(3, ' ')}]: ");

            msg.Append(message);
            return msg.ToString();
        }

        /// <summary>
        /// 精简打印模式
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string FormatMessage(string message, MessageType type) => $"{DateTime.Now.ToString()} [ {type.ToString()} ] -> {message}";

        /// <summary>
        /// 简单打印一条消息
        /// </summary>
        /// <param name="message"></param>
        public abstract void WriteLine(string message);

        /// <summary>
        /// 打印一条详细的消息
        /// </summary>
        /// <param name="message">消息的具体内容</param>
        /// <param name="type">消息类型</param>
        public abstract void WriteLine(
            string message,
            MessageType type);

    }
}
