using Microsoft.EntityFrameworkCore;

namespace DatosIonosfericos.Data;

public class IonosferaContext : DbContext
{
    public DbSet<Record> Records => Set<Record>();

    public IonosferaContext(DbContextOptions<IonosferaContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
}
