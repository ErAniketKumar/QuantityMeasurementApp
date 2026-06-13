namespace QMAPP.Entities;

public class QuantityMeasurementEntity
{
    public int Id { get; set; }

    public double Value1 { get; set; }

    public string Unit1 { get; set; }

    public double Value2 { get; set; }

    public string Unit2 { get; set; }

    public string MeasurementType { get; set; }

    public string Operation { get; set; }

    public string Result { get; set; }

    public DateTime CreatedAt { get; set; }
}