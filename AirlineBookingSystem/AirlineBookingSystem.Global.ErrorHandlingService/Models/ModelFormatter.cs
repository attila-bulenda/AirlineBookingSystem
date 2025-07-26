using System.Text.Json;

namespace AirlineBookingSystem.Global.ErrorHandlingService.Models
{
    public static class ModelFormatter
    {
        public static string JSONFormatProblemDetailsModel(Exception exception, string path)
        {
            var details = new StructuredProblemDetails
            {
                Title = exception.Message,
                DetailLines = exception.StackTrace?
                    .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList() ?? [],
                Instance = path
            };
            var json = JsonSerializer.Serialize(details, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            return json;
        }
    }
}
