using AutoMapper;
using RezervationPortal.Data.DTO.ReservationDtos;
using RezervationPortal.Data.DTO.RoomDtos;
using RezervationPortal.Entities;

namespace RezervationPortal.Mapping
{
    public class RoomMapping : Profile
    {
        public RoomMapping()
        {
            CreateMap<CreateRoomDto, Room>().ReverseMap();
            CreateMap<UpdateRoomDto, Room>().ReverseMap();


        }
    }
}
