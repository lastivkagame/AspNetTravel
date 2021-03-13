using AutoMapper;
using TravelAgenncyUI.Models;
using TravelDAL.Entities;

namespace TravelAgenncyUI.Utils
{
    public class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration()
        {
            CreateMap<Tour, TourViewModel>()
                .ForMember(x => x.Location, s => s.MapFrom(z => z.Location.LocationFullName))
                .ForMember(x => x.Flight, s => s.MapFrom(z => z.Flight.StartCityTo));

            CreateMap<TourViewModel, Tour>()
                .ForMember(x => x.Location, s => s.MapFrom(z => new Location { LocationFullName = z.Location }))
                .ForMember(x => x.Flight, s => s.MapFrom(z => new Flight { StartCityTo = z.Flight }));
        }
    }
}