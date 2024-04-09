using SampleDemo.Yzh.Net.Core;
using Serilog;

namespace SampleDemo.Yzh.Net.Logger
{
    public static class CustomLogger
    {
        public static IHostBuilder AddCustomLog(this IHostBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(AppSettings.Configuration)
                .Enrich.FromLogContext()

                // 输出到控制台
                .WriteToConsole()
                // 输出到文件
                .WriteToFile()
                // 输出到Es
                .WriteToElasticsearch()
                .CreateLogger();

            builder.UseSerilog();
            return builder;
        }
    }
}
