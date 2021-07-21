using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using GerenciadorCartoesCredito.Data_Access_Layer;

namespace GerenciadorCartoesCredito.Models
{
    public class ModelLogin
    {  
        public string Id { get; set; }

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

        public bool ValidarLogin()
        {
            try
            {
                Dal dal = new Dal();
                dal.LimparParametros();

                string sql = $"Select Id, Nome From Login Where Email = '{Email}' And Senha = '{Senha}'";
                DataTable dt = dal.RetDatatable(sql);

                if (dt.Rows.Count == 1)
                {
                    Id = dt.Rows[0]["Id"].ToString();
                    Nome = dt.Rows[0]["Nome"].ToString();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}