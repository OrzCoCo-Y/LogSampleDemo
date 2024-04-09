namespace SampleDemo.Yzh.Net.Core
{
    /// <summary>
    /// Response 处理中间件
    /// </summary>
    /// <param name="next">请求</param>
    /// <param name="logger">日志</param>
    public class ResponseLoggingMiddleware(RequestDelegate next, ILogger<ResponseLoggingMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            // 使用MemoryStream替换原始的响应流
            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            // 继续处理请求
            await next(context);

            // 将响应流重置到开始位置，并读取内容
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            // 记录响应内容
            logger.LogInformation($"Response: {text}");

            // 将响应写回原始的响应流
            await responseBody.CopyToAsync(originalBodyStream);
        }
    }
}
