using AggregationApp.Application.Models;
using Microsoft.EntityFrameworkCore;
namespace AggregationApp.Application.Database
{
    public class AggregationDbContext:DbContext
    {
        public AggregationDbContext(DbContextOptions<AggregationDbContext> options) : base(options)
        {
        }
        public DbSet<AggregatedData> AggregatedData { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AggregatedData>()
                .HasKey(x => x.Region);
            modelBuilder.Entity<AggregatedData>().Property(x=>x.Region).HasColumnOrder(0).HasMaxLength(64);
            modelBuilder.Entity<AggregatedData>().Property(x => x.PPlus).HasColumnOrder(1);
            modelBuilder.ConvertDatabaseNamesToSnakeCase();
        }
    }
}
