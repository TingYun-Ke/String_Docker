using Microsoft.AspNetCore.Mvc;
using WebManager.Services.Interface;
using WebManager.ViewModels.Request.Management;
using WebManager.ViewModels.Response.Management;

namespace WebManager.Controllers
{
    public class ManagementController
    {
        private readonly IManagementService _managementService;

        public ManagementController(IManagementService managementService)
        {
            this._managementService = managementService;
        }

        [HttpPost("AccountManagement")]
        [ResponseCache]
        public async Task<GetAccountManagementRes> GetAccountManagement([FromQuery] GetAccountManagementReq req)
        {
            var res = await _managementService.GetAccountManagement(req);
            return res;
        }

        
    }
}
