using Autofac.Extras.DynamicProxy;
using SampleDemo.Yzh.Net.Core;

namespace SampleDemo.Yzh.Net.Service
{
    [Intercept(typeof(AopDemo))]   // 一个一个太麻烦，使用程序集注入，一次性全指定AopDemo
    public interface IValuesService
    {
        Task<bool> UpdateSM();
    }
}
