using Microsoft.EntityFrameworkCore;
using Server.Data; // if you have a DbContext

var builder = WebApplication.CreateBuilder(args);

// API only (no Razor views needed)
builder.Services.AddControllers();

// Optional: Swagger to test your API quickly
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext for EF Core
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Serve static files produced by your React build
app.UseStaticFiles();

// Route attribute-routed API controllers (e.g., [Route("api/[controller]")])
app.MapControllers();

// For any non-API route, serve the SPA entry. Make sure your React build
// outputs `index.html` into wwwroot.
app.MapFallbackToFile("index.html");

app.Run();
