using log4net;
using log4net.Util.TypeConverters;
using System.Security;
using WebManager.CommonModels;
using WebManager.ViewModels.Request.Management;

namespace WebManager.Utility
{
    public class AccountManagementFunc
    {
        static ILog m_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<AccountManagementFuncDto> PasswordHandle(GetAccountManagementReq amReq)
        {
            // 創建 SecureString 的密碼
            //SecureString securePassword = new SecureString();
            //if (!string.IsNullOrEmpty(amReq.Password))
            //{
            //    foreach(char c in amReq.Password)
            //    {
            //        securePassword.AppendChar(c);
            //    }
            //}
            var tempMina = amReq.Password is null ? new char[0] : amReq.Password.ToCharArray(); ;
            amReq.Password = "xxxxx";
            // 創建 WebServiceLog  實例
            WebServiceLog wsLog = WebServiceLog.IN(m_logger, amReq);
            amReq.Password = tempMina.Length == 0 ? null : new string(tempMina);
            // 清除內文中的明文密碼
            Array.Clear(tempMina, 0, tempMina.Length);
            AccountManagementFuncDto Dto = new AccountManagementFuncDto
            {
                AmReq = amReq,
                WsLog = wsLog,
            };
            return Dto;
        }
    }
}
