// using QMAPP.BusinessLogic;

using QMAPP.src;
using QMAPP.Repositories;
using QMAPP.Services;
using QMAPP.Controllers;
using QMAPP.DTOs;
using QMAPP.Factory;

// QuantityMeasurementApp quantityMeasurementApp = new QuantityMeasurementApp();

// quantityMeasurementApp.QuantityMeasurmentMainMethod();




// QuantityMeasurementApp quantityMeasurementApp = new QuantityMeasurementApp();

// quantityMeasurementApp.Run();


var builder = WebApplication.CreateBuilder(args);

// IQuantityMeasurementRepository repo = new QuantityMeasurementCacheRepository();

// IQuantityMeasurementService service = new QuantityMeasurementServiceImpl(repo);

builder.Services.AddSingleton<IQuantityFactory, QuantityFactory>();
builder.Services.AddScoped<IQuantityMeasurementRepository, QuantityMeasurementCacheRepository>();
builder.Services.AddScoped<IQuantityMeasurementService, QuantityMeasurementServiceImpl>();

builder.Services.AddControllers();

// var dto1 = new QuantityDTO
// {
//     Value = 1,
//     Unit = "FEET",
//     MeasurementType = "LENGTH"
// };

// var dto2 = new QuantityDTO
// {
//     Value = 12,
//     Unit = "INCH",
//     MeasurementType = "LENGTH"
// };

// controller.PerformComparison(dto1, dto2);


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var service =
        scope.ServiceProvider
            .GetRequiredService<IQuantityMeasurementService>();

    var dto1 = new QuantityDTO
    {
        Value = 1,
        Unit = "FEET",
        MeasurementType = "LENGTH"
    };

    var dto2 = new QuantityDTO
    {
        Value = 12,
        Unit = "INCH",
        MeasurementType = "LENGTH"
    };

    bool result =
        service.Compare(dto1, dto2);

    Console.WriteLine(result);

    object add = service.Add(dto1, dto2);
    System.Console.WriteLine(add.ToString());

    object sub = service.Sub(dto1, dto2);
    System.Console.WriteLine(sub.ToString());

}

app.MapControllers();
app.Run();