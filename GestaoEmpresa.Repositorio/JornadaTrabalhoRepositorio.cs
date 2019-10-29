using GestaoEmpresa.Dominio;
using GestaoEmpresa.Repositorio.RepositorioComum;
using Microsoft.EntityFrameworkCore;
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
