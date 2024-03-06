using WebManager.ViewModels.Common;

namespace WebManager.ViewModels.Response.ServerInfo
{
    public class GetServerInfoRes : outMagBase
    {
        public string MsgServerVersion { get; set; }
        public string ClientIp { get; set; }
        public bool EnableIM { get; set; }
        /// <summary>
        /// 最後登入有效
        /// </summary>
        public int BINDING_MODE { get; set; }
        public bool EnableReceiverTextBox { get; set; }
        public bool NeedApproval { get; set; }
        public string MsgServerInternetUrl { get; set; }
        public int MESSAGE_EXPIRED { get; set; }
    }
}
