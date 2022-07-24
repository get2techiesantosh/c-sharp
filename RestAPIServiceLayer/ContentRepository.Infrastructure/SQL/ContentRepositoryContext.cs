using System;
using System.Collections.Generic;
using ContentRepository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace ContentRepository.Infrastructure
{
    public partial class ContentRepositoryContext : DbContext
    {
        private string _connectionString = "";
        public ContentRepositoryContext()
        {
        }

        public ContentRepositoryContext(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public ContentRepositoryContext(DbContextOptions<ContentRepositoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Post> Posts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                //optionsBuilder.UseSqlServer("Data Source=LT-SINGHS;Initial Catalog=SantoshDb;User Id=sa;Password=welcome@123;");
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Post");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
