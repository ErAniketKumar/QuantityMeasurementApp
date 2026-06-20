using NUnit.Framework;
using QMAPP.src;

namespace QMAPP.Tests;

public class TemperatureTests
{
    [Test]
    public void Given0CelsiusAnd32Fahrenheit_WhenCompared_ShouldReturnEqual()
    {
        var c = new Quantity<TemperatureUnit>(0.0, TemperatureUnit.CELSIUS);
        var f = new Quantity<TemperatureUnit>(32.0, TemperatureUnit.FAHRENHEIT);
        Assert.That(c, Is.EqualTo(f));
    }

    [Test]
    public void Given100CelsiusAnd212Fahrenheit_WhenCompared_ShouldReturnEqual()
    {
        var c = new Quantity<TemperatureUnit>(100.0, TemperatureUnit.CELSIUS);
        var f = new Quantity<TemperatureUnit>(212.0, TemperatureUnit.FAHRENHEIT);
        Assert.That(c, Is.EqualTo(f));
    }

    [Test]
    public void Given0CelsiusAnd273_15Kelvin_WhenCompared_ShouldReturnEqual()
    {
        var c = new Quantity<TemperatureUnit>(0.0, TemperatureUnit.CELSIUS);
        var k = new Quantity<TemperatureUnit>(273.15, TemperatureUnit.KELVIN);
        Assert.That(c, Is.EqualTo(k));
    }

    [Test]
    public void Given212FahrenheitAnd100Celsius_WhenCompared_ShouldReturnEqual()
    {
        var f = new Quantity<TemperatureUnit>(212.0, TemperatureUnit.FAHRENHEIT);
        var c = new Quantity<TemperatureUnit>(100.0, TemperatureUnit.CELSIUS);
        Assert.That(f, Is.EqualTo(c));
    }

    [Test]
    public void GivenTemperatures_WhenAdded_ShouldThrowInvalidOperationException()
    {
        var c1 = new Quantity<TemperatureUnit>(10.0, TemperatureUnit.CELSIUS);
        var c2 = new Quantity<TemperatureUnit>(10.0, TemperatureUnit.CELSIUS);
        
        Assert.Throws<InvalidOperationException>(() => c1.Add(c2));
    }
}
