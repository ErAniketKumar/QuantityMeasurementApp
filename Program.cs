// using QMAPP.BusinessLogic;

using QMAPP.src;
using QMAPP.Repositories;
using QMAPP.Services;
using QMAPP.Controllers;
using QMAPP.DTOs;
using QMAPP.Factory;
using QMAPP.Data;
using Microsoft.EntityFrameworkCore;

var builder =WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<QmDbContext>(
    options =>
    options.UseSqlServer(
        builder.Configuration
            .GetConnectionString(
                "DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<
    IQuantityFactory,
    QuantityFactory>();

builder.Services.AddScoped<
    IQuantityMeasurementRepository,
    QuantityMeasurementDbeRepository>();

builder.Services.AddScoped<
    IQuantityMeasurementService,
    QuantityMeasurementServiceImpl>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

app.Run();