namespace WebManager.ViewModels.Common
{
    public class outMagBase
    {
        public string UniqueId { get; set; }

        public string errCode { get; set; } = "";

        public string errMsg { get; set; }

        public int errProc { get; set; }

        public string ApplicationId { get; set; }   // 申請核准代碼
    }
}
