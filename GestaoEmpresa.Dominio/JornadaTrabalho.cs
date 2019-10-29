using GestaoEmpresa.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoEmpresa.Dominio
{
    public class JornadaTrabalho
    {
        public int Id { get; set; }
        public int IdFuncionario { get; set; }
        public EDiaSemana DiaInicio { get; set; }
        public EDiaSemana? DiaFim { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
    }
}
