namespace QMAPP.Factory;
using QMAPP.DTOs;
using QMAPP.src;

public class QuantityFactory : IQuantityFactory
{
    public object CreateQuantity(QuantityDTO dto)
    {
        double value = dto.Value;
        string measurementType = dto.MeasurementType;
        string unit = dto.Unit;

        switch (measurementType.ToUpper())
        {
            case "LENGTH":

                return new Quantity<LengthUnit>(
                    value,
                    GetLengthUnit(unit)
                );

            case "WEIGHT":

                return new Quantity<WeightUnit>(
                    value,
                    GetWeightUnit(unit)
                );

            case "VOLUME":

                return new Quantity<VolumeUnit>(
                    value,
                    GetVolumeUnit(unit)
                );

            case "TEMPERATURE":

                return new Quantity<TemperatureUnit>(
                    value,
                    GetTemperatureUnit(unit)
                );

            default:
                throw new Exception(
                    "Invalid Measurement Type"
                );
        }
    }

    private LengthUnit GetLengthUnit(string unit)
    {
        return unit.ToUpper() switch
        {
            "FEET" => LengthUnit.FEET,
            "INCH" => LengthUnit.INCH,
            "YARDS" => LengthUnit.YARDS,
            _ => throw new Exception()
        };
    }

    private WeightUnit GetWeightUnit(string unit)
    {
        return unit.ToUpper() switch
        {
            "GRAM" => WeightUnit.GRAM,
            "KILOGRAM" => WeightUnit.KILOGRAM,
            _ => throw new Exception()
        };
    }

    private VolumeUnit GetVolumeUnit(string unit)
    {
        return unit.ToUpper() switch
        {
            "LITRE" => VolumeUnit.LITRES,
            "MILLILITRE" => VolumeUnit.MILLILITRES,
            _ => throw new Exception()
        };
    }

    private TemperatureUnit GetTemperatureUnit(
        string unit)
    {
        return unit.ToUpper() switch
        {
            "CELSIUS" => TemperatureUnit.CELSIUS,
            "FAHRENHEIT" => TemperatureUnit.FAHRENHEIT,
            _ => throw new Exception()
        };
    }

    public object GetUnit(
           string measurementType,
           string unit)
    {
        switch (measurementType.ToUpper())
        {
            case "LENGTH":
                return unit.ToUpper() switch
                {
                    "FEET" => LengthUnit.FEET,
                    "INCH" => LengthUnit.INCH,
                    "YARDS" => LengthUnit.YARDS,
                    "CENTIMETER" => LengthUnit.CENTIMETER,
                    _ => throw new ArgumentException("Invalid Length Unit")
                };

            case "WEIGHT":
                return unit.ToUpper() switch
                {
                    "GRAM" => WeightUnit.GRAM,
                    "KILOGRAM" => WeightUnit.KILOGRAM,
                    _ => throw new ArgumentException("Invalid Weight Unit")
                };

            case "VOLUME":
                return unit.ToUpper() switch
                {
                    "LITRE" => VolumeUnit.LITRES,
                    "MILLILITRE" => VolumeUnit.MILLILITRES,
                    "GALLON" => VolumeUnit.GALLON,
                    _ => throw new ArgumentException("Invalid Volume Unit")
                };

            case "TEMPERATURE":
                return unit.ToUpper() switch
                {
                    "CELSIUS" => TemperatureUnit.CELSIUS,
                    "FAHRENHEIT" => TemperatureUnit.FAHRENHEIT,
                    _ => throw new ArgumentException("Invalid Temperature Unit")
                };

            default:
                throw new ArgumentException(
                    "Invalid Measurement Type");
        }
    }
}