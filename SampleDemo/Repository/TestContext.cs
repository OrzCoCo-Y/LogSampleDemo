using Microsoft.EntityFrameworkCore;

namespace SampleDemo.Yzh.Net.Repository
{
    public class TestContext(DbContextOptions<TestContext> options) : DbContext(options)
    {
        public DbSet<TestEFTable> TestEFTables { get; set; }

    }
}
