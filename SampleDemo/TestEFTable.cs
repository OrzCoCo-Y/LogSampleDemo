using System.ComponentModel.DataAnnotations.Schema;

namespace SampleDemo
{
    [Table("TestEFTable")]
    public class TestEFTable
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTimeOffset? LastModifiedAt { get; set; }
        public int LastModifiedBy { get; set; }
    }
}
