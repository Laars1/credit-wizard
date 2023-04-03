using System.ComponentModel.DataAnnotations;

namespace credit_wizard_api.Models
{
    public class SemesterTimeSlot
    {
        public Guid Id { get; set; }

        [Required]
        public string Timeslot { get; set; }

        public ICollection<Modul> Modul { get; set; } = new List<Modul>();

        public ICollection<SemesterPlanner> SemesterPlanners { get; set; }
    }
}
