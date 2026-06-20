namespace QMAPP.Services;

using QMAPP.DTOs;
using QMAPP.Entities;

public interface IQuantityMeasurementService
{
    Task<bool> Compare(QuantityDTO q1, QuantityDTO q2);

    Task<object> Convert(QuantityDTO dto, string targetUnit);

    Task<object> Add(QuantityDTO dto1, QuantityDTO dto2);

    Task<object> Sub(QuantityDTO dto1, QuantityDTO dto2);

    Task<object> Div(QuantityDTO dto1, QuantityDTO dto2);

    Task<List<QuantityMeasurementEntity>> GetHistory();

    Task DeleteHistory();
}