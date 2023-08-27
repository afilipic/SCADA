using Microsoft.EntityFrameworkCore;
using SCADA_backend;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddControllers();

var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.MapGet("/db", async (AppDbContext context) => 
{
    await context.Database.OpenConnectionAsync();
    return "Database connection successful!";
});
app.MapControllers();
app.Run();

