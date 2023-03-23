using System.ComponentModel.DataAnnotations;

namespace credit_wizard_api.Models
{
    public class Modul
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(4)]
        public string Abbreviation { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength (1000)]
        public string Description { get; set; }

        public List<DegreeModul> DegreeModuls { get; set; } = new List<DegreeModul>();

        public ICollection<SemesterPlanner> SemesterPlanners { get; set; } = new List<SemesterPlanner>();
    }
}
