using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using QMAPP.Data;
using QMAPP.Factory;
using QMAPP.Repositories;
using QMAPP.Services;
using QMAPP_NEW.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ======================================
// Database
// ======================================

builder.Services.AddDbContext<QmDbContext>(
    options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString(
                "DefaultConnection")));

// ======================================
// Controllers
// ======================================

builder.Services.AddControllers();

// ======================================
// Dependency Injection
// ======================================

builder.Services.AddSingleton<
    IQuantityFactory,
    QuantityFactory>();

builder.Services.AddScoped<
    IQuantityMeasurementRepository,
    QuantityMeasurementDbeRepository>();

builder.Services.AddScoped<
    IQuantityMeasurementService,
    QuantityMeasurementServiceImpl>();

builder.Services.AddScoped<
    IUserRepository,
    UserRepository>();

builder.Services.AddScoped<
    IAuthService,
    AuthService>();

builder.Services.AddScoped<JwtService>();

// ======================================
// JWT Authentication
// ======================================

builder.Services
    .AddAuthentication(
        JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            builder.Configuration["Jwt:Key"]!
                        ))
            };
    });

builder.Services.AddSwaggerGen();


// ======================================
// Authorization
// ======================================

builder.Services.AddAuthorization();


// ======================================
// Build App
// ======================================

// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AngularPolicy", policy =>
//     {
//         policy
//             .WithOrigins(
//                 "http://localhost:4200",
//                 "https://qtymeasurment.vercel.app"
//             )
//             .AllowAnyHeader()
//             .AllowAnyMethod();
//     });
// });


builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularPolicy", policy =>
    {
        policy
            .SetIsOriginAllowed(origin => 
                origin.StartsWith("http://localhost:") || 
                origin.StartsWith("https://"))
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AngularPolicy");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

try
{
    // Replace the existing migration block in Program.cs with:
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<QmDbContext>();
    var retryCount = 10;
    while (retryCount > 0)
    {
        try
        {
            db.Database.Migrate();
            break;
        }
        catch (Exception ex)
        {
            retryCount--;
            if (retryCount == 0) throw;
            Console.WriteLine($"Waiting for database... ({ex.Message})");
            Thread.Sleep(5000);
        }
    }
} catch (Exception ex)
{
    Console.WriteLine($"Migration Error: {ex}");
}

app.Run();