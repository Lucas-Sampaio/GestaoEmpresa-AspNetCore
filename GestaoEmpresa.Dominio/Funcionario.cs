using System.Collections.Generic;

namespace GestaoEmpresa.Dominio
{
    public class Funcionario : EntityBase, IAggregateRoot
    {
        protected Funcionario() { }

        public Funcionario(int empresaId, string pis, string matricula, string funcao, string nome, string cpf)
        {
            Pis = new Pis(pis);
            Matricula = matricula;
            Funcao = funcao;
            Nome = nome;
            Cpf = new Cpf(cpf);
            IdEmpresa = empresaId;
        }

        public int IdEmpresa { get; set; }
        public Pis Pis { get; private set; }
        public string Matricula { get; private set; }
        public string Funcao { get; private set; }
        public string Nome { get; private set; }
        public Cpf Cpf { get; private set; }
        public List<JornadaTrabalho> Jornadas { get; set; } = new List<JornadaTrabalho>();
        public Endereco Endereco { get; set; }

        public void AtualizarFuncionario(string matricula, string funcao, string nome)
        {  
            Matricula = matricula;
            Funcao = funcao;
            Nome = nome;
        }
        public void AtualizarEmpresa(int empresaId) { IdEmpresa = empresaId; }
        public void AtualizarPis(string pis)
        {
            Pis = new Pis(pis);
        }
        public void AtualizarCpf(string cpf)
        {
            Cpf = new Cpf(cpf);
        }
        public void AtribuirEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }
        public void AdicionarJornada(JornadaTrabalho jornada)
        {
            Jornadas.Add(jornada);
        }
    }
}
