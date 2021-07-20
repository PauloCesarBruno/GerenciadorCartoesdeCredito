using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorCartoesCredito.Models
{
    public class Cartao
    {
        public int CartaoId { get; set; }

        [Required(ErrorMessage ="Campo Obrigatorio !")]
        [Display(Name ="Nome do Banco")]
        public string NomeBanco { get; set; }

        [Required(ErrorMessage ="Campo Obrigatorio !")]
        [Display(Name ="Número do Cartão")]
        public string NumeroCartao { get; set; }

        [Required(ErrorMessage ="Campo Obrigatorio !")]
        [Display(Name ="Limite de Crédito")]
        [DataType(DataType.Currency)]
        public double Limite { get; set; }

        public ICollection<Gasto> Gastos { get; set; }
    }
}