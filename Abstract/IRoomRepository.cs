using RezervationPortal.Entities;

namespace RezervationPortal.Abstract
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Task<IEnumerable<Room>> GetRoomsByStatusAsync(string status);
        Task<IEnumerable<Room>> GetRoomsByTypeAsync(string type);


    }
}
