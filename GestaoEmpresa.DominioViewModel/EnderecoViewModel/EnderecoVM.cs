using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoEmpresa.DominioViewModel.EnderecoViewModel
{
    public class EnderecoVM
    {
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
