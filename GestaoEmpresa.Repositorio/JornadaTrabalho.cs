using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoEmpresa.Repositorio
{
    public class JornadaTrabalhoRepositorio : RepositorioGenerico<JornadaTrabalho>
    {
        public JornadaTrabalhoRepositorio(DbContext context) : base(context)
        {
        }
    }
}
