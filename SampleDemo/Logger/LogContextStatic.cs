namespace SampleDemo.Yzh.Net.Logger
{
    public class LogContextStatic
    {
        public static readonly string BaseLogs = "Logs";
        public static readonly string AuditLogs = "AuditLogs";
        public static readonly string EFSql = "EFSql";
        public static readonly string FileMessageTemplate = "{NewLine}Date：{Timestamp:yyyy-MM-dd HH:mm:ss.fff}{NewLine}LogLevel：{Level}{NewLine}Message：{Message}{NewLine}{Exception}" + new string('-', 50);

        static LogContextStatic()
        {
            if (!Directory.Exists(BaseLogs))
            {
                Directory.CreateDirectory(BaseLogs);
            }
        }

        public static string Combine(string path1)
        {
            return Path.Combine(BaseLogs, path1);
        }

        public static string Combine(string path1, string path2)
        {
            return Path.Combine(BaseLogs, path1, path2);
        }

        public static string Combine(string path1, string path2, string path3)
        {
            return Path.Combine(BaseLogs, path1, path2, path3);
        }
    }
}
