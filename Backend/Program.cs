using Backend.Hubs;
using Microsoft.EntityFrameworkCore;
using Backend.Data.DAO;

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

// Add services


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