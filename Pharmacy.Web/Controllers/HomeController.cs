using Microsoft.AspNetCore.Mvc;
using Pharmacy.Domain.Repositories;

namespace Pharmacy.Web.Controllers
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
            return Ok(_categoryRepository.GetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}