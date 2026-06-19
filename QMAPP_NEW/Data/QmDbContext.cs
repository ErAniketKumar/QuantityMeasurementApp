using Microsoft.EntityFrameworkCore;
using QMAPP.Entities;

namespace QMAPP.Data;

public class QmDbContext : DbContext
{
    public QmDbContext(DbContextOptions<QmDbContext> options) : base(options)
    {

    }

    public DbSet<QuantityMeasurementEntity> QuantityMeasurementEntities { get; set; }
    public DbSet<User> Users { get; set; }
}