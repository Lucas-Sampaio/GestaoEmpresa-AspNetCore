namespace GestaoEmpresa.Api.Models
{
    public class JornadaTrabalhoResult
    {
        public JornadaTrabalhoResult()
        {

        }

        public JornadaTrabalhoResult(int id, int idFuncionario, string periodoDia, string periodoHora)
        {
            Id = id;
            IdFuncionario = idFuncionario;
            PeriodoDia = periodoDia;
            PeriodoHora = periodoHora;
        }

        public int Id { get; set; }
        public int IdFuncionario { get; set; }
        public string PeriodoDia { get; set; }
        public string PeriodoHora { get; set; }
    }
}
