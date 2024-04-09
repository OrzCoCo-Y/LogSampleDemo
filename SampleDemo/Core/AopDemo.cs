
using Castle.DynamicProxy;
using ILogger = Serilog.ILogger;

namespace SampleDemo.Yzh.Net.Core
{
    /// <summary>
    /// AOP 拦截器   控制台版本在Autofac_DynamicProxy
    /// </summary>
    /// <param name="accessor"></param>
    /// <param name="logger"></param>
    public class AopDemo(IHttpContextAccessor accessor, ILogger logger) : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var httpContext = accessor.HttpContext;
            var requestPath = httpContext?.Request.Path.Value ?? "unknown path";
            var requestMethod = httpContext?.Request.Method ?? "unknown method";

            try
            {
                logger.Information($"HTTP {requestMethod} {requestPath}: Calling method {invocation.Method.Name} with parameters {string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()))}...");
                invocation.Proceed();
                logger.Information($"HTTP {requestMethod} {requestPath}: Done calling {invocation.Method.Name}. Result was {invocation.ReturnValue}.");
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"HTTP {requestMethod} {requestPath}: Exception calling {invocation.Method.Name}");
                throw;
            }
        }
    }
}
