namespace JGP.BigReference.Site.Areas.Referencing.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Area("Referencing")]
    public class ReferencingController : Controller
    {
        public ReferencingController()
        {

        }

        [Route("/referencing")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
