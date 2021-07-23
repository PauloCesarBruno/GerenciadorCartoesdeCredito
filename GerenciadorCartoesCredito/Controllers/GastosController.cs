using System;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorCartoesCredito.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorCartoesCredito.Controllers
{
    public class GastosController : Controller
    {
         private readonly Contexto _contexto;

        public GastosController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> ListagemGastos(int cartaoId)
        {
            Cartao cartao = await _contexto.Cartoes.FindAsync(cartaoId);
            //Variavel soma para efetuar o cálculo de Somar
            double soma = await _contexto.Gastos.Where(c=> c.CartaoId == cartaoId).SumAsync(c=> c.Valor);
            // Instanciado um objeto -> gastosViewModel
            GastosViewModel gastosViewModel = new GastosViewModel
            {
                CartaoId = cartaoId,
                NumeroCartao = cartao.NumeroCartao,
                ListaGastos = await _contexto.Gastos.Where(c=> c.CartaoId == cartaoId).ToListAsync(),
                PorcentagemGasta = Convert.ToInt32((soma / cartao.Limite) * 100) // Aqui acho a porcentagem
            };
            return View(gastosViewModel);
        }
    }
}