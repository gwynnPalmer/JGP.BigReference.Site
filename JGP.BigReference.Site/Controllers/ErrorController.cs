using Microsoft.AspNetCore.Mvc;

namespace JGP.BigReference.Site.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/error/{code:int}")]
        public IActionResult GetErrorPage(int code)
        {
            switch (code)
            {
                case StatusCodes.Status404NotFound:
                    Response.StatusCode = code;
                    return View("404");
                default: return View("404");
            }
        }
    }
}
