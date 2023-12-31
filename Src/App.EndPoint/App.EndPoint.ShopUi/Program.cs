using App.Domain.AppServices.BaseData;
using App.Domain.AppServices.Product;
using App.Domain.AppServices.User;
using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;

using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Core.User.Contracts.AppServices;
using App.Domain.Core.User.Entities;
using App.Domain.Services.BaseData;
using App.Domain.Services.Product;
using App.EndPoint.ShopUi.Services;
using App.Infrastructure.DataBase.Data;
using App.Infrastructure.Repository.Ef.BaseData;
using App.Infrastructure.Repository.Ef.Product;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Acount/Logout";

}); 

// Add services to the container.
builder.Services.AddControllersWithViews();
//.AddRazorRuntimeCompilation();

builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(option =>
{

    option.UseSqlServer("Data Source=DESKTOP-CGR2LP5\\MSSQLSERVER2022;Initial Catalog=DotNetShopDb; Encrypt=False; TrustServerCertificate=True;Integrated Security=true");
});

#region Identity
builder.Services.AddIdentity<AppUser, AppRole>(
    options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.SignIn.RequireConfirmedPhoneNumber = false;
        options.SignIn.RequireConfirmedEmail = false;
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredUniqueChars = 1;
        options.Password.RequiredLength = 7;
        options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        options.User.RequireUniqueEmail = true;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);
        options.Lockout.MaxFailedAccessAttempts = 3;
        
    })
 
    .AddEntityFrameworkStores<AppDbContext>();
     



#endregion

builder.Services.AddScoped<AppDbContext>();
#region Brand
builder.Services.AddScoped<IBrandAppService, BrandAppService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IBrandSurnessService, BrandSurenessService>();
builder.Services.AddScoped<IBrandCommandRepository, BrandCommandRepository>();
builder.Services.AddScoped<IBrandQueryRepository, BrandQueryRepository>();
#endregion 
#region Color
builder.Services.AddScoped<IColorAppService, ColorAppService>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<IColorCommandRepository, ColorCommandRepository>();
builder.Services.AddScoped<IColorQueryRepository, ColorQueryRepository>();
builder.Services.AddScoped<IColorSurnessService, ColorSurenessService>();
#endregion
#region Model
builder.Services.AddScoped<IModelAppService, ModelAppService>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<IModelCommandRepository, ModelCommandRepository>();
builder.Services.AddScoped<IModelQueryRepository, ModelQueryRepository>();
builder.Services.AddScoped<IModelSurnessService, ModelSurenessService>();
#endregion
#region Category
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
builder.Services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
builder.Services.AddScoped<ICategorySurnessService, CategorySurenessService>();
#endregion
#region Collection
builder.Services.AddScoped<ICollectionAppService, CollectionAppService>();
builder.Services.AddScoped<ICollectionService, CollectionService>();
builder.Services.AddScoped<ICollectionCommandRepository, CollectionCommandRepository>();
builder.Services.AddScoped<ICollectionQueryRepository, CollectionQueryRepository>();
builder.Services.AddScoped<IColletionSurnessService, CollectionSurenessService>();
#endregion
#region Product
builder.Services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
builder.Services.AddScoped<IProductQueryRepository, ProductQueryRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductSurnessService, ProductSurnessService>();
builder.Services.AddScoped<IProductAppService, ProductAppService>();
#endregion
#region Tag
//builder.Services.AddScoped<ITagCommandRepository , TagCommandRepository>();
//builder.Services.AddScoped<ITagQueryRepository,TagQueryRepository>();
//builder.Services.AddScoped<ITagService, TagService>();
//builder.Services.AddScoped<ITagSurnessService, TagSurnessService>();
//builder.Services.AddScoped<ITagAppService, TagAppService>();
#endregion
#region TagCategory
//builder.Services.AddScoped<ITagCategoryCommandRepository, TagCategoryCommandRepository>();
//builder.Services.AddScoped<ITagCategoryQueryRepository, TagCategoryQueryRepository>();
//builder.Services.AddScoped<ITagCategoryService, TagCategoryService>();
//builder.Services.AddScoped<ITagCategorySurnessService, TagCategorySurnessService>();
//builder.Services.AddScoped<ITagCategoryAppService, TagCategoryAppService>();
#endregion
#region Status
builder.Services.AddScoped<IStatusCommandRepository, StatusCommandRepository>();
builder.Services.AddScoped<IStatusQueryRepository, StatusQueryRepository>();
builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddScoped<IStatusSurnessService, StatusSurnessService>();
builder.Services.AddScoped<IStatusAppService, StatusAppService>();
#endregion
#region Order
builder.Services.AddScoped<IOrderCommandRepository, OrderCommandRepository>();
builder.Services.AddScoped<IOrderQueryRepository, OrderQueryRepository>();
builder.Services.AddScoped<IOrderSurnessService, OrderSurnessService>();
builder.Services.AddScoped<IOrderAppService, OrderAppService>();
builder.Services.AddScoped<IOrderService, OrderService>();

#endregion
#region OrderDetail
builder.Services.AddScoped<IOrderDetailCommandRepository, OrderDetailCommandRepository>();
builder.Services.AddScoped<IOrderDetailAppService, OrderDetailAppService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();

#endregion
#region ProductCollection
builder.Services.AddScoped<IProductCollectionQueryRepository, ProductCollectionQueryRepository>();
builder.Services.AddScoped<IProductCollectionAppService, ProductCollectionAppService>();
 builder.Services.AddScoped<IProductCollectionService, ProductCollectionService>();
#endregion

builder.Services.AddScoped<IAppRoleManager, AppRoleManager>();
builder.Services.AddScoped<IAppUserManager, AppUserManager>();



builder.Services.AddScoped<AppErrorDescriber>();
builder.Services.AddScoped<SignInManager<AppUser>>();
builder.Services.AddScoped<IConverting,Converting>();


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
app.UseAuthentication();

app.UseAuthorization();


app.MapAreaControllerRoute(
    areaName: "Admin",
    name: "Areas",
    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
