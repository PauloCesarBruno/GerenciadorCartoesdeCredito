using System.Threading.Tasks;
using GerenciadorCartoesCredito.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorCartoesCredito.Controllers
{
    public class CartoesController : Controller
    {
        private readonly Contexto _contexto;

        public CartoesController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            return View();
        }   

        [HttpGet]
        public IActionResult NovoCartao()
        {
            return View();
        }     

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NovoCartao(Cartao cartao)
        {
            if (ModelState.IsValid)
            {
                await _contexto.AddAsync(cartao);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(NovoCartao));
            }
            return View(cartao);
        }
    }
}