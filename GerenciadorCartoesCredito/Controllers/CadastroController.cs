using GerenciadorCartoesCredito.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorCartoesCredito.Controllers
{
    public class CadastroController : Controller
    {
        [HttpGet]
        public IActionResult Cadastro(int? Id)
        {
            if (Id != null)
            {
                ViewBag.User = new ModelCadastro();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(ModelCadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                cadastro.InserirUsuario();
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
    }
}