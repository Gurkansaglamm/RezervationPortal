using AutoMapper;
using RezervationPortal.Data.DTO.GuestDtos;
using RezervationPortal.Entities;

namespace RezervationPortal.Mapping
{
    public class GuestMapping: Profile
    {
        public GuestMapping()
        {
            CreateMap<CreateGuestDto, Guest>().ReverseMap();
            CreateMap<UpdateGuestDto, Guest>().ReverseMap();
        }

    }
}
