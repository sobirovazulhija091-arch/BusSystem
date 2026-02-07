using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options):DbContext(options)
{
    public  DbSet<Driver> Drivers{get;set;}
    public  DbSet<User> Users{get;set;}
    public  DbSet<Bus> Buses{get;set;}
    public  DbSet <Path> Paths{get;set;}
    public  DbSet<Schedule> Schedules{get;set;}
    public  DbSet<Station> Stations{get;set;}
    public  DbSet<Stop> Stops{get;set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Schedule>
        (
            builder=>{builder.HasOne<Bus>().WithMany().HasForeignKey(x=>x.BusId);
            builder.HasOne<Driver>().WithMany().HasForeignKey(x=>x.DriverId);
            builder.HasOne<Stop>().WithMany().HasForeignKey(x=>x.StopId);
            builder.HasOne<Path>().WithMany().HasForeignKey(x=>x.PathId);
            }
        );
        modelBuilder.Entity<Station>
        (
            builder =>
            {
                builder.HasOne<Stop>().WithMany().HasForeignKey(x=>x.StopId);
                builder.HasOne<Path>().WithMany().HasForeignKey(x=>x.PathId);
            }
        );
    }
}
public class ApplicationDbContextFactory:IDesignTimeDbContextFactory<ApplicationDbcontext>
{
    public ApplicationDbcontext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbcontext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=buslocation;Username=postgres;Password=1234");
         return new ApplicationDbcontext(optionsBuilder.Options);
    }
}

