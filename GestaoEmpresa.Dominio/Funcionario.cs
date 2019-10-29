using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoEmpresa.Dominio
{
    public class Funcionario
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdEndereco { get; set; }
        public string Pis { get; set; }
        public string Matricula { get; set; }
        public string Funcao { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public List<JornadaTrabalho> Jornadas { get; set; }
        public Endereco Endereco { get; set; }
    }
}
