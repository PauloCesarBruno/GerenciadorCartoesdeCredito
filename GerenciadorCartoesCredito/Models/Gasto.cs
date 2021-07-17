namespace GerenciadorCartoesCredito.Models
{
    public class Gasto
    {
        public int GastoId { get; set; }

        public int CartaoId { get; set; }

        public Cartao Cartao { get; set; }

        public double Valor { get; set; }
    }
}