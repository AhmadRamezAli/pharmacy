using Pharmacy.Domain.Repositories;
using Pharmacy.Infrastracture.DI;
using Pharmacy.Infrastracture.Repositories;
using Pharmacy.Adapters.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAdapters();
builder.Services.AddControllersWithViews();
var conncetionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddInfrastructure(conncetionString);



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
