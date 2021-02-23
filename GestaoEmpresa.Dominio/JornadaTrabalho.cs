using GestaoEmpresa.Dominio.Enums;
using System;

namespace GestaoEmpresa.Dominio
{
    public class JornadaTrabalho : EntityBase
    {
        public JornadaTrabalho(int idFuncionario, EDiaSemana diaInicio, EDiaSemana? diaFim, TimeSpan horaInicio, TimeSpan horaFim)
        {
            IdFuncionario = idFuncionario;
            DiaInicio = diaInicio;
            DiaFim = diaFim;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
        }

        protected JornadaTrabalho() { }
        
        public int IdFuncionario { get; set; }
        public EDiaSemana DiaInicio { get; set; }
        public EDiaSemana? DiaFim { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }

        public string ObterPeriodoDia()
        {
            return DiaFim.HasValue ? $"De {DiaInicio} a {DiaFim}" : DiaInicio.ToString();
        }
        public string ObterPeriodoHora()
        {
            return $"De {HoraInicio.ToString(@"hh\:mm\:ss")} as {HoraFim.ToString(@"hh\:mm\:ss")}";
        }
    }
}
