using QMAPP.Entities;

namespace QMAPP.Repositories;

public interface IQuantityMeasurementRepository
{
    void Save(QuantityMeasurementEntity entity);
    Task<List<QuantityMeasurementEntity>> GetAll();
    void DeleteAll();

}

