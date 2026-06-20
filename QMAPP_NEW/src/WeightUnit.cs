namespace QMAPP.src;

public sealed class WeightUnit : IMeasurable
{
    private readonly double _factor;
    private readonly string _name;

    private WeightUnit(double factor, string name)
    {
        _factor = factor;
        _name = name;
    }

    public static readonly WeightUnit KILOGRAM =
        new WeightUnit(1.0, "KILOGRAM");

    public static readonly WeightUnit GRAM =
        new WeightUnit(0.001, "GRAM");

    public static readonly WeightUnit POUND =
        new WeightUnit(0.453592, "POUND");

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