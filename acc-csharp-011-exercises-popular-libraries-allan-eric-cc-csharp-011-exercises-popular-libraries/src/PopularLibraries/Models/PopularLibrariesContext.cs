using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PopularLibraries.Models
{
    public partial class PopularLibrariesContext : DbContext
    {
        public PopularLibrariesContext()
        {
        }

        public PopularLibrariesContext(DbContextOptions<PopularLibrariesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Database> Databases { get; set; } = null!;
        public virtual DbSet<Language> Languages { get; set; } = null!;
        public virtual DbSet<Orm> Orms { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
# warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=../PopularLibraries.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orm>(entity =>
            {
                entity.ToTable("ORMs");

                entity.HasIndex(e => e.LanguageId, "IX_ORMs_LanguageId");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Orms)
                    .HasForeignKey(d => d.LanguageId);
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasIndex(e => e.DatabaseId, "IX_Providers_DatabaseId");

                entity.HasIndex(e => e.Ormid, "IX_Providers_ORMId");

                entity.Property(e => e.Ormid).HasColumnName("ORMId");

                entity.HasOne(d => d.Database)
                    .WithMany(p => p.Providers)
                    .HasForeignKey(d => d.DatabaseId);

                entity.HasOne(d => d.Orm)
                    .WithMany(p => p.Providers)
                    .HasForeignKey(d => d.Ormid);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}