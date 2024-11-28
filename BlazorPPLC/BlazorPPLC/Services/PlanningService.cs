using BlazorPPLC.Data;
using BlazorPPLC.Entity;
using BlazorPPLC.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BlazorPPLC.Services
{
    public class PlanningService : IPlanningService
    {
        private readonly DataContext _context;

        public PlanningService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ProductionPlanReguler>> GetProductionPlans()
        {
            var planRegulers = await _context.ProductionPlanRegulers.ToListAsync();
            List<ProductionPlanReguler> result = new List<ProductionPlanReguler>();
            foreach (var wp in planRegulers)
            {
                result.Add(wp);
                result.Add(RevisionReguler(wp, 5));

            }
            return result;
        }

        public async Task<List<ProductionPlanWeekend>> GetProductionPlanWeekends()
        {
            var planWeekends = await _context.ProductionPlanWeekends.ToListAsync();
            List<ProductionPlanWeekend> result = new List<ProductionPlanWeekend>();
            foreach (var wp in planWeekends)
            {
                result.Add(wp);
                result.Add(RevisionWeekend(wp, 6));

            }
            return result;
        }

        private ProductionPlanReguler RevisionReguler(ProductionPlanReguler wp, int dayPerWeek)
        {
            ProductionPlanReguler revision = new ProductionPlanReguler();
            int counterMod = 0;

            int totalProd = wp.Monday + wp.Tuesday + wp.Wednesday + wp.Thursday + wp.Friday;

            int dailyProd = totalProd / dayPerWeek;
            int modProd = totalProd % dailyProd;

            string notes = $"Total = {totalProd}, Daily = {dailyProd}, Mod = {modProd}";

            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("Monday", wp.Monday);
            dict.Add("Tuesday", wp.Tuesday);
            dict.Add("Wednesday", wp.Wednesday);
            dict.Add("Thursday", wp.Thursday);
            dict.Add("Friday", wp.Friday);
            var sortedDict = dict.OrderByDescending(kvp => kvp.Value);

            foreach (var kvp in sortedDict)
            {
                counterMod++;

                revision.Flag = "Revision Reguler";
                revision.Notes = notes;
                switch (kvp.Key.ToLower())
                {
                    case "monday":
                        revision.Monday = counterMod > modProd ? dailyProd : dailyProd + 1;
                        break;
                    case "tuesday":
                        revision.Tuesday = counterMod > modProd ? dailyProd : dailyProd + 1;
                        break;
                    case "wednesday":
                        revision.Wednesday = counterMod > modProd ? dailyProd : dailyProd + 1;
                        break;
                    case "thursday":
                        revision.Thursday = counterMod > modProd ? dailyProd : dailyProd + 1;
                        break;
                    case "friday":
                        revision.Friday = counterMod > modProd ? dailyProd : dailyProd + 1;
                        break;
                }

            }

            return revision;
        }

        private ProductionPlanWeekend RevisionWeekend(ProductionPlanWeekend wp, int dayPerWeek)
        {
            ProductionPlanWeekend revision = new ProductionPlanWeekend();
            int counterMod = 0;

            int totalProdWeekend = wp.Monday + wp.Tuesday + wp.Wednesday + wp.Thursday + wp.Friday + wp.Saturday + wp.Sunday;

            int dailyProd = totalProdWeekend / dayPerWeek;
            int modProd = totalProdWeekend % dailyProd;

            string notes = $"Total = {totalProdWeekend}, Daily = {dailyProd}, Mod = {modProd}";

            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("Monday", wp.Monday);
            dict.Add("Tuesday", wp.Tuesday);
            dict.Add("Wednesday", wp.Wednesday);
            dict.Add("Thursday", wp.Thursday);
            dict.Add("Friday", wp.Friday);
            dict.Add("Saturday", wp.Saturday);
            dict.Add("Sunday", wp.Sunday);
            var sortedDict = dict.OrderByDescending(kvp => kvp.Value);

            foreach (var kvp in sortedDict)
            {
                counterMod++;

                revision.Flag = "Revision Weekend";
                revision.Notes = notes;
                switch (kvp.Key.ToLower())
                {
                    case "monday":
                        revision.Monday = counterMod > modProd ? dailyProd : dailyProd + 1;
                        break;
                    case "tuesday":
                        revision.Tuesday = counterMod > modProd ? dailyProd : dailyProd + 1;
                        break;
                    case "wednesday":
                        revision.Wednesday = counterMod > modProd ? dailyProd : dailyProd + 1;
                        break;
                    case "thursday":
                        revision.Thursday = counterMod > modProd ? dailyProd : dailyProd + 1;
                        break;
                    case "friday":
                        revision.Friday = counterMod > modProd ? dailyProd : dailyProd + 1;
                        break;
                    case "saturday":
                        if (kvp.Value != 0)
                            revision.Saturday = counterMod > modProd ? dailyProd : dailyProd + 1;
                        break;
                    case "sunday":
                        if (kvp.Value != 0)
                            revision.Sunday = counterMod > modProd ? dailyProd : dailyProd + 1;
                        break;
                }

            }

            return revision;
        }

    }
}
