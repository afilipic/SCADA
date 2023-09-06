using Microsoft.EntityFrameworkCore;
using SCADA_backend;
using SCADA_backend.Hubs;
using SCADA_backend.Repository;
using SCADA_backend.Service;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<TagService>();
builder.Services.AddTransient<AlarmService>();

builder.Services.AddTransient<UserRepository>();
builder.Services.AddTransient<TagRepository>();

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddSignalR();

var app = builder.Build();
app.UseCors(corsPolicyBuilder =>
    corsPolicyBuilder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
);

app.MapHub<AlarmHub>("/alarms");
app.MapHub<TagHub>("/tag");

app.MapControllers();
app.Run();

