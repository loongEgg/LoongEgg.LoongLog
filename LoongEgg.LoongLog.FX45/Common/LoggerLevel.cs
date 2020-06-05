namespace LoongEgg.LoongLog.FX45
{
    /// <summary>
    /// Logger的级别
    /// </summary>
    public enum LoggerLevel
    {
        /// <summary>
        /// 显示所有级别消息
        /// </summary>
        Dbug,

        /// <summary>
        /// 显示一般消息、警告、故障
        /// </summary>
        Info,

        /// <summary>
        /// 显示警告、故障
        /// </summary>
        Warn,

        /// <summary>
        /// 仅显示故障
        /// </summary>
        Erro
    }
}
