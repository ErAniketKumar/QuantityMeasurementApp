namespace QMAPP.src;

public sealed class VolumeUnit : IMeasurable
{
    private readonly double _factor;

    public VolumeUnit(double factor)
    {
        this._factor = factor;
    }

    public static readonly VolumeUnit LITRES = new VolumeUnit(1.0);

    public static readonly VolumeUnit MILLILITRES = new VolumeUnit(0.001);

    public static readonly VolumeUnit GALLON = new VolumeUnit(3.78541);

    public double ConvertFromBaseUnit(double value)
    {
        return value / _factor;
    }

    public double ConvertToBaseUnit(double value)
    {
        return value * _factor;
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