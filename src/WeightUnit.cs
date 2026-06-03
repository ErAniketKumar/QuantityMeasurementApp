namespace QMAPP.src;

public sealed class WeightUnit : IMeasurable
{
    private readonly double _factor;

    private WeightUnit(double factor)
    {
        _factor = factor;
    }

    public static readonly WeightUnit KILOGRAM =
        new WeightUnit(1.0);

    public static readonly WeightUnit GRAM =
        new WeightUnit(0.001);
    public static readonly WeightUnit POUND =
        new WeightUnit(0.453592);

    public double ConvertToBaseUnit(double value)
    {
        return value * _factor;
    }

    public double ConvertFromBaseUnit(double value)
    {
        return value / _factor;
    }
}