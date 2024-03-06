using log4net;

namespace WebManager.Utility
{
    public class ErrorCode
    {
        static ILog m_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void SetExceptionInfo(ref string code, ref string msg, ref int proc, Exception ex)
        {
            SetErrorInfo(ErrorType.Exception, ref code, ref msg, ref proc);
            string exMsg = ex.Message.ToString();
            if (exMsg.Length <= 100)    // 避免透漏過多的訊息
                msg += "：" + exMsg;
            m_logger.Error("ExceptionInfo: " + LogHandle.StripLog(code + "," + msg) + "\n" + ex.ToString());
        }

        public static void SetErrorInfo(ErrorType errorType, ref string code, ref string msg, ref int proc)
        {
            ErrorCode err = GetErrorCode(errorType);
            if (err != null)
            {
                code = err.Code;
                msg = string.Format("{0}", err.Message);
                proc = (int)err.ErrorProc;

                if (errorType == ErrorType.使用授權失敗 && !string.IsNullOrWhiteSpace(WebConfigSetting.AppName))
                {
                    msg = string.Format("提醒您已在其他裝置登入，請重新啟動「{0}」", WebConfigSetting.AppName);
                }
                else if (errorType == ErrorType.會議室已達上限)
                {
                    msg = string.Format("您所建立的會議室已達{0}組上限", WebConfigSetting.MaxGroupCreateCount);
                }
                else if (errorType == ErrorType.會議室人數達上限)
                {
                    msg = string.Format("群組人數已達{0}人之上限", WebConfigSetting.MaxGroupMemberCount);
                }
            }
            else
            {
                code = "9999";
                msg = string.Format("服務執行發生錯誤:");
                proc = (int)ErrorProc.DebugDialog;
            }

            m_logger.Error("ErrorInfo: " + Utility.StripLog(code + "," + msg));
        }

        private static ErrorCode GetErrorCode(ErrorType errorType)
        {
            foreach (ErrorCode item in ErrorMaps)
            {
                if (item.ErrorType == errorType)
                    return item;
            }
            return null;
        }
    }

}
