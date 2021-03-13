using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelDAL.Entities;

namespace TravelBLL.Implementation
{
    public class TestService //: ITourService
    {
        public Task AddTourAsync(Tour tour)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tour> GetAllTour()
        {
            return new List<Tour>(){
                 new Tour
                 {
                     //Name = "Lorem",
                     //Price = 1
                 },
                 //new Tour
                 //{
                 //    Name = "Lorem",
                 //    Price = 3
                 //},
                 //new Tour
                 //{
                 //    Name = "Lorem",
                 //    Price = 2
                 //},
                };

        }

        public IEnumerable<Location> GetAllLocations()
        {
            throw new NotImplementedException();
        }
    }
}
