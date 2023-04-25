using credit_wizard_api.Models;
using System.ComponentModel.DataAnnotations;

namespace credit_wizard_api.Dtos
{
    public class SemesterPlannerDto
    {
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public User? User { get; set; }

        public bool Completed { get; set; }

        [Required]
        public Guid SemesterId { get; set; }
        public SemesterDto? SemesterDto { get; set; }

        public List<SemesterPlannerModulDto> SemesterPlannerModulDtos { get; set; } = new List<SemesterPlannerModulDto>();

        [Required]
        public Guid SemesterTimeSlotId { get; set; }

        public SemesterTimeSlotDto? SemesterTimeSlotDto { get; set; }
    }
}
