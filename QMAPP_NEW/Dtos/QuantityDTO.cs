namespace QMAPP.DTOs;

public class QuantityDTO
{
    public double Value { get; set; }

    public string Unit { get; set; } = "";

    public string MeasurementType { get; set; } = "";
}