﻿namespace RezervationPortal.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int GuestId { get; set; }
        public Guest Guest { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Status { get; set; }  // Örnek: "Booked", "CheckedIn", "Cancelled"
    }
}
