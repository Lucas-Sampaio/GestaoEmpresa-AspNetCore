using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoEmpresa.DominioViewModel.EnderecoViewModel
{
    public class EnderecoVMVal
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} obrigatório")]
        [MaxLength(10, ErrorMessage = "{0} pode ter no maximo {1} caracteres")]
        public string Cep { get; set; }
        [MaxLength(250, ErrorMessage = "{0} pode ter no maximo {1} caracteres")]
        public string Logradouro { get; set; }
        [MaxLength(100, ErrorMessage = "{0} pode ter no maximo {1} caracteres")]
        public string Bairro { get; set; }
        [MaxLength(100, ErrorMessage = "{0} pode ter no maximo {1} caracteres")]
        public string Cidade { get; set; }
        [MaxLength(50, ErrorMessage = "{0} pode ter no maximo {1} caracteres")]
        public string Estado { get; set; }
    }
}
