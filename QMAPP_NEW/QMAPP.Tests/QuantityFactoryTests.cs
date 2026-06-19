using NUnit.Framework;
using QMAPP.Factory;
using QMAPP.DTOs;
using QMAPP.src;
using System;

namespace QMAPP.Tests;

public class QuantityFactoryTests
{
    private QuantityFactory _factory;

    [SetUp]
    public void Setup()
    {
        _factory = new QuantityFactory();
    }

    [Test]
    public void GivenLengthDto_WhenCreated_ShouldReturnQuantityLength()
    {
        var dto = new QuantityDTO { MeasurementType = "LENGTH", Unit = "FEET", Value = 2.0 };
        var result = _factory.CreateQuantity(dto);

        Assert.That(result, Is.TypeOf<Quantity<LengthUnit>>());
        var quantity = (Quantity<LengthUnit>)result;
        Assert.That(quantity.Value, Is.EqualTo(2.0));
        Assert.That(quantity.Unit, Is.EqualTo(LengthUnit.FEET));
    }

    [Test]
    public void GivenWeightDto_WhenCreated_ShouldReturnQuantityWeight()
    {
        var dto = new QuantityDTO { MeasurementType = "WEIGHT", Unit = "KILOGRAM", Value = 5.0 };
        var result = _factory.CreateQuantity(dto);

        Assert.That(result, Is.TypeOf<Quantity<WeightUnit>>());
        var quantity = (Quantity<WeightUnit>)result;
        Assert.That(quantity.Value, Is.EqualTo(5.0));
        Assert.That(quantity.Unit, Is.EqualTo(WeightUnit.KILOGRAM));
    }

    [Test]
    public void GivenVolumeDto_WhenCreated_ShouldReturnQuantityVolume()
    {
        var dto = new QuantityDTO { MeasurementType = "VOLUME", Unit = "LITRE", Value = 1.0 };
        var result = _factory.CreateQuantity(dto);

        Assert.That(result, Is.TypeOf<Quantity<VolumeUnit>>());
        var quantity = (Quantity<VolumeUnit>)result;
        Assert.That(quantity.Value, Is.EqualTo(1.0));
        Assert.That(quantity.Unit, Is.EqualTo(VolumeUnit.LITRES)); 
    }

    [Test]
    public void GivenTemperatureDto_WhenCreated_ShouldReturnQuantityTemperature()
    {
        var dto = new QuantityDTO { MeasurementType = "TEMPERATURE", Unit = "CELSIUS", Value = 100.0 };
        var result = _factory.CreateQuantity(dto);

        Assert.That(result, Is.TypeOf<Quantity<TemperatureUnit>>());
        var quantity = (Quantity<TemperatureUnit>)result;
        Assert.That(quantity.Value, Is.EqualTo(100.0));
        Assert.That(quantity.Unit, Is.EqualTo(TemperatureUnit.CELSIUS));
    }

    [Test]
    public void GivenInvalidMeasurementType_WhenCreated_ShouldThrowException()
    {
        var dto = new QuantityDTO { MeasurementType = "INVALID", Unit = "FEET", Value = 2.0 };
        Assert.Throws<Exception>(() => _factory.CreateQuantity(dto));
    }
}
