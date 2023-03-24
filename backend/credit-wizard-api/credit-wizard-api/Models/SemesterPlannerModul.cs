using System.ComponentModel.DataAnnotations;

namespace credit_wizard_api.Models
{
    public class SemesterPlannerModul
    {
        [Required]
        public Guid SemesterPlannerId { get; set; }

        public SemesterPlanner SemesterPlanner { get; set; }

        [Required]
        public Guid ModulId { get; set; }

        public Modul Modul { get; set; }

        [Range(1, 6)]
        public double? Grade { get; set; }

    }
}
