namespace QMAPP.BusinessLogic;

public class QuantityLength
{
    private readonly double value;
    public readonly LengthUnit unit;

    public QuantityLength(double value, LengthUnit unit)
    {
        this.value = value;
        this.unit = unit;
    }

    public double ConvertToBaseUnit()
    {
        return this.value * LengthUnitExtension.ConversionFector(this.unit);
    }

    public override bool Equals(object? obj)
    {
        return obj is QuantityLength other &&
        Math.Abs(
           this.ConvertToBaseUnit() -
           other.ConvertToBaseUnit()
           ) < 0.0001;
    }
}
