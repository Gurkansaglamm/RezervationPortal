using AutoMapper;
using RezervationPortal.Data.DTO.PaymentDtos;
using RezervationPortal.Entities;

namespace RezervationPortal.Mapping
{
    public class PaymentMapping: Profile
    {
        public PaymentMapping()
        {
            CreateMap<CreatePaymentDto, Payment>().ReverseMap();
            CreateMap<UpdatePaymentDto, Payment>().ReverseMap();
        }
    }
}
