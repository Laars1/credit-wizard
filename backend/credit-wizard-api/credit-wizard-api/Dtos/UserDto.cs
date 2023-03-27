using System.ComponentModel.DataAnnotations;
using credit_wizard_api.Models;

namespace credit_wizard_api.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Email { get; set; }
        
        [Required, StringLength(50)]
        public string Prename { get; set; }
        
        [Required, StringLength(100)]
        public string Lastname { get; set; }
        
        [Required, StringLength(20)]
        public string MatriculationNumber { get; set; }

        public Guid DegreeId { get; set; }

        public Degree DegreeDto { get; set; }

        public ICollection<SemesterPlannerDto> SemesterPlannersDtos { get; set; } = new List<SemesterPlannerDto>();
    }
}