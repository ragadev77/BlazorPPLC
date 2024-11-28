using BlazorPPLC.Data;
using BlazorPPLC.Entity;

namespace BlazorPPLC.Interfaces
{
    public interface IPlanningService
    {
        public Task<List<ProductionPlanReguler>> GetProductionPlans();
        public Task<List<ProductionPlanWeekend>> GetProductionPlanWeekends();
    }
}
