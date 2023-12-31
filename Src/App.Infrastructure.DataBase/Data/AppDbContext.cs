﻿using System;
using System.Collections.Generic;

using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Comment.Entities;
using App.Domain.Core.Product.Entities;
using ProductColorEntities = App.Domain.Core.Product.Entities;
using ColorEntities = App.Domain.Core.BaseData.Entities;
using StatusEntities = App.Domain.Core.BaseData.Entities;

using Microsoft.EntityFrameworkCore;

using App.Domain.Core.User.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using App.Infrastructure.DataBase.Configurations;

namespace App.Infrastructure.DataBase.Data;

public partial class AppDbContext : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>, AppRoleUser, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
{

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brand { get; set; }

    public virtual DbSet<Category> Category { get; set; }

    public virtual DbSet<Collection> Collection { get; set; }
    public virtual DbSet<ProductCollection> ProductCollection { get; set; }

    public virtual DbSet<Color> Color { get; set; }

    public virtual DbSet<Comment> Comment { get; set; }

    public virtual DbSet<CommentImpression> CommentImpression { get; set; }

    public virtual DbSet<ImpressionType> ImpressionType { get; set; }

    public virtual DbSet<Model> Model { get; set; }

    public virtual DbSet<Product> Product { get; set; }

    public virtual DbSet<ProductColor> ProductColor { get; set; }

   public virtual DbSet<Status> Status { get; set; }

    public virtual DbSet<AppRole> AppRole { get; set; }
    public virtual DbSet<AppUser> AppUser { get; set; }
    public virtual DbSet<AppRoleUser>  AppRoleUser { get; set; }

    public virtual DbSet<Order> Order{ get; set; }
    public virtual DbSet<OrderDetail> OrderDetail{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ColorConfig).Assembly);


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    
}

   
