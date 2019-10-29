using GestaoEmpresa.DominioViewModel.JornadaTrabalhoViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GestaoEmpresa.DominioViewModel.FuncionarioViewModel
{
    public class FuncionarioVM
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdEndereco { get; set; }
        public string Pis { get; set; }
        [DisplayName("Matrícula")]
        public string Matricula { get; set; }
        [DisplayName("Função")]
        public string Funcao { get; set; }
        public string Nome { get; set; }
        [DisplayName("CPF")]
        public string Cpf { get; set; }
        [DisplayName("Jornadas de Trabalho")]
        public List<JornadaVM> Jornadas { get; set; }
        public string Cep { get; set; }
    }
}
