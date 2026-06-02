using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace mediatek.Controllers
{
    public class accountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View("~/Views/Account/Login.cshtml");
        }

        [HttpPost]
        public IActionResult Login(string login, string motdepasse)
        {
            if (login == "responsable" && motdepasse == "admin123")
            {
                HttpContext.Session.SetString("Login", login);
                return RedirectToAction("Index", "personnel");
            }
            ViewBag.Error = "Login ou mot de passe incorrect";
            return View("~/Views/Account/Login.cshtml");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}