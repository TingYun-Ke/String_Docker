using Microsoft.AspNetCore.Mvc;
using WebManager.Services.Interface;
using WebManager.ViewModels.Response.ServerInfo;

namespace WebManager.Controllers
{
    public class ServerInfoController
    {
        private IConfiguration _config;
        private IServerInfoService _serverInfoService;
        public ServerInfoController(IConfiguration config, IServerInfoService serverInfoService)
        {
            this._config = config;
            this._serverInfoService = serverInfoService;
        }

        [HttpPost("ServerInfo")]
        [ResponseCache]
        public async Task<GetServerInfoRes> GetServerInfo()
        {
            var res = await _serverInfoService.GetServerInfoRes();
            return res;
        }

    }
}
