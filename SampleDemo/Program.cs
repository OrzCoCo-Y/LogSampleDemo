using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Microsoft.EntityFrameworkCore;
using SampleDemo.Yzh.Net.Logger;
using SampleDemo.Yzh.Net.Repository;
using SampleDemo.Yzh.Net.Service;
using SampleDemo.Yzh.Net.Core;
using Serilog;
using ILogger = Serilog.ILogger;

var builder = WebApplication.CreateBuilder(args);
// Config
builder.Services.AddSingleton(new AppSettings(builder.Configuration));
// Serilog
builder.Host.AddCustomLog();
// EF
builder.Services.AddDbContextPool<TestContext>
    (o => o.UseSqlServer(builder.Configuration.GetConnectionString("NicoLocaldbStr"))
    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddSerilog())
    ));
// Http Info
builder.Services.AddHttpContextAccessor();
// Auto Fac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    // 注册AopDemo拦截器为单例模式
    containerBuilder.RegisterType<AopDemo>().SingleInstance();

    // InterceptedBy指定拦截器
    containerBuilder.RegisterType<ValuesService>().As<IValuesService>().EnableInterfaceInterceptors().InterceptedBy(typeof(AopDemo));
    // 或者在IValuesService 加标签 [Intercept(typeof(AopDemo))]
    //containerBuilder.RegisterType<ValuesService>().As<IValuesService>().EnableInterfaceInterceptors();

    //向 Autofac 容器注册 Log.Logger 这个已经存在的日志记录器实例 ，指定这个实例作为 ILogger 接口的实现 ，此ILogger为 Serilog的ILogger
    //当应用程序中的组件通过依赖注入请求 ILogger 接口的实例时，它们会接收到 Log.Logger 这个单例对象
    containerBuilder.RegisterInstance(Log.Logger).As<ILogger>();
});

builder.Services.AddControllers();
var app = builder.Build();
// Middleware
app.UseMiddleware<ResponseLoggingMiddleware>(); //返回客户端响应的日志记录
app.UseAuthorization();
app.MapControllers();

app.Run();
