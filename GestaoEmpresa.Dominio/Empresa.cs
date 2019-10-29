using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoEmpresa.Dominio
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public int? IdEndereco { get; set; }
        public Endereco Endereco { get; set; }
        public List<Funcionario> Funcionarios { get; set; }
    }
}
