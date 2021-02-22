using GestaoEmpresa.Web.Extensions.Atributos;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoEmpresa.Web.Models
{
    public class EmpresaVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("CNPJ")]
        [Cnpj]
        public string Cnpj { get; set; }
    }
}
