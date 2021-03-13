using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBLL.Filters;
using TravelDAL.Entities;

namespace TravelBLL.Interfaces
{
    public interface ITourService
    {
        IEnumerable<Tour> GetAllTour(List<TourFilter> filters);
        IEnumerable<Flight> GetAllFlight();
        IEnumerable<Location> GetAllLocation();
        Task AddTourAsync(Tour tour);
        IEnumerable<string> GetFlight();
        IEnumerable<string> GetLocation();
        Tour GetTour(int id);
    }
}
