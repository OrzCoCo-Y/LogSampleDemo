using Microsoft.EntityFrameworkCore;
using SampleDemo.Yzh.Net.Repository;
using System.Security.Cryptography;

namespace SampleDemo.Yzh.Net.Service
{
    public class ValuesService(ILogger<ValuesService> logger, TestContext testContext) : IValuesService
    {
        public async Task<bool> UpdateSM()
        {
            logger.LogInformation("OrzCoCo");
            var blogs = await testContext.TestEFTables.FirstOrDefaultAsync();
            if (blogs != null)
            {
                // 生成一个随机整数
                int randomNumber = GenerateRandomNumber(1, 100);  // 更安全的随机数生成器，为了通过sonar安全扫描
                blogs.Name = "test" + randomNumber;
                blogs.LastModifiedAt = DateTimeOffset.Now;
                blogs.LastModifiedBy = -1400;

                await testContext.SaveChangesAsync();
            }
            return true;
        }

        private static int GenerateRandomNumber(int minValue, int maxValue)
        {
            using RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] randomNumber = new byte[4]; // 用于存储32位整数
            rng.GetBytes(randomNumber);
            int value = BitConverter.ToInt32(randomNumber, 0);
            return Math.Abs(value % (maxValue - minValue)) + minValue;
        }
    }
}
