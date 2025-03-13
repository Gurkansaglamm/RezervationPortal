using Microsoft.EntityFrameworkCore;
using RezervationPortal.Entities;

namespace RezervationPortal.Data
{
    public class RezervationPortalContext :DbContext
    {


        public RezervationPortalContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Guest> Guests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Payment entity'sindeki Amount property'si için sütun tipini belirtin.
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");
        }

    }
}
