using GestaoEmpresa.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoEmpresa.DAL.TypeConfiguration
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionario");
            builder.HasKey(x => x.Id).HasName("PK_funcId");
            builder.Property(x => x.Id).HasColumnName("func_int_id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.Nome).HasColumnName("func_str_nome").HasMaxLength(100).IsRequired().IsUnicode();
            builder.Property(x => x.Cpf).HasColumnName("func_str_cpf").HasMaxLength(11).IsRequired();
            builder.Property(x => x.Matricula).HasColumnName("func_str_matricula").HasMaxLength(20).IsRequired();
            builder.Property(x => x.Funcao).HasColumnName("func_str_cargo").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Pis).HasColumnName("func_str_pis").HasMaxLength(20);
            builder.Property(x => x.IdEmpresa).HasColumnName("emp_int_id").IsRequired();
            builder.Property(x => x.IdEndereco).HasColumnName("end_int_id");
            builder.HasOne(x => x.Endereco).WithOne().HasForeignKey<Funcionario>(x => x.IdEndereco)
                .HasConstraintName("FK_func_end").IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(x => x.Jornadas).WithOne().IsRequired().HasForeignKey(x => x.IdFuncionario)
                .HasConstraintName("FK_func_jnd").OnDelete(DeleteBehavior.Cascade);
        }
    }
}
