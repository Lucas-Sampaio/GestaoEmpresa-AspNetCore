using GestaoEmpresa.DominioViewModel.EnderecoViewModel;
using GestaoEmpresa.DominioViewModel.FuncionarioViewModel;
using System.Collections.Generic;
using System.ComponentModel;

namespace GestaoEmpresa.DominioViewModel.EmpresaViewModel
{
    public class EmpresaVM
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Cep { get; set; }
        [DisplayName("Endereço")]
        public EnderecoVMVal Endereco { get; set; }
        public List<FuncionarioVM> Funcionarios { get; set; }
    }
}
