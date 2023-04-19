using credit_wizard_api.Models;
using System.ComponentModel.DataAnnotations;

namespace credit_wizard_api.Dtos
{
    public class DegreeDto
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(5000)]
        public string Description { get; set; }
        
        public int TotalEtcsPoints { get; set; } = 180;

        public ICollection<DegreeModulDto> DegreeModulDtos { get; set; } = new List<DegreeModulDto>();
    }
}
