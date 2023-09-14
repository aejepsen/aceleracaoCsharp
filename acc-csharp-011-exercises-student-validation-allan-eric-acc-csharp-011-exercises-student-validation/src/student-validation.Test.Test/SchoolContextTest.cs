using Microsoft.EntityFrameworkCore;
using student_validation.Models;

namespace student_validation.Test.Test;

public class SchoolContextTest : DbContext
{
    public SchoolContextTest(DbContextOptions<SchoolContextTest> options)
        : base(options) {}

    public SchoolContextTest() {}

    public DbSet<Student> Students { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseInMemoryDatabase("StudentDb");
        }
    }
}
