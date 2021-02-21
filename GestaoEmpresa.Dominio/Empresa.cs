using System.Collections.Generic;

namespace GestaoEmpresa.Dominio
{
    public class Empresa : EntityBase, IAggregateRoot
    {
        public Empresa(string nome, string cnpj)
        {
            Nome = nome;
            Cnpj = new Cnpj(cnpj);
        }

        protected Empresa() { }
        public string Nome { get; private set; }
        public Cnpj Cnpj { get; private set; }
        public Endereco Endereco { get; private set; }
        public List<Funcionario> Funcionarios { get; set; }

        public void AtribuirEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }
        public void AtualizarNome(string nome)
        {
            Nome = nome;
        }
        public void AtualizarCnpj(string cnpj)
        {
            Cnpj = new Cnpj(cnpj);
        }
    }
}
