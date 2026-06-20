using Microsoft.EntityFrameworkCore;
using QMAPP.Data;
using QMAPP.Entities;

namespace QMAPP.Repositories;

public class QuantityMeasurementDbeRepository
    : IQuantityMeasurementRepository
{
    private readonly QmDbContext _context;

    public QuantityMeasurementDbeRepository(
        QmDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync(
        QuantityMeasurementEntity entity)
    {
        await _context
            .QuantityMeasurementEntities
            .AddAsync(entity);

        await _context.SaveChangesAsync();
    }

    public async Task<List<QuantityMeasurementEntity>>
        GetAll()
    {
        return await _context
            .QuantityMeasurementEntities
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }

    public async Task DeleteAll()
    {
        _context.QuantityMeasurementEntities
            .RemoveRange(
                _context.QuantityMeasurementEntities);

        await _context.SaveChangesAsync();
    }
}