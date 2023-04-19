using credit_wizard_api.Models;
using System.ComponentModel.DataAnnotations;

namespace credit_wizard_api.Dtos
{
    public class ModulDto
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(4)]
        public string Abbreviation { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [Range(1, 15)]
        public int EtcsPoints { get; set; }

        public List<DegreeModul> DegreeModulsDto { get; set; } = new List<DegreeModul>();

        public ICollection<SemesterPlannerDto> SemesterPlannerDtos { get; set; } = new List<SemesterPlannerDto>();

        public ICollection<SemesterTimeSlotDto> SemesterTimeSlotDtos { get; set; } = new List<SemesterTimeSlotDto>();

        public ICollection<DegreeModulDto> DegreeModulDtos { get; set; } = new List<DegreeModulDto>();
    }
}
