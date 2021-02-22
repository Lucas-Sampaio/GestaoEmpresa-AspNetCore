using GestaoEmpresa.Web.Extensions.Atributos;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoEmpresa.Web.Models
{
    public class FuncionarioVM
    {
        public int Id { get; set; }
        [DisplayName("Empresa")]
        public int IdEmpresa { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Pis]
        [DisplayName("PIS")]
        public string Pis { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        [DisplayName("Matricula")]
        public string Matricula { get; private set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Função")]
        public string Funcao { get; private set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Nome")]
        public string Nome { get; private set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("CPF")]
        [Cpf]
        public string Cpf { get; private set; }
    }
}
