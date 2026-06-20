using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace QMAPP.Data;

public class QmDbContextFactory
    : IDesignTimeDbContextFactory<QmDbContext>
{
    public QmDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder =
            new DbContextOptionsBuilder<QmDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=aniket;Database=Qmeasurement;Trusted_Connection=True;TrustServerCertificate=True;"
        );

        return new QmDbContext(
            optionsBuilder.Options
        );
    }
}