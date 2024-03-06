namespace WebManager.ViewModels.Common
{
    public class inMagBaseGuid : inMagBase
    {

        public string Account { get; set; }

        public string Guid { get; set; }

        public string Password { get; set; }

        public string RoleId { get; set; }

        public bool Approval = false;   // =true, 表示為授權執行的指令, 不需要檢查帳號與密碼
        public bool BatchFileProcess = false;   // =true, 表示不需要驗證帳號密碼

        // 將 Password 及 Guid 保存, 以避免 log 顯示出來
        public void PasswordGuid_Hide(out string password_Store, out string guid_Store)
        {
            password_Store = Password;
            guid_Store = Guid;

            // 2022/08/04 Fortify原掃修正 Privacy Violation 密碼如非null或空白，會進行隱藏，沒有外洩問題，不需修正
            Password = string.IsNullOrWhiteSpace(Password) ? Password : "xxxx";
            Guid = string.IsNullOrWhiteSpace(Guid) ? Guid : "xxxx";
        }
        public void PasswordGuid_Restore(string password_Store, string guid_Store)
        {
            Password = password_Store;
            Guid = guid_Store;
        }
    }
}
