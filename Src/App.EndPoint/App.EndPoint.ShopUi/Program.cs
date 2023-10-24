using App.Domain.AppServices.BaseData;
using App.Domain.AppServices.Product;
using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.Identity;
using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.Services;

using App.Domain.Services.BaseData;
using App.Domain.Services.Product;
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


builder.Services.AddIdentity<IdentityUser<int>,AppRole>(
    options=>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.SignIn.RequireConfirmedPhoneNumber= false;
        options.SignIn.RequireConfirmedEmail= false;
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredUniqueChars = 1;
        options.Password.RequiredLength = 3;
        //options.User.AllowedUserNameCharacters
        //options.User.RequireUniqueEmail
        

      
      


    })
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<IBrandAppService, BrandAppService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IBrandSurnessService, BrandSurenessService>();
builder.Services.AddScoped<IBrandCommandRepository, BrandCommandRepository>();
builder.Services.AddScoped<IBrandQueryRepository, BrandQueryRepository>();
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<IColorAppService, ColorAppService>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<IColorCommandRepository, ColorCommandRepository>();
builder.Services.AddScoped<IColorQueryRepository, ColorQueryRepository>();
builder.Services.AddScoped<IColorSurnessService, ColorSurenessService>();

builder.Services.AddScoped<IModelAppService, ModelAppService>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<IModelCommandRepository, ModelCommandRepository>();
builder.Services.AddScoped<IModelQueryRepository, ModelQueryRepository>();
builder.Services.AddScoped<IModelSurnessService, ModelSurenessService>();
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
builder.Services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
builder.Services.AddScoped<ICategorySurnessService, CategorySurenessService>();
builder.Services.AddScoped<ICollectionAppService, CollectionAppService>();
builder.Services.AddScoped<ICollectionService, CollectionService>();
builder.Services.AddScoped<ICollectionCommandRepository, CollectionCommandRepository>();
builder.Services.AddScoped<ICollectionQueryRepository, CollectionQueryRepository>();
builder.Services.AddScoped<IColletionSurnessService, CollectionSurenessService>();
builder.Services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
builder.Services.AddScoped<IProductQueryRepository, ProductQueryRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductSurnessService, ProductSurnessService>();
builder.Services.AddScoped<IProductAppService, ProductAppService>();
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


app.UseEndpoints(endpoints=>
{

    endpoints.MapDefaultControllerRoute();

    endpoints.MapControllerRoute(
        name: "areaRoute",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");



    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{contoller=Home}/{action=Index}/{id?}"
      );


    

  
   

  
});





app.Run();
