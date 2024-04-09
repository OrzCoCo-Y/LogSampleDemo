using Microsoft.EntityFrameworkCore;
using SampleDemo.Yzh.Net.Repository;

namespace SampleDemo.Yzh.Net.Service
{
    public class ValuesService(ILogger<ValuesService> logger, TestContext bloggingContext) : IValuesService
    {
        private readonly ILogger<ValuesService> _logger = logger;
        private readonly TestContext _bloggingContext = bloggingContext;

        public async Task<bool> UpdateSM()
        {
            _logger.LogInformation("OrzCoCo");
            var blogs = await _bloggingContext.TestEFTables.FirstOrDefaultAsync();
            if (blogs != null)
            {
                // blogs.Name = "11";
                blogs.LastModifiedAt = DateTimeOffset.Now;
                blogs.LastModifiedBy = -1400;

                await _bloggingContext.SaveChangesAsync();
            }
            return true;
        }
    }
}
