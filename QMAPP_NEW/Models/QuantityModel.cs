using QMAPP.src;

namespace QMAPP.Models;

public class QuantityModel<U>
    where U : IMeasurable
{
    public double Value { get; set; }

    public U Unit { get; set; }

    public QuantityModel(double value, U unit)
    {
        Value = value;
        Unit = unit;
    }
}