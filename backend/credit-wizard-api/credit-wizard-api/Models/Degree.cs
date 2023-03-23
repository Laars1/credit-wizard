using System.ComponentModel.DataAnnotations;

namespace credit_wizard_api.Models
{
    public class Degree
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(5000)]
        public string Description { get; set; }

        public ICollection<DegreeModul> DegreeModuls { get; set; } = new List<DegreeModul>();
    }
}
