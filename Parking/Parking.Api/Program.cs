using Microsoft.EntityFrameworkCore;
using Parking.Api.Middleware;
using Parking.Infrastructure.DataContext;
using Parking.Infrastructure.Extensions;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.Load("Parking.Application")));
builder.Services.AddAutoMapper(Assembly.Load("Parking.Application"));

builder.Services.AddDbContext<IntegracionDbContext>(options => options.UseSqlServer(
    config.GetConnectionString("ParkingDatabase"),
    sqlServerOptions => { sqlServerOptions.CommandTimeout(60); sqlServerOptions.MigrationsHistoryTable("MigrationHistory"); }
));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDomainServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<AppExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();
