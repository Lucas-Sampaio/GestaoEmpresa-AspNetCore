using System.ComponentModel;

namespace GestaoEmpresa.Web.Models
{
    public class JornadaTrabalhoVM
    {
        public int Id { get; set; }
        public int IdFuncionario { get; set; }
        [DisplayName("Dias de Trabalho")]
        public string PeriodoDia { get; set; }
        [DisplayName("Horas de Trabalho")]
        public string PeriodoHora { get; set; }
    }
}
