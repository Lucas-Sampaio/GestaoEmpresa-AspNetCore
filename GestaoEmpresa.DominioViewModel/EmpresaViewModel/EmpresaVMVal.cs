using GestaoEmpresa.DominioViewModel.EnderecoViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoEmpresa.DominioViewModel.EmpresaViewModel
{
    public class EmpresaVMVal
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} obrigatório")]
        [MaxLength(100, ErrorMessage = "{0} pode ter no maximo {1} caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "{0} obrigatório")]
        [MaxLength(14, ErrorMessage = "{0} pode ter no maximo {1} caracteres")]
        public string Cnpj { get; set; }
        [DisplayName("Endereço")]
        public EnderecoVMVal Endereco { get; set; }
    }
}
