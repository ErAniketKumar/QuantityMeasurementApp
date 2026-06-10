using QMAPP.DTOs;

namespace QMAPP.Services;

public interface IQuantityMeasurementService
{
    bool Compare(QuantityDTO q1, QuantityDTO q2);

    object Convert(QuantityDTO dto, string targetUnit);

    object Add(QuantityDTO dto1, QuantityDTO dto2);

    object Sub(QuantityDTO dto1, QuantityDTO dto2);

    object Div(QuantityDTO dto1, QuantityDTO dto2);
}