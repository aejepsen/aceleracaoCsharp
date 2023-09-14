using Microsoft.EntityFrameworkCore;

namespace student_validation.Models;

public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options) {}

    public SchoolContext() {}

    public DbSet<Student> Students { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseInMemoryDatabase("StudentDb");
        }
    }
}
