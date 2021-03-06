﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoEmpresa.Web.Models
{
    public class JornadaTrabalhoVMVAL
    {
        public int Id { get; set; }
        public int IdFuncionario { get; set; }
        [DisplayName("Dia Inicial")]
        [Required(ErrorMessage = "{0} obrigatório")]
        public int DiaInicio { get; set; }
        [DisplayName("Dia Final")]
        public int? DiaFim { get; set; }
        [DisplayName("Hora Inicio")]
        [Required(ErrorMessage = "{0} obrigatório")]
        [DataType(DataType.Time)]
        public TimeSpan HoraInicio { get; set; }
        [DisplayName("Hora Final")]
        [Required(ErrorMessage = "{0} obrigatório")]
        [DataType(DataType.Time)]
        public TimeSpan HoraFim { get; set; }
    }
}
