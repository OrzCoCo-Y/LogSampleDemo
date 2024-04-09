using SampleDemo.Yzh.Net.Core;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace SampleDemo.Yzh.Net.Logger
{
    public static class LoggerConfigurationExtensions
    {
        /// <summary>
        /// 输出在控制台
        /// </summary>
        /// <param name="loggerConfiguration"></param>
        /// <returns></returns>
        public static LoggerConfiguration WriteToConsole(this LoggerConfiguration loggerConfiguration)
        {
            // 输出普通日志
            loggerConfiguration = loggerConfiguration.WriteTo.Logger(lg =>
                lg.FilterRemoveSqlLog().WriteTo.Console());

            // 输出SQL
            loggerConfiguration = loggerConfiguration.WriteTo.Logger(lg =>
                lg.FilterSqlLog().WriteTo.Console());

            return loggerConfiguration;
        }

        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="loggerConfiguration"></param>
        /// <returns></returns>
        public static LoggerConfiguration WriteToFile(this LoggerConfiguration loggerConfiguration)
        {
            // SQL语句写入 
            loggerConfiguration = loggerConfiguration.WriteTo.Logger(lg =>
                lg.FilterSqlLog()
                    .WriteTo.Async(s => s.File(LogContextStatic.Combine(LogContextStatic.EFSql, @"EFSql.txt"), rollingInterval: RollingInterval.Day,
                        outputTemplate: LogContextStatic.FileMessageTemplate, retainedFileCountLimit: 31)));

            // 非SQL写入
            loggerConfiguration = loggerConfiguration.WriteTo.Logger(lg =>
                lg.FilterRemoveSqlLog()
                    .WriteTo.Async(s => s.File(LogContextStatic.Combine(LogContextStatic.AuditLogs, @"AuditLog.txt"), rollingInterval: RollingInterval.Hour,
                    outputTemplate: LogContextStatic.FileMessageTemplate, retainedFileCountLimit: 31)));
            return loggerConfiguration;
        }

        /// <summary>
        /// 推送至 ES
        /// </summary>
        /// <param name="loggerConfiguration"></param>
        /// <returns></returns>
        public static LoggerConfiguration WriteToElasticsearch(this LoggerConfiguration loggerConfiguration)
        {
            var esUri = AppSettings.GetValue("ElasticConfiguration:Uri");
            loggerConfiguration = loggerConfiguration.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(
                    new Uri(esUri))
            {
                AutoRegisterTemplate = true,
                IndexFormat = "nico-api-log-{0:yyyy.MM.dd}",
                ModifyConnectionSettings = con => con.ServerCertificateValidationCallback((sender, certificate, chain, sslPolicyErrors) => true)
                .BasicAuthentication(
                    AppSettings.GetValue("ElasticConfiguration:Es_UserName"),
                    AppSettings.GetValue("ElasticConfiguration:Es_Pwd"))
            });
            return loggerConfiguration;
        }

        /// <summary>
        /// 过滤出 SQL语句的日志
        /// </summary>
        /// <param name="lc"></param>
        /// <returns></returns>
        public static LoggerConfiguration FilterSqlLog(this LoggerConfiguration lc)
        {
            return lc.Filter.ByIncludingOnly(e =>
            e.Properties.ContainsKey("SourceContext") &&
            e.Properties["SourceContext"].ToString().Contains("Microsoft.EntityFrameworkCore.Database.Command"));
        }

        /// <summary>
        /// 过滤非 SQL语句的日志
        /// </summary>
        /// <param name="lc"></param>
        /// <returns></returns>
        public static LoggerConfiguration FilterRemoveSqlLog(this LoggerConfiguration lc)
        {
            return lc.Filter.ByExcluding(e =>
            e.Properties.ContainsKey("SourceContext") &&
            e.Properties["SourceContext"].ToString().Contains("Microsoft.EntityFrameworkCore.Database.Command"));
        }
    }
}
