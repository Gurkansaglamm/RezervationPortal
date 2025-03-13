using RezervationPortal.Entities;

namespace RezervationPortal.Abstract
{
    public interface IReservationRepository : IGenericRepository<Reservation>
    {
        Task<IEnumerable<Reservation>> GetReservationsByRoomIdAsync(int roomId);

        Task<IEnumerable<Reservation>> GetReservationsByGuestIdAsync(int guestId);

        Task<IEnumerable<Reservation>> GetReservationsByStatusAsync(string status);

    }
}
