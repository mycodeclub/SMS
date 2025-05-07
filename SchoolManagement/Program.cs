using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models;
using SchoolManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add caching services
builder.Services.AddMemoryCache();
builder.Services.AddResponseCaching();
// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddSession();
builder.Services.AddDbContext<AppDbContext>(options =>
<<<<<<< HEAD
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConStr")));
=======
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConStrForAnkitMacDocker")));
>>>>>>> 3966949ed8e7296ae57a5dfa98cfc397a5cbc025
builder.Services.AddScoped<IUserServiceBAL, UserServiceBAL>();
builder.Services.AddScoped<ISessionYearService, SessionYearService>();
builder.Services.AddScoped<IStandardService, StandardService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddSingleton<ITempDataProvider, SessionStateTempDataProvider>();



builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 3;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();
app.UseSession();

// Enable response caching middleware
app.UseResponseCaching();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(name: "default", pattern: "{controller=Account}/{action=AutoLogin}/{id?}");

//.WithStaticAssets();


app.Run();
