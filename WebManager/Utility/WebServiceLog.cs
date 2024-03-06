using log4net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Web;

namespace WebManager.Utility
{
    public static class HttpContext
    {
        public static IServiceProvider ServiceProvider;

        public static Microsoft.AspNetCore.Http.HttpContext Current
        {
            get
            {
                object factory = ServiceProvider.GetService(typeof(IHttpContextAccessor));
                Microsoft.AspNetCore.Http.HttpContext context = ((HttpContextAccessor)factory).HttpContext;
                return context;
            }
        }

    }
    public class WebServiceLog
    {
        public DateTime BeginTime { get; set; }
        public long NO { get; set; }
        public string IP { get; set; }
        public ILog Logger { get; set; }


        public static WebServiceLog IN(ILog logger)
        {
            return _WebServiceLog(logger);
        }

        private static WebServiceLog _WebServiceLog(ILog logger)
        {
            StackTrace st = new StackTrace();
            StackFrame[] frames = st.GetFrames();
            StringBuilder sb = new StringBuilder();
            // 通過叠代調用堆棧的幀，方法名添加到sb，以記錄調用紀錄
            var methodNames = frames
                .Skip(1)
                .Take(3)
                .Select(frame => frame.GetMethod().Name);
            sb.Append(string.Join(" < ", methodNames));
            // 日誌紀錄器
            WebServiceLog data = new WebServiceLog()
            {
                Logger = logger,
                BeginTime = DateTime.Now,
                NO = LogCount.Instance.Count,
                // 抓取Client端的IP Address
                IP = ""
                //IP = (HttpContext.Current == null || HttpContext.Current.Request == null) ? "" : HttpContext.Current.Request.RemoteIpAddress;
            };
            // 調試過後的日誌寫入日誌紀錄器
            data.Logger.Debug(string.Format("IN={0},IP={1},TR={2}",
                data.NO,
                data.IP,
                sb.ToString()
                ));
            // 嘗試從請求路徑中獲取動作，並存入 HttpContext.Current.Items["actionInfo"]
            //if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
            //{
            //    ActionTxNo atn;
            //    string action = DataActionLog.GetActionFromRequestPath(System.Web.HttpContext.Current.Request.Path, out atn);
            //    if (!string.IsNullOrWhiteSpace(action))
            //        System.Web.HttpContext.Current.Items["actionInfo"] = info;
            //}

            return data;
        }

        public static WebServiceLog IN<T>(ILog logger, T arg)
        {
            return _WebServiceLog(logger, arg);
        }

        private static WebServiceLog _WebServiceLog<T>(ILog logger, T arg)
        {
            StackTrace st = new StackTrace();
            StackFrame[] frames = st.GetFrames();
            StringBuilder sb = new StringBuilder();
            // 通過叠代調用堆棧的幀，方法名添加到sb，以記錄調用紀錄
            var methodNames = frames
                .Skip(1)
                .Take(3)
                .Select(frame => frame.GetMethod().Name);
            sb.Append(string.Join(" < ", methodNames));
            // 日誌紀錄器
            WebServiceLog data = new WebServiceLog()
            {
                Logger = logger,
                BeginTime = DateTime.Now,
                NO = LogCount.Instance.Count,
                // 抓取Client端的IP Address
                IP = ""
                //IP = (HttpContext.Current == null || HttpContext.Current.Request == null) ? "" : HttpContext.Current.Request.RemoteIpAddress;
            };
            // 限制長度
            string info = JsonConvert.SerializeObject(arg);
            int maxLen = 2048; // UTB_ACTION_LOG.FLD_ACTION_PATH 的長度限制
            if (info.Length > maxLen)
                info = info.Substring(0, maxLen);
            // 調試過後的日誌寫入日誌紀錄器
            data.Logger.Debug(string.Format("IN={0},IP={1},TR={2},PA={3}",
                data.NO,
                data.IP,
                sb.ToString(),
                info));
            // 嘗試從請求路徑中獲取動作，並存入 HttpContext.Current.Items["actionInfo"]
            //if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
            //{
            //    ActionTxNo atn;
            //    string action = DataActionLog.GetActionFromRequestPath(System.Web.HttpContext.Current.Request.Path, out atn);
            //    if (!string.IsNullOrWhiteSpace(action))
            //        System.Web.HttpContext.Current.Items["actionInfo"] = info;
            //}

            return data;
        }
    }
}
