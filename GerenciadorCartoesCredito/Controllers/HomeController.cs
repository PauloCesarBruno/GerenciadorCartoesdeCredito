using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GerenciadorCartoesCredito.Models;
using Microsoft.AspNetCore.Http;

namespace GerenciadorCartoesCredito.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(int? Id)
        {
            if (Id != null)
            {
                if (Id == 0)
                {
                    HttpContext.Session.SetString("IdUsuario", string.Empty);
                    HttpContext.Session.SetString("NomeUsuario", string.Empty);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(ModelLogin login)
        {
            if (ModelState.IsValid)
            {
                bool loginOk = login.ValidarLogin();
                if (loginOk)
                {
                    HttpContext.Session.SetString("IdUsuario", login.Id);
                    HttpContext.Session.SetString("NomeUsuario", login.Nome);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["ErrorMessage"] = "Email e/ou Senha Incorreto(s) !";
                }
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
