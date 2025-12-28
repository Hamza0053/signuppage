using Microsoft.EntityFrameworkCore;
using signuppage.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Register AppDbContext with SQL Server connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Enable CORS if needed
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Middleware
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseCors();

app.MapControllers();

app.Run();
