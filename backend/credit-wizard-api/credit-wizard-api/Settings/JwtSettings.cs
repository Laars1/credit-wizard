namespace credit_wizard_api.Settings
{
    public class JwtSettings
    {
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string JwtSecret { get; set; }
    }
}
