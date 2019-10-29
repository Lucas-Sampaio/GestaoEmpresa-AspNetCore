using GestaoEmpresa.DominioViewModel.FuncionarioViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoEmpresa.DominioViewModel.EmpresaViewModel
{
    public class EmpresaVM
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Cep { get; set; }
        public List<FuncionarioVM> Funcionarios { get; set; }
    }
}
