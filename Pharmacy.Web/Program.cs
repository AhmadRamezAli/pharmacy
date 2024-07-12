using Pharmacy.Domain.Repositories;
using Pharmacy.Infrastracture.DI;
using Pharmacy.Infrastracture.Repositories;
using Pharmacy.Adapters.DI;
using Pharmacy.Application.DI;
using Serilog;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Infrastracture.DataContext;
using System.Net;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.CodeAnalysis.Options;
using Pharmacy.SharedKernel.Service;
using Presentation.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAdapters();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddInfrastructure(connectionString);
builder.Services.AddSingleton<GlobalExceptionHandler>();


builder.Services.AddApplication();
builder.Services.AddControllersWithViews();
builder.Host.UseSerilog((context,loggerConfig)=>loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(
                options =>
                {
                    options.LoginPath = "/Access/Login";
                   // options.LogoutPath = "/Account/Logout";
                  //  options.AccessDeniedPath = "/Access/Login";
                }
);

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.LoginPath = "/Account/LogIn";
   //// options.LogoutPath = "/access/logout";
    //options.AccessDeniedPath = "/access/login";
    options.SlidingExpiration = true;
});

builder.Services.AddAuthorization();
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

app.UseAuthentication();
app.UseAuthorization();
//app.UseMiddleware<GlobalExceptionHandler>();

app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();  
