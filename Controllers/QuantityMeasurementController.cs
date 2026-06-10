using QMAPP.DTOs;
using QMAPP.Services;

namespace QMAPP.Controllers;

public class QuantityMeasurementController
{
    private readonly
    IQuantityMeasurementService
    _service;

    public QuantityMeasurementController(
        IQuantityMeasurementService service)
    {
        _service = service;
    }

    public bool PerformComparison(
        QuantityDTO q1,
        QuantityDTO q2)
    {
        return _service.Compare(
            q1,
            q2
        );
    }
}