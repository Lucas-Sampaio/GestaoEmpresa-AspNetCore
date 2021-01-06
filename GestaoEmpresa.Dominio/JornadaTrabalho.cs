using GestaoEmpresa.Dominio.Enums;
using System;

namespace GestaoEmpresa.Dominio
{
    public class JornadaTrabalho : EntityBase
    {
        public int IdFuncionario { get; set; }
        public EDiaSemana DiaInicio { get; set; }
        public EDiaSemana? DiaFim { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
    }
}
