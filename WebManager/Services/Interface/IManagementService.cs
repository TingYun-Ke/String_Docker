using WebManager.ViewModels.Request.Management;
using WebManager.ViewModels.Response.Management;

namespace WebManager.Services.Interface
{
    public interface IManagementService
    {
        /// <summary>
        /// 預設帳號
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<GetAccountManagementRes> GetAccountManagement(GetAccountManagementReq req);
    }
}
