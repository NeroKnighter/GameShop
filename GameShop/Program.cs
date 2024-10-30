using GameShop;
using GameShop.DAL;
using GameShop.Domain.Models;
using GameShop.Service.Implementations;
using GameShop.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;
using Repositories.Interfaces;
using Services.Implementations;
using Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connection));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();
builder.Services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
builder.Services.AddScoped<BaseRepository<User>, BaseRepository<User>>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddScoped<AccountService, AccountService>();
builder.Services.AddScoped<IBaseRepository<Game>, BaseRepository<Game>>();
builder.Services.AddScoped<BaseRepository<Game>, BaseRepository<Game>>();
builder.Services.AddScoped<IBaseRepository<Genre>, BaseRepository<Genre>>();
builder.Services.AddScoped<BaseRepository<Genre>, BaseRepository<Genre>>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<GameService, GameService>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
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
