using Microsoft.EntityFrameworkCore;
using SCADA_backend.Model;

namespace SCADA_backend;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<AnalogInput> AnalogInputs { get; set; }
    public DbSet<AnalogOutput> AnalogOutputs { get; set; }
    public DbSet<DigitalInput> DigitalInputs { get; set; }
    public DbSet<DigitalOutput> DigitalOutputs { get; set; }
    public DbSet <Tag> Tags { get; set; }
    public DbSet <Alarm> Alarms { get; set; }
    public DbSet<TagLog> TagLogs { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tag>()
            .ToTable("Tags");
        modelBuilder.Entity<Alarm>()
            .ToTable("Alarms");
        modelBuilder.Entity<TagLog>()
            .ToTable("TagLogs");
        modelBuilder.Entity<AnalogInput>()
            .ToTable("AnalogInputs")
            .HasBaseType<Tag>();
        modelBuilder.Entity<AnalogOutput>()
            .ToTable("AnalogOutputs")
            .HasBaseType<Tag>();
        modelBuilder.Entity<DigitalInput>()
            .ToTable("DigitalInputs")
            .HasBaseType<Tag>();
        modelBuilder.Entity<DigitalOutput>()
            .ToTable("DigitalOutputs")
            .HasBaseType<Tag>();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "server=localhost;user=root;password=48223.00;database=scadadb";
        var serverversion = new MySqlServerVersion(new Version(8, 0, 32));
        optionsBuilder.UseMySql(connectionString, serverversion);
    }
}