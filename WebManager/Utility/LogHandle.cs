namespace WebManager.Utility
{
    /// <summary>
    /// 清除日志中的换行符
    /// </summary>
    public class LogHandle
    {
        public static string StripLog(string log)
        {
            if (string.IsNullOrEmpty(log))
                return log;
            string[] newLineSymbol = { "%0a", "%0A", "%0d", "%0D", "\n", "\r" };
            foreach (string symbol in newLineSymbol)
            {
                log = log.Replace(symbol, string.Empty);
            }
            return log;
        }
    }


}
