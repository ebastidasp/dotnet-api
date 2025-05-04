using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Register services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient<CatFactService>();
builder.Services.AddHttpClient<GiphyService>();
builder.Services.AddScoped<HistoryService>();
builder.Services.AddControllers();

var app = builder.Build();

// 2. Configure middleware
app.UseHttpsRedirection();
app.UseRouting();                // ← needed if you use UseAuthorization
app.UseCors("AllowAll");         // ← ensures CORS headers on all endpoints
app.UseAuthorization();          // ← if you have auth policies
app.MapControllers();

app.Run();
