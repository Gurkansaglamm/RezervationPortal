using AutoMapper;
using RezervationPortal.Data.DTO.ReservationDtos;
using RezervationPortal.Entities;

namespace RezervationPortal.Mapping
{
    public class ReservationMapping :Profile
    {
        public ReservationMapping()
        {
            CreateMap<CreateReservationDto, Reservation>().ReverseMap();
            CreateMap<UpdateReservationDto, Reservation>().ReverseMap();
        }

    }
}
