using GestaoEmpresa.Dominio;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEmpresa.DAL
{
    public class GestaoContext : DbContext, IUnitOfWork
    {
        public GestaoContext() : base() { }
        public GestaoContext(DbContextOptions<GestaoContext> options = null) : base(options)
        {
            //desabilita o rastreamento
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<JornadaTrabalho> Jornadas { get; set; }

        public async Task<bool> Commit()
        {
            var sucesso = await base.SaveChangesAsync() > 0;
            return sucesso;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configura as propriedades string que não foram configuradas para o padrao varchar(100)
            var propriedades = modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetProperties().Where(y => y.ClrType == typeof(string)));
            foreach (var property in propriedades)
            {
                property.SetColumnType("varchar(100)");
            }
            //impede a delete em cascata
            var relacoes = modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys());
            foreach (var item in relacoes)
            {
                item.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GestaoContext).Assembly);
        }
    }
}
