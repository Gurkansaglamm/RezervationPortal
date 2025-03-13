using RezervationPortal.Entities;

namespace RezervationPortal.Abstract
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetPaymentsByReservationIdAsync(int reservationId);
        Task<IEnumerable<Payment>> GetPaymentsByStatusAsync(string status);
        Task<IEnumerable<Payment>> GetPaymentsByPaymentDateAsync(DateTime paymentDate);
       
    }
}
