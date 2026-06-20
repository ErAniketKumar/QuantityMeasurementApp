namespace QMAPP.DTOs;

public class ConvertRequestDto
{
    public QuantityDTO Quantity { get; set; } = null!;

    public string TargetUnit { get; set; } = "";
}