using credit_wizard_api.Models;
using System.ComponentModel.DataAnnotations;

namespace credit_wizard_api.Dtos
{
    public class SemesterTimeSlotDto
    {
        public Guid Id { get; set; }

        [Required]
        public string Timeslot { get; set; }

        public ICollection<ModulDto> ModulDto { get; set; } = new List<ModulDto>();

        public ICollection<SemesterPlannerDto> SemesterPlannerDtos { get; set; } = new List<SemesterPlannerDto>();
    }
}