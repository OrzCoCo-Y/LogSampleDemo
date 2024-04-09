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
    containerBuilder.RegisterInstance(Log.Logger).As<ILogger>();
});

builder.Services.AddControllers();
var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
