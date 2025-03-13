using Microsoft.EntityFrameworkCore;
using RezervationPortal.Abstract;
using RezervationPortal.Data;
using RezervationPortal.Entities;

namespace RezervationPortal.Repository
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(RezervationPortalContext context) :base(context)
        {
            
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByGuestIdAsync(int guestId)
        {
            return await _dbSet.Where(r => r.GuestId == guestId).ToListAsync();

        }

        public async Task<IEnumerable<Reservation>> GetReservationsByRoomIdAsync(int roomId)
        {
            return await _dbSet.Where(r => r.RoomId ==roomId).ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByStatusAsync(string status)
        {
            return await _dbSet
        .Where(r => r.Status.ToLower() == status.ToLower())
        .ToListAsync();
        }
    }
}
