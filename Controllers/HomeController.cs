using Microsoft.AspNetCore.Mvc;

namespace EcoStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}