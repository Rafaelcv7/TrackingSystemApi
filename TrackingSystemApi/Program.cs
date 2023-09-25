using Microsoft.EntityFrameworkCore;
using TrackingSystemApi.Business;
using TrackingSystemApi.Business.Engines;
using TrackingSystemApi.Business.Engines.Contracts;
using TrackingSystemApi.Core.Contracts;
using TrackingSystemApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseInMemoryDatabase("IndividualTracking"));
builder.Services.AddTransient<IBusinessEngineFactory, BusinessEngineFactory>();
builder.Services.AddTransient<IIndividualsEngine, IndividualsEngine>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

