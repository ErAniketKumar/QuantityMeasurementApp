using Microsoft.EntityFrameworkCore;
using QMAPP.Data;
using QMAPP.Entities;

namespace QMAPP.Repositories;

public class QuantityMeasurementDbeRepository
    : IQuantityMeasurementRepository
{
    // private readonly
    // List<QuantityMeasurementEntity>
    // _data = new();

    private readonly QmDbContext _context;
    public QuantityMeasurementDbeRepository(QmDbContext context)
    {
        _context = context;
    }

    public void Save(QuantityMeasurementEntity entity)
    {
        _context.QuantityMeasurementEntities.Add(entity);
        _context.SaveChanges();
    }

    public async Task<List<QuantityMeasurementEntity>> GetAll()
    {
        return await _context.QuantityMeasurementEntities.ToListAsync();
    }

    public void DeleteAll()
    {
        _context.QuantityMeasurementEntities.RemoveRange(
            _context.QuantityMeasurementEntities
        );
        _context.SaveChanges();
    }
}