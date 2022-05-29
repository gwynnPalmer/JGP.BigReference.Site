using Microsoft.AspNetCore.Mvc;

namespace JGP.BigReference.Site.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
