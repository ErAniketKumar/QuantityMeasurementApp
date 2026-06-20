namespace QMAPP.src;

public sealed class TemperatureUnit : IMeasurable
{
    private readonly string _name;

    private TemperatureUnit(string name)
    {
        this._name = name;
    }

    public static readonly TemperatureUnit CELSIUS =
         new TemperatureUnit("CELSIUS");
    public static readonly TemperatureUnit FAHRENHEIT =
        new TemperatureUnit("FAHRENHEIT");
    public static readonly TemperatureUnit KELVIN =
    new TemperatureUnit("KELVIN");

    public double ConvertToBaseUnit(double value)
    {
        if (this == CELSIUS)
            return value;

        if (this == FAHRENHEIT)
            return (value - 32) * 5 / 9;

        if (this == KELVIN)
            return value - 273.15;

        throw new InvalidOperationException();
    }

    public double ConvertFromBaseUnit(double value)
    {
        if (this == CELSIUS)
            return value;

        if (this == FAHRENHEIT)
            return (value * 9 / 5) + 32;

        if (this == KELVIN)
            return value + 273.15;

        throw new InvalidOperationException();
    }
    public bool SupportsArithmetic()
    {
        return false;
    }

    public override string ToString()
    {
        return _name;
    }

    public void ValidateOperationSupport(ArithmeticOperation operation)
    {
        throw new InvalidOperationException(
            $"Temperature does not support {operation}"
        );
    }

}