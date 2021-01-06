using System.Collections.Generic;

namespace GestaoEmpresa.Dominio
{
    public class Empresa : EntityBase,IAggregateRoot
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public int? IdEndereco { get; set; }
        public Endereco Endereco { get; set; }
        public List<Funcionario> Funcionarios { get; set; }
    }
}
