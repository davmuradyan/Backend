using Backend.Hubs;
using Microsoft.EntityFrameworkCore;
using Backend.Data.DAO;
using Backend.Core.Services.GpsRelated.GNSSSystemServices;
using Backend.Core.Services.GpsRelated.GpsModelGNSSServices;
using Backend.Core.Services.GpsRelated.GPSModelServices;
using Backend.Core.Services.GpsRelated.GPSServices;

using Backend.Core.Services.LocationRelated.CityServices;
using Backend.Core.Services.LocationRelated.CountryServices;
using Backend.Core.Services.LocationRelated.RegionServices;

using Backend.Core.Services.PersonRelated.AdminServices;
using Backend.Core.Services.PersonRelated.UserFeedbackServices;
using Backend.Core.Services.PersonRelated.UserServices;
using Backend.Core.Services.PersonRelated.DriverServices.Driver;
using Backend.Core.Services.PersonRelated.DriverServices.Licence;

using Backend.Core.Services.RouteRelated.EdgeServices;
using Backend.Core.Services.RouteRelated.RouteEdgeServices;
using Backend.Core.Services.RouteRelated.RouteServices;
using Backend.Core.Services.RouteRelated.StopServices;
using Backend.Core.Services.RouteRelated.TripServices;

using Backend.Core.Services.VehicleRelated.ManufacturerServices;
using Backend.Core.Services.VehicleRelated.VehicleServices;
using Backend.Core.Services.VehicleRelated.VehicleTypeServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSignalR();
builder.Services.AddSingleton<BusLocationService>();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Add DbContext with SQL Server connection
builder.Services.AddDbContext<MainDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MainConnectionString")));

// Add services //
// GPS related ////////////////////////////////////////////////////////////
builder.Services.AddScoped<IGNSSSystemService, GNSSSystemService>();
builder.Services.AddScoped<IGpsModelGNSSService, GpsModelGNSSService>();
builder.Services.AddScoped<IGPSModelService, GPSModelService>();
builder.Services.AddScoped<IGPSService, GPSService>();

// Location related /////////////////////////////////////////////
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IRegionService, RegionService>();
builder.Services.AddScoped<ICountryService, CountryService>();

// Person related ///////////////////////////////////////////////
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserFeedbackService, UserFeedbackService>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<ILicenceService, LicenceService>();

// Route related ////////////////////////////////////////////////
builder.Services.AddScoped<IEdgeService, EdgeService>();
builder.Services.AddScoped<IRouteEdgeService, IRouteEdgeService>();
builder.Services.AddScoped<IRouteService, IRouteService>();
builder.Services.AddScoped<IStopService, IStopService>();
builder.Services.AddScoped<ITripService, ITripService>();

// Vehicle related //////////////////////////////////////////////
builder.Services.AddScoped<IManufacturerService, IManufacturerService>();
builder.Services.AddScoped<IVehicleService, IVehicleService>();
builder.Services.AddScoped<IVehicleTypeService, IVehicleTypeService>();

//////////////////////////////////////////////////////////////////////////////

// Configure CORS to allow requests from any origin
builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy",
        policy => {
            policy.AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials()
                  .SetIsOriginAllowed(_ => true); // Allow all origins for development
        });
});

// Explicitly configure Kestrel to listen on all network interfaces
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080"; // Default to 8080 for Azure
builder.WebHost.UseUrls($"http://*:{port}");

var app = builder.Build();

// Force initialization of BusLocationService
var busLocationService = app.Services.GetRequiredService<BusLocationService>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS before Authorization
app.UseCors("CorsPolicy");
app.UseCors("AllowLocalhost");
app.UseAuthorization();

// Map Controllers and SignalR Hub
app.MapControllers();
app.MapHub<UserHub>("/UserHub");
app.MapHub<AdminHub>("/AdminHub");

app.Run();