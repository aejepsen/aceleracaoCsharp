namespace blog_api.Test;

using Microsoft.EntityFrameworkCore;
using blog_api.Models;
using Microsoft.Extensions.DependencyInjection;

public class BlogTestContext : DbContext
{
  public DbSet<Post> Posts { get; set; } = default!;

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
        _ = new ServiceCollection()
      .AddEntityFrameworkInMemoryDatabase()
      .BuildServiceProvider();

    optionsBuilder.UseInMemoryDatabase("BlogTest");
    }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Post>()
      .HasOne(o => o.Author)
      .WithMany(c => c.Posts)
      .HasForeignKey(o => o.AuthorId);
  }
}