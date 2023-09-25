using Microsoft.EntityFrameworkCore;
using TrackingSystemApi.Business.Entities;

namespace TrackingSystemApi.Data;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<IndividualTracking> IndividualTracking { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IndividualTracking>().Property(p => p.SymptomsDb);
    }
}