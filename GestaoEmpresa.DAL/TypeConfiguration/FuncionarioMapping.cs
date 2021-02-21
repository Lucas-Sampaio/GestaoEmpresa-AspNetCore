using GestaoEmpresa.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoEmpresa.DAL.TypeConfiguration
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionario");
            builder.HasKey(x => x.Id).HasName("PK_funcId");
            builder.Property(x => x.Id).HasColumnName("func_int_id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.IdEmpresa).HasColumnName("emp_int_id").IsRequired();

            builder.Property(x => x.Nome).HasColumnName("func_str_nome").IsRequired().IsUnicode();
            builder.OwnsOne(x => x.Cpf, y =>
            {
                y.Property(c => c.Numero).IsRequired().HasMaxLength(Cpf.MaxLength).HasColumnName("func_str_cpf").HasColumnType($"varchar({Cpf.MaxLength})");
            });

            builder.Property(x => x.Matricula).HasColumnName("func_str_matricula").HasMaxLength(20).IsRequired();
            builder.Property(x => x.Funcao).HasColumnName("func_str_cargo").IsRequired();

            builder.OwnsOne(x => x.Pis, y =>
             {
                 y.Property(c => c.Numero).IsRequired().HasMaxLength(Pis.MaxLength).HasColumnName("func_str_pis").HasColumnType($"varchar({Pis.MaxLength})");

             });

            builder.OwnsOne(x => x.Endereco, e =>
            {
                e.Property(x => x.Logradouro).HasColumnName("func_str_logradouro").HasMaxLength(250).IsUnicode();
                e.Property(x => x.Bairro).HasColumnName("func_str_bairro").IsUnicode();
                e.Property(x => x.Cidade).HasColumnName("func_str_cidade").IsUnicode();
                e.Property(x => x.Estado).HasColumnName("func_str_estado").IsUnicode();
                e.Property(x => x.Cep).HasColumnName("func_str_cep");
            });

            builder.HasMany(x => x.Jornadas).WithOne().IsRequired().HasForeignKey(x => x.IdFuncionario)
                .HasConstraintName("FK_func_jnd").OnDelete(DeleteBehavior.Cascade);
        }
    }
}
