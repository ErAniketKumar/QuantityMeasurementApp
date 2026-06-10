using QMAPP.Entities;

namespace QMAPP.Repositories;

public interface IQuantityMeasurementRepository
{
    void Save(QuantityMeasurementEntity entity);
    List<QuantityMeasurementEntity>GetAll();
}