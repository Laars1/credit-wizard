using System.ComponentModel.DataAnnotations;

namespace credit_wizard_api.Models
{
    public class SemesterPlanner
    {
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public bool Completed { get; set; }

        [Required]
        public Guid SemesterId { get; set; }
        public Semester Semester { get; set; }

        public ICollection<SemesterPlannerModul> SemesterPlannerModuls { get; set; } = new List<SemesterPlannerModul>();

        [Required]
        public Guid SemesterTimeSlotId { get; set; }

        public SemesterTimeSlot SemesterTimeSlot { get; set; }

    }
}
