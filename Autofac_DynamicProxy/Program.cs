using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;

namespace Autofac_DynamicProxy
{
    public interface IService
    {
        void DoSomething();
    }

    public class Service : IService
    {
        public void DoSomething()
        {
            Console.WriteLine("Service is doing something.");
        }
    }

    public class CustomInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"Before invoking method {invocation.Method.Name}");
            invocation.Proceed(); // 调用原始方法
            Console.WriteLine($"After invoking method {invocation.Method.Name}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 创建容器构建器
            var builder = new ContainerBuilder();

            // 注册服务并启用动态代理
            builder.RegisterType<Service>()
                .As<IService>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(CustomInterceptor));

            // 注册拦截器
            builder.Register(c => new CustomInterceptor());

            // 构建容器
            var container = builder.Build();

            // 从容器中解析服务
            var service = container.Resolve<IService>();

            // 调用服务方法
            service.DoSomething();
        }
    }
}
