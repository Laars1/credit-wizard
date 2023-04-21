namespace credit_wizard_api.Dtos;

public class DegreeProgressDto
{
    public Guid UserId { get; set; }
    public int TotalDegreeEtcsPoints { get; set; }
    public int ReachedEtcsPoints { get; set; }
    public int OpenEtcsPoints { get; set; }
    public int MissingEtcsPoints { get; set; }
    public int MissedEctsPoints { get; set; }
    public int PercentageFinishedRequiredModuls { get; set; }
}