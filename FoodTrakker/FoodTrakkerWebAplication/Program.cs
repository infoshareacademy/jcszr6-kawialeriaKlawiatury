using FoodTrakker.Core.Model;
using FoodTrakker.Repository;
using FoodTrakker.Repository.Contracts;
using FoodTrakker.Repository.Data;
using FoodTrakker.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FoodTrakker.Services.IdentityServices;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddRazorPages();

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(builder.Configuration));

builder.Services.AddScoped<FoodTruckService>();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<ReviewService>();
builder.Services.AddScoped<FavouritesFoodTruckService>();
builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<TypeService>();

var option = builder.Configuration.GetConnectionString("FoodTrakkerDb");
builder.Services.AddDbContext<FoodTrakkerContext>(options =>
  { options.UseSqlServer(builder.Configuration.GetConnectionString("FoodTrakkerDb"));
      options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    });

builder.Services.AddDefaultIdentity<User>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 7;
    options.Password.RequireUppercase = true;
    options.SignIn.RequireConfirmedAccount = true;

    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 3;
   
    options.User.RequireUniqueEmail = true;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<FoodTrakkerContext>()
    .AddPasswordValidator<PasswordValidatorService>();

builder.Services.AddScoped<IRepository<User, string>, UserRepository>();
builder.Services.AddScoped<IRepository<Event, int>, EventRepository>();
builder.Services.AddScoped<IFoodTruckRepository, FoodTruckRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ITypeRepository, TypeRepository>();


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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
