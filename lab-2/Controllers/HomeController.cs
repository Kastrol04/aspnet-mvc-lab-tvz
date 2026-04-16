using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VozniRedVlakova.Data;
using VozniRedVlakova.Models;

namespace VozniRedVlakova.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMockRepository _repository;

        public HomeController(ILogger<HomeController> logger, IMockRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var model = new HomeDashboardViewModel
            {
                UkupnoVlakova = _repository.GetPutnickiVlakovi().Count,
                UkupnoStanica = _repository.GetStanice().Count,
                UkupnoVoznji = _repository.GetVoznje().Count,
                UkupnoKarata = _repository.GetKarte().Count,
                Navigacija = _repository.GetEntityNavigation()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}