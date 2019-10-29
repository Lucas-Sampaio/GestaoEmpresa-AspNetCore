using GestaoEmpresa.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoEmpresa.DAL.TypeConfiguration
{
    public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");
            builder.HasKey(x => x.Id).HasName("PK_empId");
            builder.Property(x => x.Id).HasColumnName("emp_int_id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.Nome).HasColumnName("emp_str_nome").HasMaxLength(100).IsRequired().IsUnicode();
            builder.Property(x => x.Cnpj).HasColumnName("emp_str_cnpj").HasMaxLength(14).IsRequired();
            builder.Property(x => x.IdEndereco).HasColumnName("end_int_id");
            builder.HasOne(x => x.Endereco).WithOne().HasForeignKey<Empresa>(x => x.IdEndereco).HasConstraintName("FK_emp_end").IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(x => x.Funcionarios).WithOne().IsRequired().HasForeignKey(x => x.IdEmpresa).HasConstraintName("FK_emp_func").OnDelete(DeleteBehavior.Cascade);
        }
    }
}
