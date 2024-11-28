using BlazorPPLC.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlazorPPLC.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            
        }

        public DbSet<ProductionPlanReguler> ProductionPlanRegulers { get; set; }
        public DbSet<ProductionPlanWeekend> ProductionPlanWeekends { get; set; }

    }
}
