using GestaoEmpresa.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoEmpresa.DAL.TypeConfiguration
{
    public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");
            builder.HasKey(x => x.Id).HasName("PK_empId");
            builder.Property(x => x.Id).HasColumnName("emp_int_id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.Nome).HasColumnName("emp_str_nome").IsRequired().IsUnicode();
            builder.OwnsOne(x => x.Cnpj, y =>
            {
                y.Property(c => c.Numero).IsRequired().HasMaxLength(Cnpj.MaxLength).HasColumnName("emp_str_cnpj").HasColumnType($"varchar({Cnpj.MaxLength})");
            });

            builder.OwnsOne(x => x.Endereco, e =>
            {
                e.Property(x => x.Logradouro).HasColumnName("emp_str_logradouro").HasMaxLength(250).IsUnicode();
                e.Property(x => x.Bairro).HasColumnName("emp_str_bairro").IsUnicode();
                e.Property(x => x.Cidade).HasColumnName("emp_str_cidade").IsUnicode();
                e.Property(x => x.Estado).HasColumnName("emp_str_estado").IsUnicode();
                e.Property(x => x.Cep).HasColumnName("emp_str_cep");
            });

            builder.HasMany(x => x.Funcionarios).WithOne().IsRequired().HasForeignKey(x => x.IdEmpresa).HasConstraintName("FK_emp_func").OnDelete(DeleteBehavior.Cascade);
        }
    }
}
