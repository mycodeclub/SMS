using Microsoft.AspNetCore.Identity;
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
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConStr")));
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ISessionYearService, SessionYearService>();
builder.Services.AddScoped<IUserServiceBAL, UserServiceBAL>();



builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 3;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

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
