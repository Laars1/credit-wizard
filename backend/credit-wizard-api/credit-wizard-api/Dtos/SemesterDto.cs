using credit_wizard_api.Models;
using System.ComponentModel.DataAnnotations;

namespace credit_wizard_api.Dtos
{
    public class SemesterDto
    {

        public Guid Id { get; set; }

        [Required]
        [Range(1, 100)]
        public int Number { get; set; }

        public ICollection<SemesterPlanner> SemesterPlannersDto { get; set; } = new List<SemesterPlanner>();
    }
}
