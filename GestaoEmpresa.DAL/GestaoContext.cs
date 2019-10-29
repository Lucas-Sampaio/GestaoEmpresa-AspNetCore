using GestaoEmpresa.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoEmpresa.DAL
{
    class GestaoContext : DbContext
    {
        public GestaoContext() : base() { }
        public GestaoContext(DbContextOptions<GestaoContext> options = null) : base(options)
        {

        }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<JornadaTrabalho> Jornadas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}
