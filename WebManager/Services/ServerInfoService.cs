using log4net;
using Microsoft.Extensions.Configuration;
using WebManager.Utility;
using WebManager.ViewModels.Response.Management;
using WebManager.ViewModels.Response.ServerInfo;

namespace WebManager.Services
{
    public class ServerInfoService
    {
        private IConfiguration _config;
        static ILog m_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ServerInfoService(IConfiguration config)
        {
            this._config = config;
        }

        public async Task<GetServerInfoRes> GetServerInfo()
        {
            WebServiceLog wsLog = WebServiceLog.IN(m_logger);
            GetServerInfoRes res = new GetServerInfoRes();

            try
            {
                res.MsgServerVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                res.ClientIp = wsLog.IP;
                res.EnableIM = _config.GetValue<bool>("ServerInfo:EnableIM");
                res.BINDING_MODE = _config.GetValue<int>("ServerInfo:BINDING_MODE");
                res.EnableReceiverTextBox = _config.GetValue<bool>("ServerInfo:EnableReceiverTextBox");
                res.NeedApproval = _config.GetValue<bool>("ServerInfo:Need_Approval");
                res.MsgServerInternetUrl = _config.GetValue<string>("ServerInfo:MSG_SERVER_URL");
                res.MESSAGE_EXPIRED = _config.GetValue<int>("ServerInfo:MESSAGE_EXPIRED");
            }
            catch
            {

            }

            return res;
        }
    }
}
