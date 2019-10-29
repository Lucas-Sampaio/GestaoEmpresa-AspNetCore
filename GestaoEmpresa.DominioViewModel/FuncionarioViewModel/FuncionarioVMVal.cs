using GestaoEmpresa.DominioViewModel.EnderecoViewModel;
using GestaoEmpresa.DominioViewModel.JornadaTrabalhoViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoEmpresa.DominioViewModel.FuncionarioViewModel
{
    public class FuncionarioVMVal
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Empresa obrigatória")]
        [DisplayName("Empresa")]
        public int IdEmpresa { get; set; }
        public int? IdEndereco { get; set; }
        [MaxLength(20, ErrorMessage = "{0} pode ter no maximo {1} caracteres")]
        public string Pis { get; set; }
        [DisplayName("Matrícula")]
        [MaxLength(20, ErrorMessage = "{0} pode ter no maximo {1} caracteres")]
        public string Matricula { get; set; }
        [DisplayName("Função")]
        [MaxLength(50, ErrorMessage = "{0} pode ter no maximo {1} caracteres")]
        public string Funcao { get; set; }
        [MaxLength(100, ErrorMessage = "{0} pode ter no maximo {1} caracteres")]
        public string Nome { get; set; }
        [DisplayName("CPF")]
        [Required(ErrorMessage = "{0} obrigatório")]
        [MaxLength(11)]
        public string Cpf { get; set; }
        [DisplayName("Endereço")]
        public EnderecoVMVal Endereco { get; set; }
        public List<JornadaVM> Jornadas { get; set; }
    }
}
