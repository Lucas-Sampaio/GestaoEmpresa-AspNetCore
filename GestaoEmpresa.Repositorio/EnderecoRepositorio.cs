using GestaoEmpresa.Dominio;
using GestaoEmpresa.Repositorio.RepositorioComum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoEmpresa.Repositorio
{
    public class EnderecoRepositorio : RepositorioGenerico<Endereco>
    {
        public EnderecoRepositorio(DbContext context) : base(context)
        {
        }
    }
}
