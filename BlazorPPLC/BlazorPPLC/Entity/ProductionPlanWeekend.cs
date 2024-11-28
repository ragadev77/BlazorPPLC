using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorPPLC.Entity
{
    [Table("ProductionPlanWeekend", Schema = "dbo")]

    public class ProductionPlanWeekend
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        [Column(TypeName = "int")]
        public int Monday { get; set; }
        [Column(TypeName = "int")]
        public int Tuesday { get; set; }
        [Column(TypeName = "int")]
        public int Wednesday { get; set; }
        [Column(TypeName = "int")]
        public int Thursday { get; set; }
        [Column(TypeName = "int")]
        public int Friday { get; set; }
        [Column(TypeName = "int")]
        public int Saturday { get; set; }
        [Column(TypeName = "int")]
        public int Sunday { get; set; }
        [NotMapped]
        public string? Flag { get; set; } = "Actual";
        [NotMapped]
        public string? Notes {  get; set; }

    }
}
