using System.ComponentModel.DataAnnotations;

namespace credit_wizard_api.Models
{
    public class Semester
    {

        public Guid Id { get; set; }

        [Required]
        [Range(1, 100)]
        public int Number { get; set; }

        public ICollection<SemesterPlanner> SemesterPlanners { get; set; } = new List<SemesterPlanner>();
    }
}
