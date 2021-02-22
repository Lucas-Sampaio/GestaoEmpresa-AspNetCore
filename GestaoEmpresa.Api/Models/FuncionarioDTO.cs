using System.ComponentModel.DataAnnotations;

namespace GestaoEmpresa.Api.Models
{
    public class FuncionarioDTO
    {
        public int Id { get; set; } 
        public int IdEmpresa { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Pis { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Matricula { get;  set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Funcao { get;  set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get;  set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cpf { get;  set; }

    }
}
