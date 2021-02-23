using System.ComponentModel.DataAnnotations;

namespace GestaoEmpresa.Web.Models.Enums
{
    public enum EDiaSemanaVM
    {
        Domingo,
        [Display(Name = "Segunda-Feira")]
        Segunda,
        [Display(Name = "Terça-Feira")]
        Terca,
        [Display(Name = "Quarta-Feira")]
        quarta,
        [Display(Name = "Quinta-Feira")]
        quinta,
        [Display(Name = "Sexta-Feira")]
        sexta,
        [Display(Name = "Sábado")]
        sabado
    }
}
