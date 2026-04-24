using Microsoft.EntityFrameworkCore;
using myapiproject.Data;
 
var builder = WebApplication.CreateBuilder(args);
 
// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
// ✅ ONLY ONE DbContext (correct way)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
 
var app = builder.Build();
 
// Configure middleware
app.UseSwagger();
app.UseSwaggerUI();
 
app.MapControllers();
 
app.Run();