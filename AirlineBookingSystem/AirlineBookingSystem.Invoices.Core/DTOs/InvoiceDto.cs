namespace AirlineBookingSystem.Invoices.Core.DTOs
{
    public class InvoiceDto
    {
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string FlightNumber { get; set; }
    }
}
