namespace WebManager.Utility
{
    public class LogCount
    {
        private static LogCount _Instance;
        public static LogCount Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new LogCount();
                return _Instance;
            }
        }

        private long count = 0L;
        public long Count { get { Interlocked.Increment(ref count); return count; } }
        public string CountStr { get { Interlocked.Increment(ref count); return count.ToString(); } }
    }
}
