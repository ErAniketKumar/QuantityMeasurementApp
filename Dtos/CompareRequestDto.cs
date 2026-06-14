using System.ComponentModel.DataAnnotations;

namespace QMAPP.DTOs;

public class CompareRequestDto
{
    [Required]
    public double Value1 { get; set; }

    [Required]
    public string Unit1 { get; set; } = "";

    [Required]
    public double Value2 { get; set; }

    [Required]
    public string Unit2 { get; set; } = "";

    [Required]
    public string MeasurementType { get; set; } = "";
}