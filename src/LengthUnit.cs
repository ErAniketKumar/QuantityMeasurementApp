namespace QMAPP.src;

public sealed class LengthUnit : IMeasurable
{
    private readonly double _factor;

    private LengthUnit(double factor)
    {
        _factor = factor;
    }

    public static readonly LengthUnit FEET =
        new LengthUnit(1.0);

    public static readonly LengthUnit INCH =
        new LengthUnit(1.0 / 12.0);

    public static readonly LengthUnit YARDS =
        new LengthUnit(3.0);

    public static readonly LengthUnit CENTIMETER =
        new LengthUnit(1.0 / 30.48);

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
}