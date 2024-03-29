using Aiport_App_Structure.Models;
using Airport_App_Core.Contracts;
using Airport_App_Core.Services;
using Airport_App_Structure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AirportDb>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddDefaultIdentity<User>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.SignIn.RequireConfirmedAccount = false;
    
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AirportDb>();
builder.Services.AddControllersWithViews();



builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFlightsService, FlightService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IAirportService, AirportService>();
builder.Services.AddScoped<IAirplaneService, AirplaneService>();
builder.Services.AddScoped<IManufacturerServce, ManufacturerServce>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IPassengerService, PassengerService>();


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminsOnly", policy => policy.RequireRole("Admin"));
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("User", policy => policy.RequireRole("User"));
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/User/Login";


});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"

    );
});


app.MapRazorPages();

app.Run();
