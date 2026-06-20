namespace QMAPP.src;

public sealed class LengthUnit : IMeasurable
{
    private readonly double _factor;
    private readonly string _name;

    private LengthUnit(double factor, string name)
    {
        _factor = factor;
        _name = name;
    }

    public static readonly LengthUnit FEET =
        new LengthUnit(1.0, "FEET");

    public static readonly LengthUnit INCH =
        new LengthUnit(1.0 / 12.0, "INCH");

    public static readonly LengthUnit YARDS =
        new LengthUnit(3.0, "YARDS");

    public static readonly LengthUnit CENTIMETER =
        new LengthUnit(1.0 / 30.48, "CENTIMETER");

    public double ConvertToBaseUnit(double value)
    {
        return value * _factor;
    }

    public double ConvertFromBaseUnit(double value)
    {
        return value / _factor;
    }

    public bool SupportsArithmetic()
    {
        return true;
    }

    public void ValidateOperationSupport(
        ArithmeticOperation operation)
    {
        // nothing
    }

    public override string ToString()
    {
        return _name;
    }
}