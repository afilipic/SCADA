using Microsoft.EntityFrameworkCore;

namespace SCADA_backend;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "server=localhost;user=root;password=Anitapajic123;database=scadadb";
        var serverversion = new MySqlServerVersion(new Version(8, 0, 32));
        optionsBuilder.UseMySql(connectionString, serverversion);
    }
}