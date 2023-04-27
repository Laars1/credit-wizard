using credit_wizard_api.Models;
using System.ComponentModel.DataAnnotations;

namespace credit_wizard_api.Dtos
{
    public class SemesterPlannerModulDto
    {
        [Required]
        public Guid SemesterPlannerId { get; set; }

        public SemesterPlannerDto? SemesterPlannerDto { get; set; }

        [Required]
        public Guid ModulId { get; set; }

        public ModulDto? ModulDto { get; set; }

        [Range(1, 6)]
        public double? Grade { get; set; }
    }
}