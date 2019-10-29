using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GestaoEmpresa.DominioViewModel.JornadaTrabalhoViewModel
{
    public class JornadaVM
    {
        public int Id { get; set; }
        public int IdFuncionario { get; set; }
        [DisplayName("Dias de Trabalho")]
        public string PeriodoDia { get; set; }
        [DisplayName("Horas de Trabalho")]
        public string PeriodoHora { get; set; }
    }
}
