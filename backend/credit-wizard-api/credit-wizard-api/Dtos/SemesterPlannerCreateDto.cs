using credit_wizard_api.Models;
using System.ComponentModel.DataAnnotations;

namespace credit_wizard_api.Dtos
{
    public class SemesterPlannerCreateDto
    {

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Guid SemesterId { get; set; }
        public ICollection<SemesterDto> SemesterDtos { get; set; } = new List<SemesterDto>();

        public ICollection<Guid> SelectedModulDtos { get; set; } = new List<Guid>();

        public ICollection<ModulDto> ModulDtos { get; set; } = new List<ModulDto>();

        [Required]
        public Guid SemesterTimeslotId { get; set; }

        public ICollection<SemesterTimeSlotDto> SemesterTimeSlotDtos { get; set; } = new List<SemesterTimeSlotDto>();
    }
}
