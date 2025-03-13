namespace RezervationPortal.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }

        public int? RoomTypeId { get; set; }  // Opsiyonel
        public RoomType RoomType { get; set; }
    }
}
