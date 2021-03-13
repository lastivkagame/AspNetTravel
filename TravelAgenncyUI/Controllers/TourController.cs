using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TravelAgenncyUI.Models;
using TravelAgenncyUI.Utils.Helpers;
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

            var tour = _mapper.Map<List<TourViewModel>>(_tourService.GetAllTour());
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
            ViewBag.Locactions = _tourService.GetAllLocation();
            ViewBag.Flights = _tourService.GetAllFlight();
            return View();
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
            var game = _tourService.GetTour(id);
            return View(_mapper.Map<TourViewModel>(game));
        }

        [HttpPost]
        public ActionResult Edit()
        {
            return View();
        }
    }
}