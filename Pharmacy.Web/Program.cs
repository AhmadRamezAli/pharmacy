using Pharmacy.Domain.Repositories;
using Pharmacy.Infrastracture.DI;
using Pharmacy.Infrastracture.Repositories;
using Pharmacy.Adapters.DI;
using Pharmacy.Application.DI;
using Serilog;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Infrastracture.DataContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAdapters();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");




builder.Services.AddInfrastructure(connectionString);
builder.Services.AddApplication();
builder.Services.AddControllersWithViews();
builder.Host.UseSerilog((context,loggerConfig)=>loggerConfig.ReadFrom.Configuration(context.Configuration));

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
