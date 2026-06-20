namespace QMAPP.Entities;

public class QuantityMeasurementEntity
{
    public int Id { get; set; }

    public double Value1 { get; set; }

    public required string Unit1 { get; set; }

    public double Value2 { get; set; }

    public required string Unit2 { get; set; }

    public required string MeasurementType { get; set; }

    public required string Operation { get; set; }

    public required string Result { get; set; }

    public DateTime CreatedAt { get; set; }
}