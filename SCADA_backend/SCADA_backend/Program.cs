using Microsoft.EntityFrameworkCore;
using SCADA_backend;
using SCADA_backend.Repository;
using SCADA_backend.Service;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<TagService>();

builder.Services.AddTransient<UserRepository>();
builder.Services.AddTransient<TagRepository>();

builder.Services.AddDbContext<AppDbContext>();


var app = builder.Build();
app.MapControllers();
app.Run();

