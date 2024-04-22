using TrashHandling.Models.Entities;
using TrashHandling.Models;
using AutoMapper;

namespace TrashHandling.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<TrashBooking, TrashBookingViewModel>().ReverseMap();
            CreateMap<TrashCollection, TrashCollectionViewModel>().ReverseMap();
            CreateMap<Facility, FacilityViewModel>().ReverseMap();
            CreateMap<Shop, ShopViewModel>().ReverseMap();
        }
    }
}
