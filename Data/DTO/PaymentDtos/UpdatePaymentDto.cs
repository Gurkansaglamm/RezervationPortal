using RezervationPortal.Entities;

namespace RezervationPortal.Data.DTO.PaymentDtos
{
    public class UpdatePaymentDto
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }  // Örnek: "CreditCard", "Cash", "Online"
        public string Status { get; set; }         // Örnek: "Pending", "Completed", "Failed"
    }
}
