namespace SampleDemo.Yzh.Net.Service
{
    // [Intercept(typeof(AopDemo))] 
    // 一个一个太麻烦，使用程序集注入，一次性全指定AopDemo 具体see:https://github.com/anjoy8/Blog.Core Blog.Core.Extensions.AutofacModuleRegister
    public interface IValuesService
    {
        Task<bool> UpdateSM();
    }
}
