using AutoMapper;
using System;
using TravelAgenncyUI.Models;
using TravelDAL.Entities;

namespace TravelAgenncyUI.Utils
{
    public class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration()
        {
            //CreateMap<Flight, FlightViewModel>()
            //   .ForMember(x => x.LocationFirstFlight, s => s.MapFrom(z => z.LocationFirstFlight.City + ", " + z.LocationFirstFlight.Country))
            //   .ForMember(x => x.LocationResortPlace, s => s.MapFrom(z => z.LocationResortPlace.City + ", " + z.LocationFirstFlight.Country));

            //CreateMap<FlightViewModel, Flight>()
            //    .ForMember(x => x.LocationFirstFlight, s => s.MapFrom((z) => CreateLocationFromString(z.LocationFirstFlight)
            //    ))
            //      .ForMember(x => x.LocationResortPlace, s => s.MapFrom((z) => CreateLocationFromString(z.LocationResortPlace)
            //    ));


            CreateMap<Tour, TourViewModel>()
                .ForMember(x => x.Flight, s => s.MapFrom(z => z.Flight.FlightDateToBegan + " at " + z.Flight.StartTimeHours))
                .ForMember(x => x.LocationFirstFlight, s => s.MapFrom(z => z.LocationFirstFlight.City + ", " + z.LocationFirstFlight.Country))
                .ForMember(x => x.LocationResortPlace, s => s.MapFrom(z => z.LocationResortPlace.City + ", " + z.LocationResortPlace.Country));

            CreateMap<TourViewModel, Tour>()
                .ForMember(x => x.Flight, s => s.MapFrom(z => CreateLocationFromString(z.Flight)))
                .ForMember(x => x.LocationFirstFlight, s => s.MapFrom(z => CreateLocationFromString(z.LocationFirstFlight)))
                .ForMember(x => x.LocationResortPlace, s => s.MapFrom(z => CreateLocationFromString(z.LocationResortPlace)));
        }

        public Flight CreateLocationFromString(string data)
        {
            string date = "", time = "";
            bool flag = true;
            foreach (var item in data)
            {
                if (item == ',')
                {
                    flag = false;
                }
                else if (flag)
                {
                    date += item;
                }
                else
                {
                    time += item;
                }

            }

            return new Flight() { FlightDateToBegan = time, StartTimeHours = date };
        }

        public Location CreateFlightFromString(string data)
        {
            string city = "", country = "";
            bool flag = true;
            foreach (var item in data)
            {
                if (item == ' ' || item == 'a' || item == 't')
                {
                    flag = false;
                }
                else if (flag)
                {
                    city += item;
                }
                else
                {
                    country += item;
                }

            }

            return new Location() { City = city, Country = country };
        }
    }
}