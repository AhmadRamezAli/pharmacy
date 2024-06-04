using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pharmacy.Domain.Repositories;

namespace Pharmacy.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(ILogger<HomeController> logger, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            //return Ok(_categoryRepository.GetAll());
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}