using System.ComponentModel.DataAnnotations;

namespace credit_wizard_api.Dtos
{
    public class SemesterDto
    {

        public Guid Id { get; set; }

        [Required]
        [Range(1, 100)]
        public int Number { get; set; }

        public ICollection<SemesterPlannerDto> SemesterPlannerDtos { get; set; } = new List<SemesterPlannerDto>();
    }
}
