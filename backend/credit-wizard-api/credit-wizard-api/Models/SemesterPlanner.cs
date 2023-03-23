using System.ComponentModel.DataAnnotations;

namespace credit_wizard_api.Models
{
    public class SemesterPlanner
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Guid SemesterId { get; set; }
        public Semester Semester { get; set; }

        [Required]
        public Guid ModulId { get; set; }
        public Modul Modul { get; set; }

        [Range(1, 6)]
        public double? Grade { get; set; }

    }
}
