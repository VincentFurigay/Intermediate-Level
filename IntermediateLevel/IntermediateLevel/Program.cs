using IntermediateLevel.Contract;
using IntermediateLevel.Data;
using IntermediateLevel.Repository;
using IntermediateLevel.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CalculatorContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddControllers();

builder.Services.AddScoped<ITimeAttendanceRepository, TimeAttendanceRepository>();
builder.Services.AddScoped<IPayregRepository, PayregRepository>();
builder.Services.AddScoped<IOvertimeCalculationService, OvertimeCalculationService>();


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
