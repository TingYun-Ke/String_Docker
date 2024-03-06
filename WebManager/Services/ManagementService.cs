using WebManager.CommonModels;
using WebManager.Services.Interface;
using WebManager.Utility;
using WebManager.ViewModels.Request.Management;
using WebManager.ViewModels.Response.Management;

namespace WebManager.Services
{
    public class ManagementService : IManagementService
    {
        private readonly AccountManagementFunc _accountManagementFunc;

        public ManagementService(AccountManagementFunc accountManagementFunc)
        {
            _accountManagementFunc = accountManagementFunc;
        }
        public async Task<GetAccountManagementRes> GetAccountManagement(GetAccountManagementReq req)
        {
            AccountManagementFuncDto frontHandle = await _accountManagementFunc.PasswordHandle(req);
            // 授權查核


            GetAccountManagementRes res = new GetAccountManagementRes();
            return res;
        }
    }
}
