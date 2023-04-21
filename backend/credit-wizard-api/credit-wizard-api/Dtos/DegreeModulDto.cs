namespace credit_wizard_api.Dtos;

public class DegreeModulDto
{
    public Guid ModulId { get; set; }

    public Guid DegreeId { get; set;}

    public ModulDto ModulDto { get; set; }
    public DegreeDto DegreeDto { get; set; }

    public bool IsRequired { get; set; } = false;
}