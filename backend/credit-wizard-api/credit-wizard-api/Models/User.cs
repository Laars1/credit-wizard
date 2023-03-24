using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace credit_wizard_api.Models
{
    public class User : IdentityUser<Guid>
    {
        [Required, StringLength(20)]
        public string MatriculationNumber { get; set; }

        public Guid DegreeId { get; set; }

        public Degree Degree { get; set; }

        public ICollection<SemesterPlanner> SemesterPlanners { get; set; } = new List<SemesterPlanner>();
    }
}