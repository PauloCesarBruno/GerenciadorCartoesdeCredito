using System.ComponentModel.DataAnnotations;

namespace GerenciadorCartoesCredito.Models
{
    public class Gasto
    {
        public int GastoId { get; set; }

        public int CartaoId { get; set; }

        public Cartao Cartao { get; set; }  

        [Required(ErrorMessage ="Campo Obrigatório !")]
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório !")]
        [DataType(DataType.Currency)]
        public double Valor { get; set; }
    }
}