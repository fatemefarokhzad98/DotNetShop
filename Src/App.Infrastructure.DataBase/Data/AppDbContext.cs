using System;
using System.Collections.Generic;

using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Comment.Entities;
using App.Domain.Core.Product.Entities;
using ColorEntities = App.Domain.Core.BaseData.Entities;

using Microsoft.EntityFrameworkCore;

using App.Domain.Core.User.Entities;

namespace App.Infrastructure.DataBase.Data;

public partial class AppDbContext : DbContext
{
   
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Collection> Collections { get; set; }

    public virtual DbSet<CollectionProduct> CollectionProducts { get; set; }

    public virtual DbSet<ColorEntities.Color> Colors { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<CommentImpression> CommentImpressions { get; set; }

    public virtual DbSet<ImpressionType> ImpressionTypes { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductColor> ProductColors { get; set; }

    public virtual DbSet<ProductFile> ProductFiles { get; set; }

    public virtual DbSet<ProductTag> ProductTags { get; set; }

    public virtual DbSet<ProductView> ProductViews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<TagCategory> TagCategories { get; set; }

    public virtual DbSet<TypeFile> TypeFiles { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Brands__3214EC07D5C50981");

            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<Collection>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<CollectionProduct>(entity =>
        {
            entity.HasOne(d => d.Collection).WithMany(p => p.CollectionProducts)
                .HasForeignKey(d => d.CollectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CollectionProducts_Collections");

            entity.HasOne(d => d.Product).WithMany(p => p.CollectionProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CollectionProducts_Products");
        });

        modelBuilder.Entity<ColorEntities.Color>(entity =>
        {
            entity.Property(e => e.ColorCode).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.Property(e => e.TextComment).HasMaxLength(1500);
            entity.Property(e => e.Title)
                .HasMaxLength(300)
                .IsFixedLength();

            entity.HasOne(d => d.Product).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Products");

            entity.HasOne(d => d.Status).WithMany(p => p.Comments)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Statuses");

            entity.HasOne(d => d.SubmitUser).WithMany(p => p.Comments)
                .HasForeignKey(d => d.SubmitUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Users");
        });

        modelBuilder.Entity<CommentImpression>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CommentI__3214EC07A9D6DC18");

            entity.HasOne(d => d.Comment).WithMany(p => p.CommentImpressions)
                .HasForeignKey(d => d.CommentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CommentImpressions_Comments");

            entity.HasOne(d => d.ImpressionType).WithMany(p => p.CommentImpressions)
                .HasForeignKey(d => d.ImpressionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CommentImpressions_ImpressionTypes");

            entity.HasOne(d => d.SubmmitUser).WithMany(p => p.CommentImpressions)
                .HasForeignKey(d => d.SubmmitUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CommentImpressions_Users");
        });

        modelBuilder.Entity<ImpressionType>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(200);

            entity.HasOne(d => d.Brand).WithMany(p => p.Models)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Models_Brands");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(300);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Brands");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Categories");

            entity.HasOne(d => d.Model).WithMany(p => p.Products)
                .HasForeignKey(d => d.ModelId)
                .HasConstraintName("FK_Products_Models");

            entity.HasOne(d => d.Status).WithMany(p => p.Products)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Statuses");

            entity.HasOne(d => d.SubmitOperator).WithMany(p => p.Products)
                .HasForeignKey(d => d.SubmitOperatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Users");
        });

        modelBuilder.Entity<ProductColor>(entity =>
        {
            entity.Property(e => e.Isexit).HasColumnName("ISExit");

            entity.HasOne(d => d.Color).WithMany(p => p.ProductColors)
                .HasForeignKey(d => d.ColorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductColors_Colors");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductColors)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductColors_Products");
        });

        modelBuilder.Entity<ProductFile>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(150);

            entity.HasOne(d => d.FileType).WithMany(p => p.ProductFiles)
                .HasForeignKey(d => d.FileTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductFiles_TypeFiles");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductFiles)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductFiles_Products");
        });

        modelBuilder.Entity<ProductTag>(entity =>
        {
            entity.Property(e => e.Value).HasMaxLength(500);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductTags)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductTags_Products");

            entity.HasOne(d => d.Tag).WithMany(p => p.ProductTags)
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductTags_Tags");
        });

        modelBuilder.Entity<ProductView>(entity =>
        {
            entity.HasOne(d => d.Product).WithMany(p => p.ProductViews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductViews_Products");

            entity.HasOne(d => d.ViewerUser).WithMany(p => p.ProductViews)
                .HasForeignKey(d => d.ViewerUserId)
                .HasConstraintName("FK_ProductViews_Users");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.Property(e => e.Title).HasMaxLength(150);
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(200);

            entity.HasOne(d => d.TagCategory).WithMany(p => p.Tags)
                .HasForeignKey(d => d.TagCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tags_TagCategories");
        });

        modelBuilder.Entity<TagCategory>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<TypeFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_FileTypes");

            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.ValidExtentions).HasMaxLength(150);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FirstName).HasMaxLength(150);
            entity.Property(e => e.LastName).HasMaxLength(150);
            entity.Property(e => e.Mobile)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.PassWord).HasMaxLength(150);
            entity.Property(e => e.UserName).HasMaxLength(150);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");

            entity.HasOne(d => d.Status).WithMany(p => p.Users)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Statuses");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
