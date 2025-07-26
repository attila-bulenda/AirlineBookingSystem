namespace AirlineBookingSystem.Global.ErrorHandlingService.Models
{
    public class StructuredProblemDetails
    {
        public string Title { get; set; } = "";
        public List<string> DetailLines { get; set; } = new();
        public string Instance { get; set; } = "";
    }
}
