using Microsoft.EntityFrameworkCore;
using RezervationPortal.Abstract;
using RezervationPortal.Data; // RezervationPortalContext'in bulunduğu namespace
using RezervationPortal.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezervationPortal.Repository
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(RezervationPortalContext context) : base(context)
        {
        }

        // Status sorgusunu, "available" veya "unavailable" olarak alıyoruz.
        // Eğer "available" gönderilirse IsAvailable true, aksi halde false kabul ediyoruz.
        public async Task<IEnumerable<Room>> GetRoomsByStatusAsync(string status)
        {
            bool isAvailable = status.ToLower() == "available";
            return await _dbSet
                .Where(r => r.IsAvailable == isAvailable)
                .ToListAsync();
        }

        // Room tipini sorgulamak için, RoomType navigation property'sini kullanıyoruz.
        // RoomType.TypeName değeri DTO'da gönderilen 'type' ile eşleşiyorsa ilgili odaları getiriyoruz.
        public async Task<IEnumerable<Room>> GetRoomsByTypeAsync(string type)
        {
            return await _dbSet
                .Include(r => r.RoomType) // RoomType bilgisini de getiriyoruz.
                .Where(r => r.RoomType != null && r.RoomType.TypeName.ToLower() == type.ToLower())
                .ToListAsync();
        }
    }
}
