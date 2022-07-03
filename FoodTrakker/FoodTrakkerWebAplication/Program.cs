using FoodTrakker_WebBusinessLogic;
using FoodTrakker_WebBusinessLogic.Model;
using FoodTrakker_WebBusinessLogic.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FoodTrakkerWebAplication.Data;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FoodTrakkerWebAplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FoodTrakkerWebAplicationContext") ?? throw new InvalidOperationException("Connection string 'FoodTrakkerWebAplicationContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddSingleton<IRepository<User>, UserRepository>();
builder.Services.AddSingleton<IRepository<Event>, EventRepository>();
builder.Services.AddSingleton<IRepository<FoodTruck>, FoodTruckRepository>();

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
