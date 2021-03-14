using AutoMapper;
using Binbin.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using TravelAgenncyUI.Models;
using TravelAgenncyUI.Utils.Helpers;
using TravelBLL.Filters;
using TravelBLL.Interfaces;
using TravelDAL.Entities;

namespace TravelAgenncyUI.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourService _tourService;
        private readonly IMapper _mapper;

        //from DI
        public TourController(ITourService tourService, IMapper mapper)
        {
            _tourService = tourService;
            _mapper = mapper;
        }

        // GET: Tour
        //public ActionResult Index()
        //{
        //    return View();
        //}


        public ActionResult Index(string search)
        {
            ViewBag.Title = "TourStore";
            #region Manual mapping
            //var games = new List<GameViewModel>();
            //foreach (var item in _gameService.GetAllGames())
            //{
            //    games.Add(new GameViewModel
            //    {
            //        Id = item.Id,
            //        Name = item.Name,
            //        Description = item.Description,
            //        Price = item.Price,
            //        Year = item.Year//,
            //        //Developer = item.De
            //    });
            //} 
            #endregion

            var tour = _mapper.Map<List<TourViewModel>>(_tourService.GetAllTour(null));
            SetViewBag();
            if (String.IsNullOrEmpty(search))
            {
                return View(tour);
            }


            return View(tour.Where(x => x.Name.Contains(search)).ToList());

            // var developers = new[] { "Bethesda", "Rockstar", "Ubisoft" };
            // ViewBag.Developers = developers;

        }

        public ActionResult GetLocations()
        {
            return View();
        }

        public ActionResult Create()
        {
            //ViewBag.Locactions = GetLocationsString(_tourService.GetAllLocation());
            //ViewBag.Locactions = _tourService.GetAllLocation();
            //ViewBag.Flights = _tourService.GetAllFlight();
            SetViewBag();
            return View();
        }

        public List<string> GetLocationsString(IEnumerable<Location> list)
        {
            List<string> loc = new List<string>();

            foreach (var item in list)
            {
                loc.Add(item.Hotel);
            }

            return loc;
        }

        [HttpPost]
        public async Task<ActionResult> Create(TourViewModel model, HttpPostedFileBase image)
        {
            // 1) якщо картинка:
            //    2) зберегти картинку на сервер
            // 2.1) конвертувати картинку
            //    3) записати шлях в модель
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (image != null)
            {
                var fileName = Guid.NewGuid().ToString() + ".jpg";

                var bitmap = BitmapConvertor.Convert(image.InputStream, 200, 200);
                var serverPath = Server.MapPath($"~/Images/{fileName}");

                bitmap.Save(serverPath);
                model.Image = $"/Images/{fileName}";
            }

            await _tourService.AddTourAsync(_mapper.Map<Tour>(model));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var tour = _tourService.GetTour(id);
            return View(_mapper.Map<TourViewModel>(tour));
        }

        [HttpPost]
        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Filter(string type, string value)
        {

            var filter = new TourFilter()
            {
                Name = value,
                Type = type
            };

            // predicate: x => x.Developer == Bogdan
            // predicate: x => x.Genre == RPG

            if (type == "location")
            {
                filter.Predicate = (x => x.Location.Hotel == value);
            }
            else if (type == "flightcitystart")
            {
                filter.Predicate = (x => x.Flight.StartCityTo == value);
            }
            else if (type == "flighttype")
            {
                filter.Predicate = (x => x.Flight.Type == value);
            }

            var filters = new List<TourFilter>();
            if (Session["TourFilter"] != null)
            {
                filters = Session["TourFilter"] as List<TourFilter>;
            }

            //var results = filters.GroupBy(
            // p => p.Name,
            // p => p.Type,
            // (key, g) => new { PersonId = key, Cars = g.ToList() });

            var found = filters.FirstOrDefault(f => f.Name == value && f.Type == type);
            if (found != null)
            {
                filters.Remove(found);
            }
            else
            {
                filters.Add(filter);
            }

            Session["TourFilter"] = filters;

            var games = _tourService.GetAllTour(filters);
            SetViewBag();

            return PartialView("ToursPartial", _mapper.Map<List<TourViewModel>>(games));
        }

        private void SetViewBag()
        {
            ViewBag.Locactions = _tourService.GetAllLocation().Select(x => x.Hotel);
            ViewBag.Flights = _tourService.GetAllFlight().Select(x => x.StartCityTo);
            ViewBag.FlightType = _tourService.GetAllFlight().Select(x => x.Type);
            ViewBag.FlightForChoose = _tourService.GetAllFlight().Select(x => x.Type + " (from " + x.StartCityTo + " at " + x.StartTimeTo + " )"); ;
        }
    }
}