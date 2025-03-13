using RezervationPortal.Entities;

namespace RezervationPortal.Data.DTO.RoomDtos
{
    public class CreateRoomDto
    {
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }

        public int? RoomTypeId { get; set; }  // Opsiyonel
        public RoomType RoomType { get; set; }
    }
}
