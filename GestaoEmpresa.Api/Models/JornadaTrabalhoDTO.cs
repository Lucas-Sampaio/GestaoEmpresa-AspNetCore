using GestaoEmpresa.Dominio.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoEmpresa.Api.Models
{
    public class JornadaTrabalhoDTO
    {
        public int Id { get; set; }
        public int IdFuncionario { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        public EDiaSemana DiaInicio { get; set; }
        public EDiaSemana? DiaFim { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        public TimeSpan HoraInicio { get; set; }
        [Required(ErrorMessage = "{0} obrigatório")]
        public TimeSpan HoraFim { get; set; }
        
    }
}
