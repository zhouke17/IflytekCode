namespace NLogWinForm
{
    public class LoggerManager
    {
        private static ILog _log1;
        private static ILog _log2;

        public static ILog Log1
        {
            get
            {
                if (_log1 == null)
                {
                    _log1 = new Log(NLog.LogManager.GetLogger("Log1"));//设置特定日志文件名
                }
                return _log1;
            }
        }
        public static ILog Log2
        {
            get
            {
                if (_log2 == null)
                {
                    _log2 = new Log(NLog.LogManager.GetLogger("Log2"));//设置特定日志文件名
                }
                return _log2;
            }
        }
    }
}
