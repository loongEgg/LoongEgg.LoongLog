using System;
using System.IO;

namespace LoongEgg.LoongLog
{
    /// <summary>
    /// File版的<see cref="LoggerBase"/>
    /// </summary>
    internal class FileLogger : LoggerBase
    { 

        /*-------------------------------------- Properties -------------------------------------*/
        // Logger文件所在的路径
        public static string FileName {
            get => _FileName;
            set {
                _FileName = value;
                using (StreamWriter writer = new StreamWriter(FileName)) { }
            }
        }
        private static string _FileName = null;

        /*------------------------------------- Constructors ------------------------------------*/
        /// <summary>
        /// 生成一个FileLogger的实例,不建议指定完整的路径和名字,留为Null
        /// </summary>
        /// <param name="level"></param>
        /// <param name="fileName"></param>        
        private FileLogger(LoggerLevel level, string fileName) : base(level) {
             if (fileName == null) {
                
                string root = Environment.CurrentDirectory;
                
                if (! Directory.Exists(root + @"/log/")) {
                    Directory.CreateDirectory(root + @"/log/");
                }

                FileName = root + @"/log/" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".log";
            }
            else {
                FileName = fileName;       
            } 
        }

        /// <summary>
        /// 生成一个FileLogger的实例
        /// </summary>
        /// <param name="level"></param>
        [Obsolete("不允许在外部通过构造器生成实例", true)]
        public FileLogger(LoggerLevel level) : this(level, null) { }
         
        /*------------------------------------ Public Methods -----------------------------------*/
        public override void WriteLine(string message) => WriteLine(FileName, message);

        public override void WriteLine(string message, MessageType type) => WriteLine(FileName, message);

        private static void WriteLine(string filePath, string message) {
            using (StreamWriter writer = new StreamWriter(FileName, true)) {
                writer.WriteLineAsync(message);
            }
        }
    }
}
