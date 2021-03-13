using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBLL.Interfaces;
using TravelDAL.Entities;
using TravelDAL.Repository.Interface;

namespace TravelBLL.Implementation
{
    public class TourService : ITourService
    {
        private readonly IGenericRepository<Tour> _tourRepository;
        private readonly IGenericRepository<Flight> _frightRepository;
        private readonly IGenericRepository<Location> _locationRepository;

        public TourService(IGenericRepository<Tour> tourRepository,
            IGenericRepository<Flight> frightRepository,
            IGenericRepository<Location> locationRepository)
        {
            _tourRepository = tourRepository;
            _frightRepository = frightRepository;
            _locationRepository = locationRepository;
        }

        public async Task AddTourAsync(Tour tour)
        {
            await _tourRepository.CreateAsync(tour);
        }

        public IEnumerable<Flight> GetAllFlight()
        {
            return _frightRepository.GetAll();
        }

        public IEnumerable<Location> GetAllLocation()
        {
            return _locationRepository.GetAll();
        }

        public IEnumerable<Tour> GetAllTour()
        {
            return _tourRepository.GetAll();
        }

        public IEnumerable<string> GetFlight()
        {
            return _frightRepository.GetAll().Select(x => x.FlightName);
        }

        public IEnumerable<string> GetLocation()
        {
            return _locationRepository.GetAll().Select(x => x.LocationFullName);
        }

        public Tour GetTour(int id)
        {
            return _tourRepository.Get(id);
        }
    }
}
