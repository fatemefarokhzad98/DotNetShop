
using App.Domain.AppServices.BaseData;
using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Services.BaseData;
using App.Infrastructure.DataBase.Data;
using App.Infrastructure.Repository.Ef.BaseData;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(option =>
{

    option.UseSqlServer("Data Source=DESKTOP-CGR2LP5\\MSSQLSERVER2022;Initial Catalog=DotNetShopDb; Encrypt=False; TrustServerCertificate=True;Integrated Security=true");
});
//brand

builder.Services.AddScoped<IBrandAppService, BrandAppService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ISurenessService, BrandSurenessService>();
builder.Services.AddScoped<IBrandCommandRepository, BrandCommandRepository>();
builder.Services.AddScoped<IBrandQueryRepository, BrandQueryRepository>();
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped <IColorAppService, ColorAppService>();
builder.Services.AddScoped < IColorService, ColorService>();
builder.Services.AddScoped<IColorCommandRepository, ColorCommandRepository>();
builder.Services.AddScoped<IColorQueryRepository, ColorQueryRepository>();
builder.Services.AddScoped<ISurenessService, ColorSurenessService>();

builder.Services.AddScoped<IModelAppService, ModelAppService>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<IModelCommandRepository, ModelCommandRepository>();
builder.Services.AddScoped<IModelQueryRepository, ModelQueryRepository>();
builder.Services.AddScoped<ISurenessService, ModelSurenessService>();
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
builder.Services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
builder.Services.AddScoped<ISurenessService, CategorySurenessService>();
builder.Services.AddScoped<ICollectionAppService, CollectionAppService>();
builder.Services.AddScoped<ICollectionService, CollectionService>();
builder.Services.AddScoped<ICollectionCommandRepository, CollectionCommandRepository>();
builder.Services.AddScoped<ICollectionQueryRepository, CollectionQueryRepository>();
builder.Services.AddScoped<ISurenessService, CollectionSurenessService>();







var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
