using QMAPP.BusinessLogic;

public static class WeightUnitExtension
{
    public static double ConversionFector(WeightUnit unit)
    {
        switch (unit)
        {
            case WeightUnit.KILOGRAM:
                return 1.0;
            case WeightUnit.GRAM:
                return 1.0 / 1000.0;
            case WeightUnit.POUND:
                return 0.453592;
            default:
                throw new System.ArgumentOutOfRangeException(nameof(unit), unit, null);
        }
    }

    public static double ConvertToBaseUnit(WeightUnit unit, double value)
    {
        return value * ConversionFector(unit);
    }

    public static double ConvertFromBaseUnit(WeightUnit unit, double baseValue)
    {
        return baseValue / ConversionFector(unit);
    }
}