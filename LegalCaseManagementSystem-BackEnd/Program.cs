using api.Data;
using LegalCaseManagementSystem_BackEnd.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<LawyerService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<CaseService>();
builder.Services.AddScoped<CaseTaskService>();
builder.Services.AddScoped<DocumentService>();
builder.Services.AddScoped<HearingService>();
builder.Services.AddScoped<InvoiceService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
