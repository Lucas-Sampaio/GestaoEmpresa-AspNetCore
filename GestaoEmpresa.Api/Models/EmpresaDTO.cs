using System.ComponentModel.DataAnnotations;

namespace GestaoEmpresa.Api.Models
{
    public class EmpresaDTO
    {
        public EmpresaDTO() { }

        public EmpresaDTO(string nome, string cnpj, int id)
        {
            Nome = nome;
            Cnpj = cnpj;
            Id = id;
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get;  set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cnpj { get;  set; }
    }
}
