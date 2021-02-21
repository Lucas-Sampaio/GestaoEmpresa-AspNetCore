using System.ComponentModel.DataAnnotations;

namespace GestaoEmpresa.Api.Models
{
    public class EmpresaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; private set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cnpj { get; private set; }
    }
}
