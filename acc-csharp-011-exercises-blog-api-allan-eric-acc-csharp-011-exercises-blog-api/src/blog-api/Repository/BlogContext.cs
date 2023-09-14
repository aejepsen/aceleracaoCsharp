using Microsoft.EntityFrameworkCore;
using blog_api.Models;

namespace blog_api.Repository;

public class BlogContext : DbContext
{
  public DbSet<Post>? Posts { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=root;User=SA;Password=password123;");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Post>()
      .HasOne(o => o.Author)
      .WithMany(c => c.Posts)
      .HasForeignKey(o => o.AuthorId);
  }
}
