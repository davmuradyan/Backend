using Backend.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSignalR();
builder.Services.AddSwaggerGen();

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
builder.WebHost.ConfigureKestrel(serverOptions => {
    serverOptions.ListenAnyIP(8080, listenOptions => listenOptions.UseHttps()); // HTTPS
    serverOptions.ListenAnyIP(5000); // HTTP (for testing)
});

var app = builder.Build();

// Enable Swagger for both Development & Production (optional)
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Use CORS before Authorization
app.UseCors("CorsPolicy");

app.UseAuthorization();

// Map Controllers and SignalR Hub
app.MapControllers();
app.MapHub<ConnectionUserHub>("/Hub");

app.Run();