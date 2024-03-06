using System.Runtime.Serialization;

namespace WebManager.ViewModels.Request.Management
{
    public class GetAccountManagementReq
    {
        /// <summary>
        /// 請求查詢的使用者帳號
        /// </summary>
        public string ManagerAccount { get; set; }
        /// <summary>
        /// 請求查詢的使用者密碼
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 新增帳號以半形逗號分隔
        /// </summary>
        public string AccountList { get; set; }
    }
}
