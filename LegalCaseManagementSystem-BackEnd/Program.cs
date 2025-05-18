using api.Data;
using LegalCaseManagementSystem_BackEnd.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Configuration
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secret = jwtSettings["Secret"] ?? throw new ArgumentNullException("JWT Secret is missing");

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS Configuration (Updated)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(
                "https://localhost:7285"  // Blazor Server
              )
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();  // Required for cookies/auth
    });
});

// Database
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Authentication (Updated)
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
            ClockSkew = TimeSpan.Zero 
        };
    });

// Services Registration
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<LawyerService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<CaseService>();
builder.Services.AddScoped<CaseTaskService>();
builder.Services.AddScoped<DocumentService>();
builder.Services.AddScoped<HearingService>();
builder.Services.AddScoped<InvoiceService>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<AuthService>();
var webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
if (!Directory.Exists(webRoot))
{
    Directory.CreateDirectory(webRoot);
}
builder.WebHost.UseWebRoot("wwwroot");

var app = builder.Build();

// Pipeline Configuration
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseHttpsRedirection();

// Critical Middleware Order
app.UseRouting();
app.UseCors("AllowFrontend"); 
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();