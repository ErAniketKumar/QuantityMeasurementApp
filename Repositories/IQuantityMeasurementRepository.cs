using QMAPP.Entities;

namespace QMAPP.Repositories;

public interface IQuantityMeasurementRepository
{
    Task SaveAsync(
        QuantityMeasurementEntity entity
    );

    Task<List<QuantityMeasurementEntity>>
        GetAll();

    Task DeleteAll();
}

