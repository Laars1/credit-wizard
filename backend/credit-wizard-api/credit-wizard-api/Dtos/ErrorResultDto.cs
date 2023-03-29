using System.Text.Json;

namespace credit_wizard_api.Dtos
{
    public class ErrorResultDto
    {
        public string ErrorType { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
