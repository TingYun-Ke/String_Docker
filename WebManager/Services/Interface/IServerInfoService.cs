using WebManager.ViewModels.Response.ServerInfo;

namespace WebManager.Services.Interface
{
    public interface IServerInfoService
    {
        /// <summary>
        /// 取得 Server 相關資訊
        /// </summary>
        /// <returns></returns>
        Task<GetServerInfoRes> GetServerInfoRes();
    }
}
