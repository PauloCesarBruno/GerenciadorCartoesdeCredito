using System.ComponentModel.DataAnnotations;
using System.Data;
using GerenciadorCartoesCredito.Data_Access_Layer;

namespace GerenciadorCartoesCredito.Models
{
    public class ModelCadastro
    {        
        public string Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [Display(Name = " Nome")]
        [MaxLength(50, ErrorMessage = "Maximo 50 (cinquenta) caracteres !")]
        [MinLength(3, ErrorMessage = "Mínimo 03 (três) caracteres !")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O Email não possui um formato válido !")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [MinLength(4, ErrorMessage = "Mínimo 04 caracteres !")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [MinLength(4, ErrorMessage = "Mínimo 04 caracteres !")]
        [Display(Name = "Confirme à Senha")]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "A senha não confere !")]
        public string ConfSenha { get; set; }


        public void InserirUsuario()
        {
            try
            {
                if (Id == null)
                {
                    Dal dal = new Dal();
                    dal.LimparParametros();
                    dal.AddParametros("Nome", Nome);
                    dal.AddParametros("Email", Email);
                    dal.AddParametros("Senha", Senha);
                    string IdUsuario = dal.ExecutarManipulacao(CommandType.Text, "Insert Into Login (Nome, Email, Senha) Values (@Nome, @Email, @Senha)").ToString();
                    dal.FecharConexao();
                }
                else
                {
                    //
                }
            }
            catch
            {
                //
            }
        }
    }
}