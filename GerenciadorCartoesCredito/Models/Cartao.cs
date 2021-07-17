using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorCartoesCredito.Models
{
    public class Cartao
    {
        public int CartaoId { get; set; }

        [Required(ErrorMessage ="Campo Obrigatorio !")]
        public string NomeBanco { get; set; }

        [Required(ErrorMessage ="Campo Obrigatorio !")]
        public string NumeroCartao { get; set; }

        [Required(ErrorMessage ="Campo Obrigatorio !")]
        public double Limite { get; set; }

        public ICollection<Gasto> Gastos { get; set; }
    }
}