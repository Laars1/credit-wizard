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

        [Required]
        [Range(1,15)]
        public int EtcsPoints { get; set; }

        public List<DegreeModul> DegreeModuls { get; set; } = new List<DegreeModul>();

        public ICollection<SemesterPlannerModul> SemesterPlanners { get; set; } = new List<SemesterPlannerModul>();

        public ICollection<SemesterTimeSlot> SemesterTimeSlot { get; set; } = new List<SemesterTimeSlot>();
    }
}
