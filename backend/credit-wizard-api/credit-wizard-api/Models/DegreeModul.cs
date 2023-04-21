namespace credit_wizard_api.Models
{
    public class DegreeModul
    {
        public Guid ModulId { get; set; }

        public Guid DegreeId { get; set;}

        public Modul Modul { get; set; }
        public Degree Degree { get; set; }

        public bool IsRequired { get; set; } = false;
    }
}
