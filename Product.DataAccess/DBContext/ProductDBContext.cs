using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Product.Contracts.Models;

namespace Product.DataAccess.DBContext
{
    public partial class ProductDBContext : DbContext
    {
        public ProductDBContext()
        {
        }

        public ProductDBContext(DbContextOptions<ProductDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<SubCategory> SubCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.SubCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Item__SubCategor__412EB0B6");
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SubCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubCatego__Categ__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
