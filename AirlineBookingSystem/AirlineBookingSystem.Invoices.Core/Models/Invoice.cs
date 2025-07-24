namespace AirlineBookingSystem.Invoices.Core.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string FlightNumber { get; set; }
    }
}
