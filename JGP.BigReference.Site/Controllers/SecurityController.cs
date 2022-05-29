using Microsoft.AspNetCore.Mvc;

namespace JGP.BigReference.Site.Controllers
{
    public class SecurityController : Controller
    {
        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

    }
}
