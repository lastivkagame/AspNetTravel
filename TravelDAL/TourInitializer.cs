using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelDAL.Entities;

namespace TravelDAL
{
    public class TourInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var locations = new List<Location>
            {
                new Location(){LocationFullName="Egypt, Hurghada, Sphinx Aqua Park Beach Resort 5",
                    Hotel ="Sphinx Aqua Park Beach Resort 5", Rating=5,
                    Description ="The hotel is located on the same territory and has a common infrastructure" +
                    " with King Tut Aqua Park Beach Resort 4 *. Opened in 2009. In 2017, a renovation was" +
                    " carried out, consisting of a complex of 6-storey buildings. The hotel is suitable for" +
                    " young people. The area of ​​the territory is 8,600 m2",
                    MainImage ="https://www.otpusk.com/foto/3/1200x900/00/03/78/28/3782890.jpg",
                    ImagesGallery = new List<string>(){ "https://www.otpusk.com/foto/3/1200x900/00/02/78/05/2780586.jpg",
                        "https://www.otpusk.com/foto/3/1200x900/00/03/78/28/3782888.jpg",
                        "https://www.otpusk.com/foto/3/1200x900/00/02/78/05/2780581.jpg" } },
                new Location(){LocationFullName="Egypt, Sharm el Sheikh, Siva Sharm Resort & Spa 5",
                    Hotel ="Siva Sharm Resort & Spa 5",Rating=4.5, Description="The hotel is located in Sharks Bay and has many bars, shops, cafes and singing fountains on the picturesque shores of the Red Sea. Built in 2006. Great for young people and snorkeling enthusiasts.", MainImage="https://www.otpusk.com/foto/3/1200x900/00/02/78/06/2780661.jpg", ImagesGallery= new List<string>(){ "https://www.otpusk.com/foto/3/1200x900/00/02/78/05/2780556.jpg", "https://www.otpusk.com/foto/3/1200x900/00/02/78/05/2780566.jpg" } },

                new Location(){LocationFullName="Turkey, Bodrum, Sundance Resort 5", Hotel="Sundance Resort 5",Rating=4, Description="The hotel is located on the beach a kilometer from the place of Turkey. Established in 2004, updated in 2016. This is from the main and additional 4-storey building. The hotel is suitable for all categories of tourists. The area of ​​the territory is 16,000 m2", MainImage="https://www.otpusk.com/foto/3/1200x900/00/03/79/09/3790910.jpg", ImagesGallery=new List<string>(){ "https://www.otpusk.com/foto/3/1200x900/00/02/78/05/2780566.jpg", "https://www.otpusk.com/foto/3/1200x900/00/03/79/09/3790910.jpg" } },
                new Location(){LocationFullName="Georgia, Batumi, Side Alegria Hotel & Spa 5", Hotel="Side Alegria Hotel & Spa 5",Rating=3, Description="Royal Palace Hotel is located in Batumi, a 3-minute walk from the Black Sea. The hotel is suitable for family vacations and trips with friends", MainImage="https://www.otpusk.com/foto/3/1200x900/00/03/79/09/3790911.jpg", ImagesGallery=new List<string>(){ "https://www.otpusk.com/foto/3/1200x900/00/03/79/09/3790917.jpg", "https://www.otpusk.com/foto/3/1200x900/00/03/79/09/3790930.jpg" } },
                new Location(){LocationFullName="OAE, Smana Hotel Al Raffa 3", Hotel="Smana Hotel Al Raffa 3",Rating=4, Description="The hotel is located in Sharjah. Built in 2017. The hotel is 13 km from Sahara Center and 2.1 km from Museum of Islamic Civilization. Sharjah Aquarium is 7 km away", MainImage="https://www.otpusk.com/foto/3/1200x900/00/03/79/09/3790919.jpg", ImagesGallery=new List<string>(){ "https://www.otpusk.com/foto/3/1200x900/00/03/79/09/3790930.jpg", "https://www.otpusk.com/foto/3/1200x900/00/03/79/09/3790910.jpg" } },
            };

            var flig = new List<Flight>
            {
                new Flight(){FlightName="Flight #24d2s", StartCityTo="Kiev", Type="Business Class", StartTimeTo="13:25", StartTimeBack="9:00"},
                new Flight(){FlightName="Flight #46dsd", StartCityTo="Lviv", Type="First Class", StartTimeTo="23:15", StartTimeBack="7:20" },
                new Flight(){FlightName="Flight #989sd", StartCityTo="Rivne", Type="First Class", StartTimeTo="11:25", StartTimeBack="8:00"},
                new Flight(){FlightName="Flight #24d2a", StartCityTo="Kharkiv", Type="Economy Class", StartTimeTo="17:05", StartTimeBack="7:00"},
                new Flight(){FlightName="Flight #37d2q", StartCityTo="Kiev", Type="Economy Class", StartTimeTo="10:45", StartTimeBack="12:35"},
            };

            var tours = new List<Tour>
            {
                new Tour(){Name="Sphinx Aqua Park Beach Resort 5, Egypt, Hurghada", ResortNights=6, Price="22 500 hrn",
                    AmountPeople=2, Type="All inclusive", Image="https://www.otpusk.com/foto/3/1200x900/00/03/78/28/3782890.jpg",
                    Description ="Included: Transfer insurance, non-departure insurance, not included: visa",
                    Flight = flig.FirstOrDefault(x=>x.FlightName=="Flight #37d2q"), Location=locations.FirstOrDefault(x=>x.Hotel=="Sphinx Aqua Park Beach Resort 5")},

                new Tour(){Name="Spa weekend in Turkey, Bodrum. All inclusive!", ResortNights=6, Price="13 778 hrn",
                    AmountPeople=2, Type="All inclusive", Image="https://www.otpusk.com/foto/3/1200x900/00/04/33/17/4331707.jpg",
                    Description ="Included: Transfer insurance is not required",
                    Flight = flig.FirstOrDefault(x=>x.FlightName=="Flight #989sd"), Location=locations.FirstOrDefault(x=>x.Hotel=="Sundance Resort 5")},

                new Tour(){Name="Relax in OAE, Dubai, Side Alegria", ResortNights=8, Price="23 640 hrn",
                    AmountPeople=2, Type="Without food", Image="https://www.otpusk.com/foto/3/1200x900/00/03/86/74/3867480.jpg",
                    Description ="Included: Transfer insurance, non-departure insurance, not included: visa",
                    Flight = flig.FirstOrDefault(x=>x.FlightName=="Flight #46dsd"), Location=locations.FirstOrDefault(x=>x.Hotel=="Smana Hotel Al Raffa 3")},

                new Tour(){Name="Siva Sharm Resort & Spa 5, Egypt, recomended for young", ResortNights=6, Price="13 974 hrn",
                    AmountPeople=2, Type="All inclusive", Image="https://www.otpusk.com/foto/3/1200x900/00/03/79/09/3790919.jpg",
                    Description ="Included: Transfer insurance, non-departure insurance, not included: visa",
                    Flight = flig.FirstOrDefault(x=>x.FlightName=="Flight #989sd"), Location=locations.FirstOrDefault(x=>x.Hotel=="Siva Sharm Resort & Spa 5")},

                new Tour(){Name="Georgia, Batumi, Side Alegria Hotel & Spa 5", ResortNights=6, Price="15 600 hrn",
                    AmountPeople=2, Type="Only breakfast", Image="https://lh3.googleusercontent.com/proxy/XpzsTnUkOreeYlHt0xVvgK577cXRqsEqEDL5sbj2ZRtE81jLvboRh5zLg2ji9nR6H_ltRVUc-ci66firdMGkGhT99k9WMlTjNhIXvMdF3WL1wA9P4Ls1",
                    Description ="Included: Transfer insurance, non-departure insurance, not included: visa",
                    Flight = flig.FirstOrDefault(x=>x.FlightName=="Flight #37d2q"), Location=locations.FirstOrDefault(x=>x.Hotel=="Side Alegria Hotel & Spa 5")},
            };

            context.Locations.AddRange(locations);
            context.Flights.AddRange(flig);
            context.Tours.AddRange(tours);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
