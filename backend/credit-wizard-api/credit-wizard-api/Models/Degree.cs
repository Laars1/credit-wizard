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

        [Required]
        public int TotalEtcsPoints { get; set; } = 180;

        public ICollection<DegreeModul> DegreeModuls { get; set; } = new List<DegreeModul>();
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
